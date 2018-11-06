using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public class SwitchView : Switch, BaseView
    {
        public SwitchView(Boolean on)
        {
            this.IsToggled = on;
        }

        public View Setup(View parent)
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) => this.IsToggled = !this.IsToggled;
            
            parent.GestureRecognizers.Add(tapGestureRecognizer);

            return this;
        }
        
        public void IsSelected()
        {
        }
    }

    public static class SwitchViewExtensions
    {
    }
}