using System;
using CoreGraphics;
using Foundation;
using iOS.DependencyServices;
using MessageUI;
using PCL.Common;
using PCL.DependencyServices;
using PCL.UI.CustomViews;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DependencyPlatform_iOS_OpenExternal))]

namespace iOS.DependencyServices
{
    public class DependencyPlatform_iOS_OpenExternal : IDependencyPlatformOpenExternal
    {
        public Boolean Browser(String websiteUrl)
        {
            UIApplication.SharedApplication.OpenUrl(NSUrl.FromString(websiteUrl));

            return true;
        }

        public Boolean Email(String emailAddress = null, String subject = null, String body = null, Attachment attachment = null)
        {
            if (!MFMailComposeViewController.CanSendMail)
                return false;

            MFMailComposeViewController mailComposer = new MFMailComposeViewController();

            if (!String.IsNullOrWhiteSpace(emailAddress))
                mailComposer.SetToRecipients(new String[]
                {
                    emailAddress
                });

            if (!String.IsNullOrWhiteSpace(subject))
                mailComposer.SetSubject(subject);

            if (!String.IsNullOrWhiteSpace(body))
                mailComposer.SetMessageBody(body, true);

            if (attachment != null)
                mailComposer.AddAttachmentData(NSData.FromFile(attachment.Path), attachment.Extension, attachment.FileName);
            
            mailComposer.Finished += (sender, e) => UIApplication.SharedApplication.KeyWindow.RootViewController.DismissViewController(true, null);

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(mailComposer, true, null);

            return true;
        }

        public Boolean Phone(String phoneNumber)
        {
            NSUrl url = NSUrl.FromString("telprompt:" + Uri.EscapeDataString(phoneNumber.Replace(" ", "")));

            if (!UIApplication.SharedApplication.CanOpenUrl(url))
                return false;

            UIApplication.SharedApplication.OpenUrl(url);

            return true;
        }

        public Boolean Print(String name, CV_WebView webView)
        {
            try
            {
                UIWebView platformWebView = (UIWebView)webView.PlatformControl;

                UIPrintInteractionController printer = UIPrintInteractionController.SharedPrintController;

                printer.ShowsPageRange = true;

                printer.PrintInfo = UIPrintInfo.PrintInfo;
                printer.PrintInfo.OutputType = UIPrintInfoOutputType.General;
                printer.PrintInfo.JobName = name;

                printer.PrintPageRenderer = new UIPrintPageRenderer()
                {
                    HeaderHeight = 40,
                    FooterHeight = 40
                };
                printer.PrintPageRenderer.AddPrintFormatter(platformWebView.ViewPrintFormatter, 0);

                if (Device.Idiom == TargetIdiom.Phone)
                {
                    printer.PresentAsync(true);
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    printer.PresentFromRectInViewAsync(new CGRect(200, 200, 0, 0), platformWebView, true);
                }

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
                UIPrintInteractionController printer = UIPrintInteractionController.SharedPrintController;

                printer.ShowsPageRange = true;

                printer.PrintInfo = UIPrintInfo.PrintInfo;
                printer.PrintInfo.OutputType = UIPrintInfoOutputType.General;
                printer.PrintInfo.JobName = name;

                printer.PrintingItem = NSData.FromFile(attachment.Path);
                
                if (Device.Idiom == TargetIdiom.Phone)
                {
                    printer.PresentAsync(true);
                }
                else if (Device.Idiom == TargetIdiom.Tablet)
                {
                    printer.PresentFromRectInViewAsync(new CGRect(200, 200, 0, 0), null, true);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }

}