using System;
using Xamarin.Forms;

namespace PCL.UI.Templates.Cells
{
    public class TextDefaultCell : ViewCell
    {
        public Label Label;

        public TextDefaultCell()
        {
            this.Label = new Label();
            this.Label.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Label.YAlign = TextAlignment.Center;
            this.Label.TextColor = Color.Black;
            this.Label.FontSize = 13.0;

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.Label.FontSize = this.Label.FontSize * 1.5;

                this.Height = this.Label.FontSize * 3;
            }

            this.View = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Padding = new Thickness(15, 0, 0, 0),
                Children =
                {
                    this.Label,
                }
            };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext == null)
                return;

            this.Label.Text = this.BindingContext.ToString();
        }
    }
}