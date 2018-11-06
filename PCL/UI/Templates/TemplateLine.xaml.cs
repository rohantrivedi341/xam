using System;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateLine : StackLayout
    {
        public TemplateLine(Int32 height)
        {
            this.InitializeComponent();

            this.Children.Add(new BoxView()
            {
                HeightRequest = height,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = Color.Gray
            });
        }

        public static TemplateLine Create(Int32 height = 2)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                height = (Int32) (height*1.5);
            }

            return new TemplateLine(height);
        }
    }
}