using System;
using System.Collections.Generic;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Phc.UI.Helpers.ContentPageBase;

namespace PCL.Phc.UI
{
    public partial class ViewCalculatorIcd10CodesResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorIcd10View CalculatorWhoDiseasesView;

            public List<CalculatorIcd10CodesCode> CalculatorWhoDiseasesCodes;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorIcd10CodesResult()
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

            if (this.BindingContext.GetType() == typeof (CalculatorIcd10View))
            {
                this.View.CalculatorWhoDiseasesView = (CalculatorIcd10View) this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Chapter '{2}', Block '{3}', Code '{4}'", PCLResources.Calculators, PhcResources.CalculatorIcd10Codes, this.View.CalculatorWhoDiseasesView.Chapter.Title, this.View.CalculatorWhoDiseasesView.Block.Title, this.View.CalculatorWhoDiseasesView.Code.Title));

                this.View.CalculatorWhoDiseasesCodes = this.View.RepositoryCalculatorIcd10CodesCode.GetChildren(this.View.CalculatorWhoDiseasesView.Chapter.Number, this.View.CalculatorWhoDiseasesView.Block.Number, this.View.CalculatorWhoDiseasesView.Code.Code);

                foreach (CalculatorIcd10CodesCode calculatorWhoDiseasesCode in this.View.CalculatorWhoDiseasesCodes)
                {
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(calculatorWhoDiseasesCode.Code).Bold(), new LabelView(calculatorWhoDiseasesCode.Title)));
                }

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorIcd10CodesSource)._Disclaimer()));
            }
        }
    }
}