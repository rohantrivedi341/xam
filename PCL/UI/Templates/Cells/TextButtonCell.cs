using System;
using PCL.Common;
using PCL.UI.CustomViews;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace PCL.UI.Templates.Cells
{
    public class TextButtonCell : ViewCell
    {
        public Boolean HasContent;

        public Label Label;
        public CV_ButtonDisableFocus Button;

        public TextButtonCell()
        {
            this.Label = new Label();
            this.Label.HorizontalOptions = LayoutOptions.FillAndExpand;
            this.Label.YAlign = TextAlignment.Center;
            this.Label.TextColor = Color.Black;
            this.Label.FontSize = 13.0;

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.Label.FontSize = this.Label.FontSize*1.5;

                this.Height = this.Label.FontSize*3;
            }

            this.Button = new CV_ButtonDisableFocus();
            this.Button.Image = (FileImageSource) ImageSource.FromFile("list_item_information.png");
            this.Button.BackgroundColor = Color.Transparent;
            this.Button.HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false);
            this.Button.VerticalOptions = new LayoutOptions(LayoutAlignment.Center, false);

            this.View = new StackLayout()
            {
                Orientation = StackOrientation.Horizontal,
                Spacing = 0,
                Padding = new Thickness(15, 0, 0, 0),
                Children =
                {
                    this.Label,
                    this.Button
                }
            };

            this.View.SizeChanged += (s, e) =>
                                     {
                                         if (this.HasContent)
                                         {
                                             this.Label.WidthRequest = App.ScreenSize.Width*0.8 - 15;
                                             this.Button.WidthRequest = App.ScreenSize.Width*0.2;
                                         }
                                         else
                                         {
                                             this.Label.WidthRequest = App.ScreenSize.Width*1.0 - 15;
                                             this.Button.WidthRequest = App.ScreenSize.Width*0.0;
                                         }
                                     };
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext == null)
                return;

            if (this.BindingContext.GetType() == typeof (StructureItem))
            {
                StructureItem structureItem = (StructureItem) this.BindingContext;

                this.Label.Text = structureItem.ToString();

                this.HasContent = !String.IsNullOrWhiteSpace(structureItem.Information);

                this.Button.Clicked += (sender, e) => ((ContentPage) ((Button) sender).ParentView.ParentView.ParentView).DisplayAlert(PCLResources.Information, structureItem.Information, PCLResources.OK);
            }
        }
    }
}