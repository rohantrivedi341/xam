using System;
using PCL.Phc.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorPaediatricDosageResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorPaediatricDosageView CalculatorPaediatricDosageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricDosageResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = PhcResources.CalculatorPaediatricDosageResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorPaediatricDosageView))
            {
                this.View.CalculatorPaediatricDosageView = (CalculatorPaediatricDosageView) this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Drug '{2}', Age Weight Group '{3}'", PCLResources.Calculators, PhcResources.CalculatorPaediatricDosages, this.View.CalculatorPaediatricDosageView.Drug, this.View.CalculatorPaediatricDosageView.AgeWeightGroup));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageMedicine).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.Drug.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageAgeWeightBand).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.AgeWeightGroup.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageIndications).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.Drug.Indications)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageFrequency).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.Drug.Frequency)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageStandardisedDosage).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.Drug.DosageFormula)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageDose).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.AgeWeightGroup.Dosage)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(PhcResources.CalculatorPaediatricDosageFormulationOptions).Bold(), new LabelView(this.View.CalculatorPaediatricDosageView.AgeWeightGroup.FormulationOptions)));
            }
        }
    }
}