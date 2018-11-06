using System;
using System.Collections.Generic;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorArvRenalDosageResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public Button ButtonCalculateCreatinineClearance;

            public StackLayout StackLayout;

            public CalculatorArvRenalDosageView CalculatorArvRenalDosageView;

            public List<CalculatorArvRenalDosageDosageItem> CalculatorArvRenalDosageDosageItems;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorArvRenalDosageResult()
        {
            this.InitializeComponent();

            this.View.ButtonCalculateCreatinineClearance = this.buttonCalculateCreatinineClearance;
            this.View.ButtonCalculateCreatinineClearance.Text = HivResources.CalculatorArvRenalDosageCalculateCreatinineClearance;
            this.View.ButtonCalculateCreatinineClearance.Clicked += this.OnButtonCalculateCreatinineClearanceClicked;
            this.View.StackLayout = this.stackLayout;

            this.Title = HivResources.CalculatorArvRenalDosageResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorArvRenalDosageView))
            {
                this.View.CalculatorArvRenalDosageView = (CalculatorArvRenalDosageView) this.BindingContext;

                if (this.View.CalculatorArvRenalDosageView.DosageItem == null)
                {
                    App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - ARV '{2}', Dosage '{3}'", PCLResources.Calculators, HivResources.CalculatorArvRenalDosage, this.View.CalculatorArvRenalDosageView.Arv, this.View.CalculatorArvRenalDosageView.Dosage));
                }
                else
                {
                    App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - ARV '{2}', Dosage '{3}', Dosage Item '{4}'", PCLResources.Calculators, HivResources.CalculatorArvRenalDosage, this.View.CalculatorArvRenalDosageView.Arv, this.View.CalculatorArvRenalDosageView.Dosage, this.View.CalculatorArvRenalDosageView.DosageItem));
                }

                this.View.CalculatorArvRenalDosageDosageItems = this.View.RepositoryCalculatorArvRenalDosageDosageItem.GetByCalculatorArvRenalDosageDosage(this.View.CalculatorArvRenalDosageView.Dosage.Id);

                if (this.View.CalculatorArvRenalDosageView.CreatinineClearance.HasValue)
                {
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(HivResources.CalculatorArvRenalDosageCalculatedCreatinineClearance).Bold(), new LabelView(this.View.CalculatorArvRenalDosageView.CreatinineClearance.Value + " " + HivResources.CalculatorArvRenalDosageCreatinineClearanceUnit), 0.7, 0.3));

                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateSpace.Create());
                }

                Boolean displayAsterisk = false;

                foreach (CalculatorArvRenalDosageDosageItem calculatorArvRenalDosageDosageItem in this.View.CalculatorArvRenalDosageDosageItems)
                {
                    Boolean selected = this.View.CalculatorArvRenalDosageView.DosageItem != null && this.View.CalculatorArvRenalDosageView.DosageItem.Id.Equals(calculatorArvRenalDosageDosageItem.Id);

                    if (!displayAsterisk)
                    {
                        displayAsterisk = calculatorArvRenalDosageDosageItem.Title.Contains("*") || calculatorArvRenalDosageDosageItem.Value.Contains("*");
                    }

                    if (!selected)
                    {
                        this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(calculatorArvRenalDosageDosageItem.Title).Bold(), new LabelView(calculatorArvRenalDosageDosageItem.Value)));
                    }
                    else
                    {
                        this.View.StackLayout.Children.Add(new StackLayout()
                        {
                            Orientation = StackOrientation.Horizontal,
                            BackgroundColor = PCL.App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark(),
                            Children =
                            {
                                TemplateRow2.Create(new LabelView(calculatorArvRenalDosageDosageItem.Title).Bold(), new LabelView(calculatorArvRenalDosageDosageItem.Value), 0.85, true),
                                new ImageView(ImageSource.FromFile("selected_tick.png"), PCL.App.ScreenSize.Width*0.15)
                            }
                        });
                    }
                }

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                if (displayAsterisk)
                {
                    this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorArvRenalDosageResultAsterisk)._Disclaimer()));
                }

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorArvRenalDosageDisclaimer)._Disclaimer()));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorArvRenalDosageSource)._Disclaimer()));
            }
        }

        private void OnButtonCalculateCreatinineClearanceClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new ViewCalculatorArvRenalDosageCreatinineClearance
            {
                BindingContext = this.View.CalculatorArvRenalDosageView
            }, true);
        }
    }
}