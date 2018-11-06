using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorAdultIsoniazidePreventiveTherapyResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorAdultIsoniazidePreventiveTherapyView CalculatorAdultIsoniazidePreventiveTherapyView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdultIsoniazidePreventiveTherapyResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorAdultIsoniazidePreventiveTherapyResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorAdultIsoniazidePreventiveTherapyView))
            {
                this.View.CalculatorAdultIsoniazidePreventiveTherapyView = (CalculatorAdultIsoniazidePreventiveTherapyView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Therapy '{2}'", PCLResources.Calculators, TbResources.CalculatorAdultIsoniazidePreventiveTherapy, this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy));
                
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapyArtTreatment).Bold(), new LabelView(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.ArtTreatment ? TbResources.CalculatorAdultIsoniazidePreventiveTherapyYes : TbResources.CalculatorAdultIsoniazidePreventiveTherapyNo)));
                
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapyTstAvailable).Bold(), new LabelView(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.TstAvailable ? TbResources.CalculatorAdultIsoniazidePreventiveTherapyYes : TbResources.CalculatorAdultIsoniazidePreventiveTherapyNo)));

                if (this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size != null)
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapySize).Bold(), new LabelView(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size.ToString())));
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapyManagement).Bold(), new LabelView(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Size.Management)));
                }
                else
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapyManagement).Bold(), new LabelView(this.View.CalculatorAdultIsoniazidePreventiveTherapyView.Therapy.Management)));
                }
                
                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorAdultIsoniazidePreventiveTherapySource)._Disclaimer()));
            }
        }
    }
}