using System;
using System.Collections.Generic;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using PCL.UI.Templates.Views.Enum;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorMedicineCostingResults : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorMedicineCostingView CalculatorMedicineCostingView;

            public List<CalculatorMedicineCostingDescription> CalculatorMedicineCostingDescriptions;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorMedicineCostingResults()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = PhcResources.CalculatorMedicineCostingResults;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorMedicineCostingView))
            {
                this.View.CalculatorMedicineCostingView = (CalculatorMedicineCostingView) this.BindingContext;

                this.View.CalculatorMedicineCostingDescriptions = this.View.RepositoryCalculatorMedicineCostingDescription.GetByCalculatorMedicineCostingGeneric(this.View.CalculatorMedicineCostingView.Generic.Id);

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Generic '{2}'", PCLResources.Calculators, PhcResources.CalculatorMedicineCosting, this.View.CalculatorMedicineCostingView.Generic.Title));

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(this.View.CalculatorMedicineCostingView.Generic.ToString(), LabelDisplayType.Big).Bold()));

                foreach (CalculatorMedicineCostingDescription calculatorMedicineCostingDescription in this.View.CalculatorMedicineCostingDescriptions)
                {
                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorMedicineCostingDescription).Bold(), new LabelView(calculatorMedicineCostingDescription.Title).TextColor(Color.Gray), 0.3, 0.7));
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorMedicineCostingBrand).Bold(), new LabelView(calculatorMedicineCostingDescription.Brand).TextColor(Color.Gray), 0.3, 0.7));
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorMedicineCostingPrice).Bold(), new LabelView(calculatorMedicineCostingDescription.Price).TextColor(Color.Gray), 0.3, 0.7));
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorMedicineCostingContractNumber).Bold(), new LabelView(calculatorMedicineCostingDescription.ContractNumber).TextColor(Color.Gray), 0.3, 0.7));
                }
            }
        }
    }
}