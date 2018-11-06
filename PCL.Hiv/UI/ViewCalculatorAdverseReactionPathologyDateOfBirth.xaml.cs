using System;
using System.Globalization;
using PCL.Hiv.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Hiv.UI.Helpers.ContentPageBase;

namespace PCL.Hiv.UI
{
    public partial class ViewCalculatorAdverseReactionPathologyDateOfBirth : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public TemplateColumn3 DateRow;
            public TemplateColumn1 ButtonNextRow;

            public CalculatorAdverseReactionPathologyView CalculatorAdverseReactionPathologyView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorAdverseReactionPathologyDateOfBirth()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = HivResources.CalculatorAdverseReactionPathologySelectDateOfBirth;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorAdverseReactionPathologyView))
            {
                this.View.CalculatorAdverseReactionPathologyView = (CalculatorAdverseReactionPathologyView) this.BindingContext;
                this.View.CalculatorAdverseReactionPathologyView.DateOfBirth = DateTime.Now;
                this.View.CalculatorAdverseReactionPathologyView.DaysBorn = (Int32) Math.Abs(Math.Round(DateTime.Now.Subtract(this.View.CalculatorAdverseReactionPathologyView.DateOfBirth).TotalDays));
                this.View.CalculatorAdverseReactionPathologyView.Sex = null;
                this.View.CalculatorAdverseReactionPathologyView.Results = null;

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.DateRow = TemplateColumn3.Create(new EntryView(String.Empty, Keyboard.Numeric, "day"), new EntryView(String.Empty, Keyboard.Numeric, "month"), new EntryView(String.Empty, Keyboard.Numeric, "year"), spacing: 10);
                this.View.StackLayout.Children.Add(this.View.DateRow);

                this.View.ButtonNextRow = TemplateColumn1.Create(new ButtonView(PCLResources.Next, this.OnButtonNextClicked));
                this.View.StackLayout.Children.Add(this.View.ButtonNextRow);
            }
        }

        private void OnButtonNextClicked(object sender, EventArgs e)
        {
            String day = ((EntryView) this.View.DateRow.First).Text;
            String month = ((EntryView) this.View.DateRow.Second).Text;
            String year = ((EntryView) this.View.DateRow.Third).Text;

            if (String.IsNullOrWhiteSpace(day) || String.IsNullOrWhiteSpace(month) || String.IsNullOrWhiteSpace(year))
            {
                this.DisplayAlert(PCLResources.ValidationRequired, HivResources.CalculatorAdverseReactionPathologyDateOfBirthValidationRequired, PCLResources.OK);

                return;
            }

            if (day.Length == 1)
            {
                day = "0" + day;
            }
            if (month.Length == 1)
            {
                month = "0" + month;
            }

            DateTime tempDateTime;

            if (!DateTime.TryParseExact(day + month + year, new[]
            {
                "ddMMyyyy"
            }, CultureInfo.InvariantCulture, DateTimeStyles.None, out tempDateTime))
            {
                this.DisplayAlert(PCLResources.ValidationParsing, HivResources.CalculatorAdverseReactionPathologyDateOfBirthValidationParsing, PCLResources.OK);

                return;
            }

            this.View.CalculatorAdverseReactionPathologyView.DateOfBirth = tempDateTime;
            this.View.CalculatorAdverseReactionPathologyView.DaysBorn = (Int32) Math.Abs(Math.Round(DateTime.Now.Subtract(this.View.CalculatorAdverseReactionPathologyView.DateOfBirth).TotalDays));

            this.Navigation.PushAsync(new ViewCalculatorAdverseReactionPathologySex()
            {
                BindingContext = this.View.CalculatorAdverseReactionPathologyView
            }, true);
        }
    }
}