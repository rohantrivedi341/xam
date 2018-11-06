using Droid.Renderers;
using PCL.UI.CustomViews;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof (CV_ButtonDisableFocus), typeof (CV_ButtonDisableFocusRenderer))]

namespace Droid.Renderers
{
    public class CV_ButtonDisableFocusRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            this.Control.Focusable = false;
        }
    }
}