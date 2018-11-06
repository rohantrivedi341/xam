using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorArvRenalDosageCreatinineClearance : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;
            public Button CalculateButton;

            public TemplateColumn2 LabelEntryCreatinine;
            public TemplateColumn2 LabelEntryWeight;
            public TemplateColumn2 LabelEntryAge;
            public TemplateColumn2 LabelPickerSex;

            public CalculatorArvRenalDosageView CalculatorArvRenalDosageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorArvRenalDosageCreatinineClearance()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;
            this.View.CalculateButton = this.calculateButton;

            this.Title = HivResources.CalculatorArvRenalDosageCalculateCreatinineClearance;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorArvRenalDosageView))
            {
                this.View.CalculatorArvRenalDosageView = (CalculatorArvRenalDosageView)this.BindingContext;
                this.View.CalculatorArvRenalDosageView.Dosage = null;
                this.View.CalculatorArvRenalDosageView.DosageItem = null;
                this.View.CalculatorArvRenalDosageView.CreatinineClearance = null;

                this.View.LabelEntryCreatinine = TemplateColumn2.Create(new LabelView(HivResources.CalculatorArvRenalDosageCreatinine).Bold(), new EntryView(String.Empty, Keyboard.Numeric, HivResources.CalculatorArvRenalDosageCreatinineHint));
                this.View.StackLayout.Children.Add(this.View.LabelEntryCreatinine);

                this.View.LabelEntryWeight = TemplateColumn2.Create(new LabelView(HivResources.CalculatorArvRenalDosageWeight).Bold(), new EntryView(String.Empty, Keyboard.Numeric, HivResources.CalculatorArvRenalDosageWeightHint));
                this.View.StackLayout.Children.Add(this.View.LabelEntryWeight);

                this.View.LabelEntryAge = TemplateColumn2.Create(new LabelView(HivResources.CalculatorArvRenalDosageAge).Bold(), new EntryView(String.Empty, Keyboard.Numeric, HivResources.CalculatorArvRenalDosageAgeHint));
                this.View.StackLayout.Children.Add(this.View.LabelEntryAge);

                List<String> sexes = new List<String>();
                sexes.Add(HivResources.CalculatorArvRenalDosageSexMale);
                sexes.Add(HivResources.CalculatorArvRenalDosageSexFemale);

                this.View.LabelPickerSex = TemplateColumn2.Create(new LabelView(HivResources.CalculatorArvRenalDosageSex).Bold(), new PickerView(sexes));
                this.View.StackLayout.Children.Add(this.View.LabelPickerSex);

                this.View.CalculateButton.Text = HivResources.CalculatorArvRenalDosageCalculate;
                this.View.CalculateButton.Clicked += this.OnCalculateButtonClicked;

                ((StackLayout)this.View.StackLayout.Parent).Children.Add(TemplateLine.Create());
                ((StackLayout)this.View.StackLayout.Parent).Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorArvRenalDosageCalculateCreatinineClearanceDisclaimer)._Disclaimer()));
            }
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            Double doubleCreatinine;
            Double doubleWeight;
            Double doubleAge;

            if (String.IsNullOrWhiteSpace(this.View.LabelEntryCreatinine.Second.AsEntry().Text))
            {
                this.DisplayAlert(PCLResources.ValidationRequired, HivResources.CalculatorArvRenalDosageCreatinineValidationRequired, PCLResources.OK);

                return;
            }

            if (!Double.TryParse(this.View.LabelEntryCreatinine.Second.AsEntry().Text, out doubleCreatinine))
            {
                this.DisplayAlert(PCLResources.ValidationParsing, HivResources.CalculatorArvRenalDosageCreatinineValidationParsing, PCLResources.OK);

                return;
            }

            if (String.IsNullOrWhiteSpace(this.View.LabelEntryWeight.Second.AsEntry().Text))
            {
                this.DisplayAlert(PCLResources.ValidationRequired, HivResources.CalculatorArvRenalDosageWeightValidationRequired, PCLResources.OK);

                return;
            }

            if (!Double.TryParse(this.View.LabelEntryWeight.Second.AsEntry().Text, out doubleWeight))
            {
                this.DisplayAlert(PCLResources.ValidationParsing, HivResources.CalculatorArvRenalDosageWeightValidationParsing, PCLResources.OK);

                return;
            }

            if (String.IsNullOrWhiteSpace(this.View.LabelEntryAge.Second.AsEntry().Text))
            {
                this.DisplayAlert(PCLResources.ValidationRequired, HivResources.CalculatorArvRenalDosageAgeValidationRequired, PCLResources.OK);

                return;
            }

            if (!Double.TryParse(this.View.LabelEntryAge.Second.AsEntry().Text, out doubleAge))
            {
                this.DisplayAlert(PCLResources.ValidationParsing, HivResources.CalculatorArvRenalDosageAgeValidationParsing, PCLResources.OK);

                return;
            }

            if (doubleAge < 15.0)
            {
                this.DisplayAlert(PCLResources.Validation, HivResources.CalculatorArvRenalDosageAgeValidationOnlyForAdults, PCLResources.OK);

                return;
            }

            if (this.View.LabelPickerSex.Second.AsPicker().SelectedIndex < 0 || this.View.LabelPickerSex.Second.AsPicker().SelectedIndex > 1)
            {
                this.DisplayAlert(PCLResources.ValidationRequired, HivResources.CalculatorArvRenalDosageSexValidationRequired, PCLResources.OK);

                return;
            }

            Double calculationFactor = this.View.LabelPickerSex.Second.AsPicker().SelectedIndex == 0 ? 1.23 : 1.04;

            this.View.CalculatorArvRenalDosageView.CreatinineClearance = (Int32)Math.Floor(((140.0 - doubleAge) * doubleWeight * calculationFactor) / doubleCreatinine);
            
            List<CalculatorArvRenalDosageDosage> calculatorArvRenalDosageDosages = this.View.RepositoryCalculatorArvRenalDosageDosage.GetByCalculatorArvRenalDosageArv(this.View.CalculatorArvRenalDosageView.Arv.Id);

            if (calculatorArvRenalDosageDosages.Count == 1)
            {
                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosages.First();
            }
            else
            {
                this.View.CalculatorArvRenalDosageView.Dosage = null;

                foreach (CalculatorArvRenalDosageDosage calculatorArvRenalDosageDosage in calculatorArvRenalDosageDosages)
                {
                    switch (calculatorArvRenalDosageDosage.Type)
                    {
                        case CalculatorArvRenalDosageDosageType.Normal:
                            break;
                        case CalculatorArvRenalDosageDosageType.GreaterThanOrEqualTo:
                            if (doubleWeight >= calculatorArvRenalDosageDosage.TypeValue)
                            {
                                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosage;
                            }
                            break;
                        case CalculatorArvRenalDosageDosageType.GreaterThan:
                            if (doubleWeight > calculatorArvRenalDosageDosage.TypeValue)
                            {
                                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosage;
                            }
                            break;
                        case CalculatorArvRenalDosageDosageType.LessThanOrEqualTo:
                            if (doubleWeight <= calculatorArvRenalDosageDosage.TypeValue)
                            {
                                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosage;
                            }
                            break;
                        case CalculatorArvRenalDosageDosageType.LessThan:
                            if (doubleWeight < calculatorArvRenalDosageDosage.TypeValue)
                            {
                                this.View.CalculatorArvRenalDosageView.Dosage = calculatorArvRenalDosageDosage;
                            }
                            break;
                    }

                    if (this.View.CalculatorArvRenalDosageView.Dosage != null)
                    {
                        break;
                    }
                }
            }

            if (this.View.CalculatorArvRenalDosageView.Dosage == null)
            {
                this.DisplayAlert(PCLResources.Error, HivResources.CalculatorArvRenalDosageDataIncorrect, PCLResources.OK);

                return;
            }

            List<CalculatorArvRenalDosageDosageItem> calculatorArvRenalDosageDosageItems = this.View.RepositoryCalculatorArvRenalDosageDosageItem.GetByCalculatorArvRenalDosageDosage(this.View.CalculatorArvRenalDosageView.Dosage.Id);

            foreach (CalculatorArvRenalDosageDosageItem calculatorArvRenalDosageDosageItem in calculatorArvRenalDosageDosageItems)
            {
                if (calculatorArvRenalDosageDosageItem.CreatinineClearanceBeginMlPerMinute == null)
                {
                    if (calculatorArvRenalDosageDosageItem.CreatinineClearanceEndMlPerMinute == null)
                    {
                        if (calculatorArvRenalDosageDosageItems.Count == 1)
                        {
                            this.View.CalculatorArvRenalDosageView.DosageItem = calculatorArvRenalDosageDosageItem;
                        }
                    }
                    else
                    {
                        if (this.View.CalculatorArvRenalDosageView.CreatinineClearance <= calculatorArvRenalDosageDosageItem.CreatinineClearanceEndMlPerMinute)
                        {
                            this.View.CalculatorArvRenalDosageView.DosageItem = calculatorArvRenalDosageDosageItem;
                        }
                    }
                }
                else
                {
                    if (calculatorArvRenalDosageDosageItem.CreatinineClearanceEndMlPerMinute != null)
                    {
                        if (this.View.CalculatorArvRenalDosageView.CreatinineClearance >= calculatorArvRenalDosageDosageItem.CreatinineClearanceBeginMlPerMinute && this.View.CalculatorArvRenalDosageView.CreatinineClearance <= calculatorArvRenalDosageDosageItem.CreatinineClearanceEndMlPerMinute)
                        {
                            this.View.CalculatorArvRenalDosageView.DosageItem = calculatorArvRenalDosageDosageItem;
                        }
                    }
                    else
                    {
                        if (this.View.CalculatorArvRenalDosageView.CreatinineClearance >= calculatorArvRenalDosageDosageItem.CreatinineClearanceBeginMlPerMinute)
                        {
                            this.View.CalculatorArvRenalDosageView.DosageItem = calculatorArvRenalDosageDosageItem;
                        }
                    }
                }


                if (this.View.CalculatorArvRenalDosageView.DosageItem != null)
                {
                    break;
                }
            }

            if (this.View.CalculatorArvRenalDosageView.DosageItem == null)
            {
                this.DisplayAlert(PCLResources.Error, HivResources.CalculatorArvRenalDosageDataIncorrect, PCLResources.OK);

                return;
            }

            this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageResult
            {
                BindingContext = this.View.CalculatorArvRenalDosageView
            }, true);
        }
    }
}