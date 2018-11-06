using System;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorDrugInteractionInteraction : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorDrugInteractionView CalculatorDrugInteractionView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorDrugInteractionInteraction()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorDrugInteractionResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorDrugInteractionView))
            {
                this.View.CalculatorDrugInteractionView = (CalculatorDrugInteractionView) this.BindingContext;
                this.View.CalculatorDrugInteractionView.Interaction = null;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - EDL '{2}', ARV '{3}'", PCLResources.Calculators, TbResources.CalculatorDrugInteraction, this.View.CalculatorDrugInteractionView.Edl, this.View.CalculatorDrugInteractionView.Arv));

                this.View.CalculatorDrugInteractionView.Interaction = this.View.RepositoryCalculatorDrugInteractionInteraction.Get(this.View.CalculatorDrugInteractionView.Edl.Id, this.View.CalculatorDrugInteractionView.Arv.Id);

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorDrugInteractionEdl).Bold(), new LabelView(this.View.CalculatorDrugInteractionView.Edl.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorDrugInteractionArv).Bold(), new LabelView(this.View.CalculatorDrugInteractionView.Arv.ToString())));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorDrugInteractionInteractions).Bold(), new LabelView(this.View.CalculatorDrugInteractionView.Interaction != null ? this.View.CalculatorDrugInteractionView.Interaction.Interaction : TbResources.CalculatorDrugInteractionInteractionsDefaultText)));

                this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorDrugInteractionManagement).Bold(), new LabelView(this.View.CalculatorDrugInteractionView.Interaction != null ? this.View.CalculatorDrugInteractionView.Interaction.Management : TbResources.CalculatorDrugInteractionManagementDefaultText)));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorDrugInteractionDisclaimer)._Disclaimer()));
            }
        }
    }
}