using Droid.Renderers;
using PCL.UI.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (CV_WebViewImage), typeof (CV_WebViewImageRenderer))]

namespace Droid.Renderers
{
    public class CV_WebViewImageRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            this.Control.Settings.BuiltInZoomControls = true;
            this.Control.Settings.DisplayZoomControls = false;
        }
    }
}