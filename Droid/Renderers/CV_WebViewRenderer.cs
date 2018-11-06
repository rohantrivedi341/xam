using Droid.Renderers;
using PCL.UI.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (CV_WebView), typeof (CV_WebViewRenderer))]

namespace Droid.Renderers
{
    public class CV_WebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            ((CV_WebView) this.Element).PlatformControl = this.Control;

            this.Control.Settings.BuiltInZoomControls = true;
            this.Control.Settings.DisplayZoomControls = false;
        }
    }
}