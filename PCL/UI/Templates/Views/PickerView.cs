using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PCL.UI.Templates.Views
{
    public class PickerView : Picker, BaseView
    {
        public PickerView(List<String> options)
        {
            foreach (String option in options)
            {
                this.Items.Add(option);
            }
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

    public static class PickerViewExtensions
    {
    }
}