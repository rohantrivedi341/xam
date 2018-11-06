using System;
using System.IO;
using Android.Content;
using Android.OS;
using Android.Print;
using Android.Print.Pdf;
using Android.Runtime;
using Droid.DependencyServices;
using Java.IO;
using PCL.Common;
using PCL.DependencyServices;
using PCL.UI.CustomViews;
using Xamarin.Forms;
using File = Java.IO.File;
using Uri = Android.Net.Uri;

[assembly: Dependency(typeof(DependencyPlatform_Droid_OpenExternal))]

namespace Droid.DependencyServices
{
    public class DependencyPlatform_Droid_OpenExternal : IDependencyPlatformOpenExternal
    {
        public Boolean Browser(String websiteUrl)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse(websiteUrl));

            Forms.Context.StartActivity(intent);

            return true;
        }

        public Boolean Email(String emailAddress = null, String subject = null, String body = null, Attachment attachment = null)
        {
            Intent intent = new Intent(Intent.ActionSendto);

            if (!String.IsNullOrWhiteSpace(emailAddress))
                intent.SetData(Uri.Parse("mailto:" + emailAddress));

            if (!String.IsNullOrWhiteSpace(subject))
                intent.PutExtra(Intent.ExtraSubject, subject);

            if (!String.IsNullOrWhiteSpace(body))
                intent.PutExtra(Intent.ExtraText, body);

            if (attachment != null)
                intent.PutExtra(Intent.ExtraStream, Uri.FromFile(new File(attachment.Path)));

            Forms.Context.StartActivity(intent);

            return true;
        }

        public Boolean Phone(String phoneNumber)
        {
            Intent intent = new Intent(Intent.ActionView);
            intent.SetData(Android.Net.Uri.Parse("tel:" + phoneNumber));

            Forms.Context.StartActivity(intent);

            return true;
        }

        public Boolean Print(String name, CV_WebView webView)
        {
            try
            {
                PrintManager printManager = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);

                Android.Webkit.WebView platformWebView = (Android.Webkit.WebView)webView.PlatformControl;

                printManager.Print(name, platformWebView.CreatePrintDocumentAdapter(name), null);

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Boolean Print(String name, Attachment attachment)
        {
            try
            {
                PrintManager printManager = (PrintManager)Forms.Context.GetSystemService(Context.PrintService);
                
                printManager.Print(name, new PdfPrintAdapter(attachment), null);
                
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private class PdfPrintAdapter : PrintDocumentAdapter
        {
            public Attachment Attachment;

            public PdfPrintAdapter(Attachment attachment)
            {
                this.Attachment = attachment;
            }
            
            public override void OnLayout(PrintAttributes oldAttributes, PrintAttributes newAttributes, CancellationSignal cancellationSignal, LayoutResultCallback callback, Bundle extras)
            {
                callback.OnLayoutFinished(new PrintDocumentInfo.Builder(this.Attachment.FileName).SetContentType(PrintContentType.Document).SetPageCount(1).Build(), true);
            }

            public override void OnWrite(PageRange[] pages, ParcelFileDescriptor destination, CancellationSignal cancellationSignal, WriteResultCallback callback)
            {
                OutputStreamInvoker outputStreamInvoker = new OutputStreamInvoker(new FileOutputStream(destination.FileDescriptor));

                FileInputStream fileInputStream = new FileInputStream(this.Attachment.Path);

                Byte[] buffer = new Byte[256];
                
                Int32 currentReadLength;

                while ((currentReadLength = fileInputStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    outputStreamInvoker.Write(buffer, 0, currentReadLength);
                }
                
                callback.OnWriteFinished(pages);
            }
        }
    }
}