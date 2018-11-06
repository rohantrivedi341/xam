using System;
using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public class ButtonView : Button, BaseView
    {
        public ButtonView(String text, EventHandler eventHandlerClicked)
        {
            this.Text = text;
            this.Clicked += eventHandlerClicked;
        }

        public View Setup(View parent)
        {
            return this;
        }

        public void IsSelected()
        {
        }
    }

    public static class ButtonViewExtensions
    {
    }
}