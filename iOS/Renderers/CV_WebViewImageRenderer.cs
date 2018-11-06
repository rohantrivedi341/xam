using iOS.Renderers;
using PCL.UI.CustomViews;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof (CV_WebViewImage), typeof (CV_WebViewImageRenderer))]

namespace iOS.Renderers
{
    public class CV_WebViewImageRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            this.AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;
            this.ScalesPageToFit = true;
        }
    }
}