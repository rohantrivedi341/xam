using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
    public partial class ViewCalculatorTbTreatmentFollowUpDateResult : Tb.UI.Helpers.ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private class ViewModel : ContentPageBase.ViewModel
        {
            public StackLayout StackLayout;

            public CalculatorTbTreatmentFollowUpDateView CalculatorTbTreatmentFollowUpDateView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewCalculatorTbTreatmentFollowUpDateResult()
        {
            this.InitializeComponent();

            this.View.StackLayout = this.stackLayout;

            this.Title = TbResources.CalculatorTbTreatmentFollowUpDateResult;

            ToolbarCommand.Share(this, this.Share);
            ToolbarCommand.Search(this);
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof(CalculatorTbTreatmentFollowUpDateView))
            {
                this.View.CalculatorTbTreatmentFollowUpDateView = (CalculatorTbTreatmentFollowUpDateView)this.BindingContext;

                App.CurrentInstance.DependencyPlatformGoogleAnalytics.LogScreen(String.Format("{0} - {1} - Category '{2}'", PCLResources.Calculators, TbResources.CalculatorTbTreatmentFollowUpDate, this.View.CalculatorTbTreatmentFollowUpDateView.TreatmentDate.ToString("dd-MM-yyyy")));

                this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorTbTreatmentFollowUpDateTreatmentDate).Bold(), new LabelView(this.View.CalculatorTbTreatmentFollowUpDateView.TreatmentDate.ToString("dd-MM-yyyy"))));

                this.View.CalculatorTbTreatmentFollowUpDateView.FollowUpDates = this.View.RepositoryCalculatorTbTreatmentFollowUpDate.Get();

                foreach (CalculatorTbTreatmentFollowUpDate calculatorTbTreatmentFollowUpDate in this.View.CalculatorTbTreatmentFollowUpDateView.FollowUpDates)
                {
                    this.View.StackLayout.Children.Add(TemplateLine.Create());

                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorTbTreatmentFollowUpDateNextAppointmentOver).Bold(), new LabelView(calculatorTbTreatmentFollowUpDate.Title)));
                    this.View.StackLayout.Children.Add(TemplateColumn2.Create(new LabelView(TbResources.CalculatorTbTreatmentFollowUpDateDate).Bold(), new LabelView(this.View.CalculatorTbTreatmentFollowUpDateView.TreatmentDate.AddDays(calculatorTbTreatmentFollowUpDate.Days).ToString("dd-MM-yyyy"))));
                    this.View.StackLayout.Children.Add(TemplateRow2.Create(new LabelView(TbResources.CalculatorTbTreatmentFollowUpDateMessage).Bold(), new LabelView(calculatorTbTreatmentFollowUpDate.Message)));
                }

                this.View.StackLayout.Children.Add(TemplateLine.Create());

                this.View.StackLayout.Children.Add(TemplateColumn1.Create(new LabelView(TbResources.CalculatorTbTreatmentFollowUpDateSource)._Disclaimer()));
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
            String sourceString = App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory() + "calculators/" + this.View.CalculatorTbTreatmentFollowUpDateView.ItemCalculator.Pdf;
            String destinationString = App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory() + "calculators/" + fileName;
            
            using (Stream sourceStream = App.CurrentInstance.DependencyPlatformIO.FileRead(sourceString))
            {
                using (Stream destinationStream = App.CurrentInstance.DependencyPlatformIO.FileCreate(destinationString))
                {
                    PdfFixedDocument document = new PdfFixedDocument(sourceStream);
                    
                    for (int i = 1; i < this.View.CalculatorTbTreatmentFollowUpDateView.FollowUpDates.Count + 1; i++)
                    {
                        if (i > 7)
                            continue;
                        
                        CalculatorTbTreatmentFollowUpDate calculatorTbTreatmentFollowUpDate = this.View.CalculatorTbTreatmentFollowUpDateView.FollowUpDates[i - 1];
                        
                        document.Form.Fields["Date" + i + "Weeks"].Value = calculatorTbTreatmentFollowUpDate.Title;
                        document.Form.Fields["Date" + i + "Date"].Value = this.View.CalculatorTbTreatmentFollowUpDateView.TreatmentDate.AddDays(calculatorTbTreatmentFollowUpDate.Days).ToString("dddd dd MMMM yyyy");
                        document.Form.Fields["Date" + i + "Message"].Value = calculatorTbTreatmentFollowUpDate.Message;
                    }
                    
                    document.Form.FlattenFields();

                    document.Save(destinationStream);
                }
            }

            Attachment attachment = new Attachment(destinationString, "application/pdf", fileName);

            if (selectedShare.Equals(PCLResources.Email))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Email(TbResources.CalculatorTbTreatmentFollowUpDateEmailAddress, TbResources.CalculatorTbTreatmentFollowUpDateEmailSubject, TbResources.CalculatorTbTreatmentFollowUpDateEmailBody, attachment);
            }
            else if (selectedShare.Equals(PCLResources.Print))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Print(attachment.FileName, attachment);
            }
        }
    }
}