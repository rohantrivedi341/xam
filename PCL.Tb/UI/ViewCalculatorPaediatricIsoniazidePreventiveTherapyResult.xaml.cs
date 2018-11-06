using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorPaediatricIsoniazidePreventiveTherapyResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorPaediatricIsoniazidePreventiveTherapyView CalculatorPaediatricIsoniazidePreventiveTherapyView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorPaediatricIsoniazidePreventiveTherapyResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorPaediatricIsoniazidePreventiveTherapyResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorPaediatricIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView = (CalculatorPaediatricIsoniazidePreventiveTherapyView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Therapy '{2}'", PCLResources.Calculators, TbResources.CalculatorPaediatricIsoniazidePreventiveTherapy, this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.Therapy));
                
                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricIsoniazidePreventiveTherapyTargetDose).Bold(), new LabelView(this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.Therapy.TargetDose)));
                
                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricIsoniazidePreventiveTherapyAvailableFormulations).Bold(), new LabelView(this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.Therapy.AvailableFormulations)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup).Bold(), new LabelView(this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.WeightGroup.ToString())));
                
                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorPaediatricIsoniazidePreventiveTherapyDosage).Bold(), new LabelView(this.View.CalculatorPaediatricIsoniazidePreventiveTherapyView.WeightGroup.Dosage)));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorPaediatricIsoniazidePreventiveTherapySource)._Disclaimer()));
            }
        }
    }
}