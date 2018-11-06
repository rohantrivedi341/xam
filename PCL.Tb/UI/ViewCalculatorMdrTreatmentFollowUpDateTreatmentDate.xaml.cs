using System;
using System.Globalization;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorMdrTreatmentFollowUpDateTreatmentDate : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public TemplateColumn3 DateRow;
            public TemplateColumn1 ButtonTodayRow;
            public TemplateColumn1 ButtonNextRow;

            public CalculatorMdrTreatmentFollowUpDateView CalculatorMdrTreatmentFollowUpDateView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorMdrTreatmentFollowUpDateTreatmentDate()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorMdrTreatmentFollowUpDateSelectTreatmentDate;

            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (CalculatorMdrTreatmentFollowUpDateView))
            {
                this.View.CalculatorMdrTreatmentFollowUpDateView = (CalculatorMdrTreatmentFollowUpDateView) this.BindingContext;
                this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate = DateTime.Now;

                this.View.StackLayout.Children.Add(TemplateSpace.Create());

                this.View.DateRow = TemplateColumn3.Create(new EntryView(String.Empty, Keyboard.Numeric, "day"), new EntryView(String.Empty, Keyboard.Numeric, "month"), new EntryView(String.Empty, Keyboard.Numeric, "year"), spacing: 10);
                this.View.StackLayout.Children.Add(this.View.DateRow);

                this.View.ButtonTodayRow = TemplateColumn1.Create(new ButtonView(TbResources.CalculatorMdrTreatmentFollowUpDateToday, this.OnButtonTodayClicked));
                this.View.StackLayout.Children.Add(this.View.ButtonTodayRow);

                this.View.ButtonNextRow = TemplateColumn1.Create(new ButtonView(PCLResources.Next, this.OnButtonNextClicked));
                this.View.StackLayout.Children.Add(this.View.ButtonNextRow);
            }
        }

        private void OnButtonTodayClicked(object sender, EventArgs e)
        {
            DateTime dateTimeNow = DateTime.Now;

            ((EntryView) this.View.DateRow.First).Text = dateTimeNow.Day.ToString();
            ((EntryView)this.View.DateRow.Second).Text = dateTimeNow.Month.ToString();
            ((EntryView)this.View.DateRow.Third).Text = dateTimeNow.Year.ToString();
            
            this.OnButtonNextClicked(null, null);
        }

        private void OnButtonNextClicked(object sender, EventArgs e)
        {
            String day = ((EntryView) this.View.DateRow.First).Text;
            String month = ((EntryView) this.View.DateRow.Second).Text;
            String year = ((EntryView) this.View.DateRow.Third).Text;

            if (String.IsNullOrWhiteSpace(day) || String.IsNullOrWhiteSpace(month) || String.IsNullOrWhiteSpace(year))
            {
                this.DisplayAlert(PCLResources.ValidationRequired, TbResources.CalculatorMdrTreatmentFollowUpDateTreatmentDateValidationRequired, PCLResources.OK);

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
                this.DisplayAlert(PCLResources.ValidationParsing, TbResources.CalculatorMdrTreatmentFollowUpDateTreatmentDateValidationParsing, PCLResources.OK);

                return;
            }

            this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate = tempDateTime;
            
            this.Navigation.PushAsync(new ViewCalculatorMdrTreatmentFollowUpDateResult()
            {
                BindingContext = this.View.CalculatorMdrTreatmentFollowUpDateView
            }, true);
        }
    }
}