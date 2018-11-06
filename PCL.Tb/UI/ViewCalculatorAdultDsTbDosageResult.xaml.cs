using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorAdultDsTbDosageResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorAdultDsTbDosageView CalculatorAdultDsTbDosageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultDsTbDosageResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorAdultDsTbDosageResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultDsTbDosageView))
            {
                this.View.CalculatorAdultDsTbDosageView = (CalculatorAdultDsTbDosageView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Phase '{2}'", PCLResources.Calculators, TbResources.CalculatorAdultDsTbDosages, this.View.CalculatorAdultDsTbDosageView.Phase));
                
                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosagePhase).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.Phase.ToString())));
                
                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageDrug).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.Drug.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageTargetDose).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.Drug.TargetDose)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageAvailableFormulations).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.Drug.AvailableFormulations)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageWeightGroup).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.WeightGroup.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageDosage).Bold(), new LabelView(this.View.CalculatorAdultDsTbDosageView.WeightGroup.Dosage)));
                
                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorAdultDsTbDosageSource)._Disclaimer()));
            }
        }
    }
}