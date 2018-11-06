using System;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateSpace : StackLayout
    {
        public TemplateSpace(Int32 height)
        {
            this.InitializeComponent();

            this.Children.Add(new BoxView()
            {
                HeightRequest = height,
                WidthRequest = App.ScreenSize.Width
            });
        }

        public static TemplateSpace Create(Int32 height = 10)
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                height = (Int32) (height*1.5);
            }

            return new TemplateSpace(height);
        }
    }
}