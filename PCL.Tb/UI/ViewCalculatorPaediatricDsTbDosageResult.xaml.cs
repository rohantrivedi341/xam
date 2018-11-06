using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorPaediatricDsTbDosageResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorPaediatricDsTbDosageView CalculatorPaediatricDsTbDosageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricDsTbDosageResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorPaediatricDsTbDosageResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorPaediatricDsTbDosageView))
            {
                this.View.CalculatorPaediatricDsTbDosageView = (CalculatorPaediatricDsTbDosageView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Category '{2}'", PCLResources.Calculators, TbResources.CalculatorPaediatricDsTbDosages, this.View.CalculatorPaediatricDsTbDosageView.Category));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageCategory).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.Category.ToString())));

                if (this.View.CalculatorPaediatricDsTbDosageView.Phase == null)
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageAvailableFormulations).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.Category.AvailableFormulations)));
                }
                else
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosagePhase).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.Phase.ToString())));

                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageAvailableFormulations).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.Phase.AvailableFormulations)));
                }

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageWeightGroup).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.WeightGroup.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageDosage).Bold(), new LabelView(this.View.CalculatorPaediatricDsTbDosageView.WeightGroup.Dosage)));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorPaediatricDsTbDosageSource)._Disclaimer()));
            }
        }
    }
}