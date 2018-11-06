using System;
using System.Collections.Generic;
using PCL.Tb.Common;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using PCL.UI.Templates.Views.Enum;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorBmiResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorBmiView CalculatorBmiView;

            public List<CalculatorBmi> CalculatorBmis;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorBmiResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorBmiResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorBmiView))
            {
                this.View.CalculatorBmiView = (CalculatorBmiView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Result '{2}'", PCLResources.Calculators, TbResources.CalculatorBmi, this.View.CalculatorBmiView.Result.ToString()));

                this.View.CalculatorBmis = this.View.RepositoryCalculatorBmi.Get();

                this.View.CalculatorBmiView.Bmi = this.View.RepositoryCalculatorBmi.GetByResult(this.View.CalculatorBmiView.Result);

                StackLayout stackLayoutTop = new StackLayout();
                stackLayoutTop.Padding = 10;
                stackLayoutTop.BackgroundColor = Color.FromHex(this.View.CalculatorBmiView.Bmi.Color);

                Color textColor = Color.White;

                stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(this.View.CalculatorBmiView.Bmi.Title).TextColor(textColor).XAlign(TextAlignment.Center)));

                stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(this.View.CalculatorBmiView.Result.ToString()).TextColor(textColor).Font(LabelDisplayType.Biggest).Bold().XAlign(TextAlignment.Center)));

                if (!String.IsNullOrWhiteSpace(this.View.CalculatorBmiView.Bmi.Message))
                {
                    stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(this.View.CalculatorBmiView.Bmi.Message).TextColor(textColor).XAlign(TextAlignment.Center)));
                }

                this.View.StackLayout.Children.Add(stackLayoutTop);

                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorBmiMass).Bold(), new LabelView($"{this.View.CalculatorBmiView.Mass} {TbResources.CalculatorBmiMassUnit}")));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorBmiLength).Bold(), new LabelView($"{(Int32)(this.View.CalculatorBmiView.Length * 100)} {TbResources.CalculatorBmiLengthUnit}")));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                foreach (CalculatorBmi calculatorBmi in this.View.CalculatorBmis)
                {
                    String range = calculatorBmi.ValueStart + " - " + calculatorBmi.ValueEnd;

                    if (calculatorBmi.ValueStart == null)
                    {
                        range = "< " + calculatorBmi.ValueEnd;
                    }
                    else if (calculatorBmi.ValueEnd == null)
                    {
                        range = "> " + calculatorBmi.ValueStart;
                    }

                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(calculatorBmi.Title).Bold(), new LabelView(range)));
                }

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorBmiFormula)._Disclaimer()));
            }
        }
    }
}