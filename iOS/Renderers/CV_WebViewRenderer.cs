using System;
using Foundation;
using iOS.Renderers;
using PCL.UI.CustomViews;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof (CV_WebView), typeof (CV_WebViewRenderer))]

namespace iOS.Renderers
{
    public class CV_WebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            ((CV_WebView) this.Element).PlatformControl = this.NativeView;
        }

        public override void LoadHtmlString(String content, NSUrl baseUrl)
        {
            baseUrl = new NSUrl(((CV_WebView) this.Element).Url);

            base.LoadHtmlString(content, baseUrl);
        }
    }
}