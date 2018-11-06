using System;
using PCL.Hiv.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorPaediatricArvDosageResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorPaediatricArvDosageView CalculatorPaediatricArvDosageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }
        
        public ViewCalculatorPaediatricArvDosageResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = HivResources.CalculatorPaediatricArvDosageResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricArvDosageView))
            {
                this.View.CalculatorPaediatricArvDosageView = (CalculatorPaediatricArvDosageView) this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - ARV '{2}', Weight Group '{3}'", PCLResources.Calculators, HivResources.CalculatorPaediatricArvDosage, this.View.CalculatorPaediatricArvDosageView.Arv, this.View.CalculatorPaediatricArvDosageView.WeightGroup));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageArv).Bold(), new LabelView(this.View.CalculatorPaediatricArvDosageView.Arv.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageWeightGroup).Bold(), new LabelView(this.View.CalculatorPaediatricArvDosageView.WeightGroup.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageDosage).Bold(), new LabelView(this.View.CalculatorPaediatricArvDosageView.WeightGroup.Dosage)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageTargetDose).Bold(), new LabelView(this.View.CalculatorPaediatricArvDosageView.Arv.TargetDose)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageAvailableFormulations).Bold(), new LabelView(this.View.CalculatorPaediatricArvDosageView.Arv.AvailableFormulations)));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorPaediatricArvDosageSource)._Disclaimer()));
            }
        }
    }
}