using System;
using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public class ImageView : Image, BaseView
    {
        public ImageView(ImageSource source, Double? width = null, EventHandler eventHandlerTapped = null)
        {
            this.Source = source;

            if (width != null)
            {
                this.WidthRequest = width.Value;
            }

            this.HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false);
            this.VerticalOptions = new LayoutOptions(LayoutAlignment.Center, false);

            if (eventHandlerTapped != null)
            {
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += eventHandlerTapped;

                this.GestureRecognizers.Add(tapGestureRecognizer);
            }
        }

        public View Setup(View parent)
        {
            return this;
        }

        public void IsSelected()
        {
        }
    }

    public static class ImageViewExtensions
    {
    }
}