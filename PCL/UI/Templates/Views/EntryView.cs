using System;
using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public class EntryView : Entry, BaseView
    {
        public EntryView(String text, Keyboard keyboard, String placeHolder = null)
        {
            this.Text = text;
            this.Keyboard = keyboard;

            if (!String.IsNullOrWhiteSpace(placeHolder))
                this.Placeholder = placeHolder;
        }

        public View Setup(View parent)
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) => this.Focus();

            parent.GestureRecognizers.Add(tapGestureRecognizer);

            return this;
        }

        public void IsSelected()
        {
        }
    }

    public static class EntryViewExtensions
    {
    }
}