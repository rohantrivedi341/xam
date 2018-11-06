using System;
using System.Collections.Generic;
using System.Linq;
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
    public partial class ViewCalculatorCardiovascularRiskResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorCardiovascularRiskView CalculatorCardiovascularRiskView;

            public List<CalculatorCardiovascularRiskResult> CalculatorCardiovascularRiskResults;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorCardiovascularRiskResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = PhcResources.CalculatorCardiovascularRiskResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorCardiovascularRiskView))
            {
                this.View.CalculatorCardiovascularRiskView = (CalculatorCardiovascularRiskView) this.BindingContext;

                Int32 score = 0;

                switch (this.View.CalculatorCardiovascularRiskView.Sex.Type)
                {
                    case CalculatorCardiovascularRiskSexType.Male:
                        score += this.View.CalculatorCardiovascularRiskView.Age.Male;
                        score += this.View.CalculatorCardiovascularRiskView.TotalCholesterol.Male;
                        score += this.View.CalculatorCardiovascularRiskView.HdlCholesterol.Male;
                        score += this.View.CalculatorCardiovascularRiskView.Smoker.Male;
                        score += this.View.CalculatorCardiovascularRiskView.Diabetic.Male;
                        score += this.View.CalculatorCardiovascularRiskView.SystolicBp.Male;

                        break;
                    case CalculatorCardiovascularRiskSexType.Female:
                        score += this.View.CalculatorCardiovascularRiskView.Age.Female;
                        score += this.View.CalculatorCardiovascularRiskView.TotalCholesterol.Female;
                        score += this.View.CalculatorCardiovascularRiskView.HdlCholesterol.Female;
                        score += this.View.CalculatorCardiovascularRiskView.Smoker.Female;
                        score += this.View.CalculatorCardiovascularRiskView.Diabetic.Female;
                        score += this.View.CalculatorCardiovascularRiskView.SystolicBp.Female;

                        break;
                }

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Sex '{2}', Score '{3}'", PCLResources.Calculators, PhcResources.CalculatorCardiovascularRisk, this.View.CalculatorCardiovascularRiskView.Sex, score));

                this.View.CalculatorCardiovascularRiskResults = this.View.RepositoryCalculatorCardiovascularRiskResult.Get(this.View.CalculatorCardiovascularRiskView.Sex.Type).ToList();

                CalculatorCardiovascularRiskResult calculatorCardiovascularRiskResult = this.View.CalculatorCardiovascularRiskResults.Where(x => score.Equals(x.Points)).SingleOrDefault();

                if (calculatorCardiovascularRiskResult == null)
                {
                    if (score < this.View.CalculatorCardiovascularRiskResults.First().Points)
                    {
                        calculatorCardiovascularRiskResult = this.View.CalculatorCardiovascularRiskResults.First();
                    }
                    else
                    {
                        calculatorCardiovascularRiskResult = this.View.CalculatorCardiovascularRiskResults.Last();
                    }
                }

                Boolean highRisk = calculatorCardiovascularRiskResult.RiskValue > 20.0;

                StackLayout stackLayoutTop = new StackLayout();
                stackLayoutTop.Padding = 10;
                stackLayoutTop.BackgroundColor = !highRisk ? Color.White : Color.FromHex("FF6A00");

                Color textColor = !highRisk ? Color.Black : Color.White;

                stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(calculatorCardiovascularRiskResult.RiskText).TextColor(textColor).Font(LabelDisplayType.Biggest).Bold().XAlign(TextAlignment.Center)));

                stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(String.Format(PhcResources.CalculatorCardiovascularRiskResultPercentageCharacteristics, calculatorCardiovascularRiskResult.RiskValue)).TextColor(textColor).XAlign(TextAlignment.Center)));

                if (highRisk)
                {
                    stackLayoutTop.Children.Add(TemplateColumn1.Create(new LabelView(String.Format(PhcResources.CalculatorCardiovascularRiskResultHighRiskPatients, calculatorCardiovascularRiskResult.RiskValue)).TextColor(textColor).XAlign(TextAlignment.Center)));
                }

                this.View.StackLayout.Children.Add(stackLayoutTop);

                if (!highRisk)
                {
                    this.View.StackLayout.Children.Add(TemplateLine.Create());
                }

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                if (this.View.CalculatorCardiovascularRiskView.Diabetic.Id == 1 && this.View.CalculatorCardiovascularRiskView.Age.Id >= 3)
                {
                    this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskResultOlderThan40AndDiabetic).XAlign(TextAlignment.Center)));

                    this.View.StackLayout.Children.Add(TemplateSpace.Create());

                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateSpace.Create());
                }

                if (this.View.CalculatorCardiovascularRiskView.TotalCholesterol.Id == 5)
                {
                    this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskResultCholesterolReferral).XAlign(TextAlignment.Center)));

                    this.View.StackLayout.Children.Add(TemplateSpace.Create());

                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateSpace.Create());
                }

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskCharacteristics).Font(LabelDisplayType.Big).Bold()));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskSex).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.Sex.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskAge).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.Age.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskTotalCholesterol).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.TotalCholesterol.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskHdlCholesterol).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.HdlCholesterol.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskSmoker).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.Smoker.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskDiabetic).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.Diabetic.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskBpTreatment).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.BpTreatment.Title)));
                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskSystolicBp).Bold(), new LabelView(this.View.CalculatorCardiovascularRiskView.SystolicBp.Title)));

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(String.Format(PhcResources.CalculatorCardiovascularRiskResultMessage, calculatorCardiovascularRiskResult.RiskValue)).XAlign(TextAlignment.Center)));

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(String.Format(PhcResources.CalculatorCardiovascularRiskResultLevelOfEvidence, calculatorCardiovascularRiskResult.RiskValue)).XAlign(TextAlignment.Center).Bold()));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskSource)._Disclaimer()));

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskReference1)._Disclaimer()));

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskReference2)._Disclaimer()));

                this.View.StackLayout.Children.Add(TemplateSpace.Create());
                
                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(PhcResources.CalculatorCardiovascularRiskReference3)._Disclaimer()));
            }
        }
    }
}