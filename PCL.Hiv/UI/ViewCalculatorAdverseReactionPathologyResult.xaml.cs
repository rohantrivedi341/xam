using System;
using System.Linq;
using PCL.Hiv.Common;
using PCL.Hiv.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorAdverseReactionPathologyResult : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorAdverseReactionPathologyView CalculatorAdverseReactionPathologyView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdverseReactionPathologyResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = HivResources.CalculatorAdverseReactionPathologyResult;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorAdverseReactionPathologyView))
            {
                this.View.CalculatorAdverseReactionPathologyView = (CalculatorAdverseReactionPathologyView) this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Date of Birth '{2}', Amount of Results '{3}'", PCLResources.Calculators, HivResources.CalculatorAdverseReactionPathology, this.View.CalculatorAdverseReactionPathologyView.DateOfBirth.ToString("dd-MM-yyyy"), this.View.CalculatorAdverseReactionPathologyView.Results));

                String topGradeText = HivResources.CalculatorAdverseReactionPathologyGradeNoAbnormalReactionResult;

                switch (this.View.CalculatorAdverseReactionPathologyView.Results.First().Grade)
                {
                    case CalculatorAdverseReactionPathologyGrade.Grade1:
                        topGradeText = HivResources.CalculatorAdverseReactionPathologyGrade1Result;
                        break;
                    case CalculatorAdverseReactionPathologyGrade.Grade2:
                        topGradeText = HivResources.CalculatorAdverseReactionPathologyGrade2Result;
                        break;
                    case CalculatorAdverseReactionPathologyGrade.Grade3:
                        topGradeText = HivResources.CalculatorAdverseReactionPathologyGrade3Result;
                        break;
                    case CalculatorAdverseReactionPathologyGrade.Grade4:
                        topGradeText = HivResources.CalculatorAdverseReactionPathologyGrade4Result;
                        break;
                    default:
                        break;
                }

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(topGradeText).Bold().XAlign(TextAlignment.Center)));

                foreach (CalculatorAdverseReactionPathologyResult tempResult in this.View.CalculatorAdverseReactionPathologyView.Results)
                {
                    CalculatorAdverseReactionPathologyResult result = tempResult;

                    StackLayout stackLayoutParameter = new StackLayout();
                    stackLayoutParameter.Padding = 10;

                    String resultGradeText = HivResources.CalculatorAdverseReactionPathologyGradeNoAbnormalReaction;
                    Color backgroundColor = Color.White;
                    Color textColor = Color.Black;

                    switch (result.Grade)
                    {
                        case CalculatorAdverseReactionPathologyGrade.Grade1:
                            resultGradeText = HivResources.CalculatorAdverseReactionPathologyGrade1;
                            backgroundColor = Color.Green;
                            textColor = Color.White;
                            break;
                        case CalculatorAdverseReactionPathologyGrade.Grade2:
                            resultGradeText = HivResources.CalculatorAdverseReactionPathologyGrade2;
                            backgroundColor = Color.Yellow;
                            textColor = Color.Black;
                            break;
                        case CalculatorAdverseReactionPathologyGrade.Grade3:
                            resultGradeText = HivResources.CalculatorAdverseReactionPathologyGrade3;
                            backgroundColor = Color.FromHex("FF6A00");
                            textColor = Color.White;
                            break;
                        case CalculatorAdverseReactionPathologyGrade.Grade4:
                            resultGradeText = HivResources.CalculatorAdverseReactionPathologyGrade4;
                            backgroundColor = Color.Red;
                            textColor = Color.White;
                            break;
                        default:
                            break;
                    }

                    stackLayoutParameter.BackgroundColor = backgroundColor;

                    String valueUnit = result.TestResult.ToString("#.##") + " " + result.Parameter.Unit;

                    stackLayoutParameter.Children.Add(TemplateColumn2.Create(new LabelView(result.Parameter.Title).TextColor(textColor).Bold(), new LabelView(valueUnit).TextColor(textColor).XAlign(TextAlignment.End), 0.6, 0.4));
                    stackLayoutParameter.Children.Add(TemplateColumn1.Create(new LabelView(resultGradeText).TextColor(textColor)));

                    String popupText = valueUnit;

                    if (result.SexUln > 1.0)
                    {
                        popupText += "\r\n\r\n";
                        popupText += String.Format("{0} x {1}", result.TestResultUln.ToString("#.##"), HivResources.CalculatorAdverseReactionPathologyUln);
                        popupText += "\r\n\r\n";
                        popupText += String.Format(HivResources.CalculatorAdverseReactionPathologyUlnUsedForCalculation, result.SexUln);
                    }

                    TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                    tapGestureRecognizer.Tapped += (sender, e) => this.DisplayAlert(result.Parameter.Title, popupText, PCLResources.OK);

                    stackLayoutParameter.GestureRecognizers.Add(tapGestureRecognizer);

                    this.View.StackLayout.Children.Add(stackLayoutParameter);
                }

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(HivResources.CalculatorAdverseReactionPathologyDisclaimer)._Disclaimer()));
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            this.DisplayAlert(PCLResources.ImportantInformation, HivResources.CalculatorAdverseReactionPathologyDisclaimerPopup, PCLResources.IUnderstand);
        }
    }
}