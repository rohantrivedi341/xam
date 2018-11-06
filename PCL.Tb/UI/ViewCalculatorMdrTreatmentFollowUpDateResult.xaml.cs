using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using PCL.Common;
using PCL.Tb.Common;
using PCL.Tb.Common.View;
using PCL.UI.Helpers;
using PCL.UI.Templates;
using PCL.UI.Templates.Views;
using Xamarin.Forms;
using Xfinium.Pdf;
using ContentPageBase = PCL.Tb.UI.Helpers.ContentPageBase;

namespace PCL.Tb.UI
{
    public partial class ViewCalculatorMdrTreatmentFollowUpDateResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorMdrTreatmentFollowUpDateView CalculatorMdrTreatmentFollowUpDateView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorMdrTreatmentFollowUpDateResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorMdrTreatmentFollowUpDateResult;

            ToolbarCommand.Share(this, this.Share);
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorMdrTreatmentFollowUpDateView))
            {
                this.View.CalculatorMdrTreatmentFollowUpDateView = (CalculatorMdrTreatmentFollowUpDateView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Category '{2}'", PCLResources.Calculators, TbResources.CalculatorMdrTreatmentFollowUpDate, this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate.ToString("dd-MM-yyyy")));

                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorMdrTreatmentFollowUpDateTreatmentDate).Bold(), new LabelView(this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate.ToString("dd-MM-yyyy"))));

                this.View.CalculatorMdrTreatmentFollowUpDateView.FollowUpDates = this.View.RepositoryCalculatorMdrTreatmentFollowUpDate.Get();

                foreach (CalculatorMdrTreatmentFollowUpDate calculatorTbTreatmentFollowUpDate in this.View.CalculatorMdrTreatmentFollowUpDateView.FollowUpDates)
                {
                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorMdrTreatmentFollowUpDateNextAppointmentOver).Bold(), new LabelView(calculatorTbTreatmentFollowUpDate.Title)));
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorMdrTreatmentFollowUpDateDate).Bold(), new LabelView(this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate.AddDays(calculatorTbTreatmentFollowUpDate.Days).ToString("dd-MM-yyyy"))));
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorMdrTreatmentFollowUpDateMessage).Bold(), new LabelView(calculatorTbTreatmentFollowUpDate.Message)));
                }

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorMdrTreatmentFollowUpDateSource)._Disclaimer()));
            }
        }
        private async void Share()
        {
            List<String> shareItems = new List<String>();
            shareItems.Add(PCLResources.Email);
            shareItems.Add(PCLResources.Print);

            String selectedShare = await this.DisplayActionSheet(PCLResources.Share, PCLResources.Cancel, null, shareItems.ToArray());

            if (selectedShare == null || selectedShare.Equals(PCLResources.Cancel))
            {
                return;
            }

            String fileName = DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".pdf";
            String sourceString = App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory() + "calculators/" + this.View.CalculatorMdrTreatmentFollowUpDateView.ItemCalculator.Pdf;
            String destinationString = App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory() + "calculators/" + fileName;

            using (Stream sourceStream = App.CurrentInstance.DependencyPlatformIO.FileRead(sourceString))
            {
                using (Stream destinationStream = App.CurrentInstance.DependencyPlatformIO.FileCreate(destinationString))
                {
                    PdfFixedDocument document = new PdfFixedDocument(sourceStream);

                    for (int i = 1; i < this.View.CalculatorMdrTreatmentFollowUpDateView.FollowUpDates.Count + 1; i++)
                    {
                        if (i > 7)
                            continue;

                        CalculatorMdrTreatmentFollowUpDate calculatorTbTreatmentFollowUpDate = this.View.CalculatorMdrTreatmentFollowUpDateView.FollowUpDates[i - 1];

                        document.Form.Fields["Date" + i + "Weeks"].Value = calculatorTbTreatmentFollowUpDate.Title;
                        document.Form.Fields["Date" + i + "Date"].Value = this.View.CalculatorMdrTreatmentFollowUpDateView.TreatmentDate.AddDays(calculatorTbTreatmentFollowUpDate.Days).ToString("dddd dd MMMM yyyy");
                        document.Form.Fields["Date" + i + "Message"].Value = calculatorTbTreatmentFollowUpDate.Message;
                    }

                    document.Form.FlattenFields();

                    document.Save(destinationStream);
                }
            }

            Attachment attachment = new Attachment(destinationString, "application/pdf", fileName);

            if (selectedShare.Equals(PCLResources.Email))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Email(TbResources.CalculatorMdrTreatmentFollowUpDateEmailAddress, TbResources.CalculatorMdrTreatmentFollowUpDateEmailSubject, TbResources.CalculatorMdrTreatmentFollowUpDateEmailBody, attachment);
            }
            else if (selectedShare.Equals(PCLResources.Print))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Print(attachment.FileName, attachment);
            }
        }
    }
}