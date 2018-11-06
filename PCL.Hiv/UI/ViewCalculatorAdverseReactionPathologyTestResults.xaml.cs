using System;
using System.Collections.Generic;
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
    public partial class ViewCalculatorAdverseReactionPathologyTestResults : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public Button CalculateButton;

            public readonly List<CalculatorAdverseReactionPathologyInput> TestResultLabelEntries = new List<CalculatorAdverseReactionPathologyInput>();

            public List<CalculatorAdverseReactionPathologyParameter> CalculatorAdverseReactionPathologyParameters;

            public CalculatorAdverseReactionPathologyView CalculatorAdverseReactionPathologyView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdverseReactionPathologyTestResults()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;
            this.View.CalculateButton = this.calculateButton;

            this.Title = HivResources.CalculatorAdverseReactionPathologyTestResults;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorAdverseReactionPathologyView))
            {
                this.View.CalculatorAdverseReactionPathologyView = (CalculatorAdverseReactionPathologyView) this.BindingContext;
                this.View.CalculatorAdverseReactionPathologyView.Results = null;

                this.View.CalculatorAdverseReactionPathologyParameters = this.View.RepositoryCalculatorAdverseReactionPathologyParameter.Get();

                foreach (CalculatorAdverseReactionPathologyParameter calculatorAdverseReactionPathologyParameter in this.View.CalculatorAdverseReactionPathologyParameters)
                {
                    TemplateColumn2 row = TemplateColumn2.Create(new LabelView(calculatorAdverseReactionPathologyParameter.Title).Bold(), new EntryView(String.Empty, Keyboard.Numeric, calculatorAdverseReactionPathologyParameter.Unit), 0.6, 0.4);

                    this.View.TestResultLabelEntries.Add(new CalculatorAdverseReactionPathologyInput(calculatorAdverseReactionPathologyParameter, row.Second.AsEntry()));

                    this.View.StackLayout.Children.Add(row);
                }

                this.View.CalculateButton.Text = HivResources.CalculatorAdverseReactionPathologyCalculate;
                this.View.CalculateButton.Clicked += this.OnCalculateButtonClicked;
            }
        }

        private void OnCalculateButtonClicked(object sender, EventArgs e)
        {
            this.View.CalculatorAdverseReactionPathologyView.Results = new List<CalculatorAdverseReactionPathologyResult>();

            foreach (CalculatorAdverseReactionPathologyInput input in this.View.TestResultLabelEntries)
            {
                if (String.IsNullOrWhiteSpace(input.Entry.Text))
                {
                    continue;
                }

                Double testResult;

                if (!Double.TryParse(input.Entry.Text.Replace(",", "."), out testResult))
                {
                    this.DisplayAlert(input.Parameter.Title, HivResources.CalculatorAdverseReactionPathologyTestResultValidationParsing, PCLResources.OK);

                    return;
                }

                CalculatorAdverseReactionPathologyAgeCategory ageCategory = this.View.RepositoryCalculatorAdverseReactionPathologyAgeCategory.GetByCalculatorAdverseReactionPathologyParameterAndDaysBorn(input.Parameter.Id, this.View.CalculatorAdverseReactionPathologyView.DaysBorn);

                Double sexUln = 0.0;

                switch (this.View.CalculatorAdverseReactionPathologyView.Sex.Type)
                {
                    case CalculatorAdverseReactionPathologySexType.Male:
                        sexUln = ageCategory.UlnMale;
                        break;
                    case CalculatorAdverseReactionPathologySexType.Female:
                        sexUln = ageCategory.UlnFemale;
                        break;
                }

                Double testResultUln = testResult/sexUln;

                CalculatorAdverseReactionPathologyGrade grade = CalculatorAdverseReactionPathologyGrade.GradeNoAbnormalReaction;

                if (ageCategory.Grade4 >= ageCategory.GradeNoAbnormalReaction)
                {
                    if (testResultUln >= ageCategory.Grade4)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade4;
                    }
                    else if (testResultUln >= ageCategory.Grade3)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade3;
                    }
                    else if (testResultUln >= ageCategory.Grade2)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade2;
                    }
                    else if (testResultUln >= ageCategory.Grade1)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade1;
                    }
                    else if (testResultUln >= ageCategory.GradeNoAbnormalReaction)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.GradeNoAbnormalReaction;
                    }
                }
                else
                {
                    if (testResultUln >= ageCategory.GradeNoAbnormalReaction)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.GradeNoAbnormalReaction;
                    }
                    else if (testResultUln >= ageCategory.Grade1)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade1;
                    }
                    else if (testResultUln >= ageCategory.Grade2)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade2;
                    }
                    else if (testResultUln >= ageCategory.Grade3)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade3;
                    }
                    else if (testResultUln >= ageCategory.Grade4)
                    {
                        grade = CalculatorAdverseReactionPathologyGrade.Grade4;
                    }
                }

                this.View.CalculatorAdverseReactionPathologyView.Results.Add(new CalculatorAdverseReactionPathologyResult()
                {
                    Parameter = input.Parameter,
                    AgeCategory = ageCategory,
                    SexUln = sexUln,
                    TestResult = testResult,
                    TestResultUln = testResultUln,
                    Grade = grade
                });
            }

            this.View.CalculatorAdverseReactionPathologyView.Results = this.View.CalculatorAdverseReactionPathologyView.Results.OrderByDescending(x => x.Grade).ThenBy(x => x.Parameter.Title).ToList();

            if (!this.View.CalculatorAdverseReactionPathologyView.Results.Any())
            {
                this.DisplayAlert(PCLResources.ValidationRequired, PCLResources.ValidationAtLeastOneResultRequired, PCLResources.OK);

                return;
            }

            this.Navigation.PushAsync(new ViewCalculatorAdverseReactionPathologyResult()
            {
                BindingContext = this.View.CalculatorAdverseReactionPathologyView
            }, true);
        }
    }
}