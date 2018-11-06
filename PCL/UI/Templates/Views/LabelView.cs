using System;
using System.Globalization;
using ExternalMaps.Plugin;
using PCL.Common;
using PCL.UI.Templates.Views.Enum;
using Xamarin.Forms;
using Label = Xamarin.Forms.Label;

namespace PCL.UI.Templates.Views
{
    public class LabelView : Label, BaseView
    {
        public LabelDisplayType DisplayType { get; set; }

        public LabelInteractionType InteractionType { get; set; }

        public Boolean Selected { get; set; }

        public Object View { get; set; }

        public LabelView(String text, LabelDisplayType displayType = LabelDisplayType.Normal, LabelInteractionType interactionType = LabelInteractionType.None)
        {
            this.Text = text;
            this.DisplayType = displayType;
            this.InteractionType = interactionType;
            this.Selected = false;

            this.YAlign = TextAlignment.Center;
        }

        public View Setup(View parent)
        {
            switch (this.DisplayType)
            {
                case LabelDisplayType.Smallest:
                    this.FontSize = 6;
                    break;
                case LabelDisplayType.Smaller:
                    this.FontSize = 8;
                    break;
                case LabelDisplayType.Small:
                    this.FontSize = 10;
                    break;
                case LabelDisplayType.Normal:
                    this.FontSize = 14;
                    break;
                case LabelDisplayType.Big:
                    this.FontSize = 18;
                    break;
                case LabelDisplayType.Bigger:
                    this.FontSize = 24;
                    break;
                case LabelDisplayType.Biggest:
                    this.FontSize = 32;
                    break;
            }

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.FontSize = this.FontSize*1.5;
            }

            if (this.InteractionType != LabelInteractionType.None)
            {
                TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();
                tapGestureRecognizer.Tapped += (sender, e) =>
                                               {
                                                   switch (this.InteractionType)
                                                   {
                                                       case LabelInteractionType.Browser:
                                                           App.CurrentInstance.DependencyPlatformOpenExternal.Browser(this.Text);
                                                           break;

                                                       case LabelInteractionType.Email:
                                                           App.CurrentInstance.DependencyPlatformOpenExternal.Email(this.Text);
                                                           break;

                                                       case LabelInteractionType.Phone:
                                                           App.CurrentInstance.DependencyPlatformOpenExternal.Phone(this.Text);
                                                           break;

                                                       case LabelInteractionType.Map:
                                                           ItemContact itemContact = (ItemContact) this.View;

                                                           CrossExternalMaps.Current.NavigateTo(itemContact.Title, Double.Parse(itemContact.Latitude, CultureInfo.InvariantCulture), Double.Parse(itemContact.Longitude, CultureInfo.InvariantCulture));

                                                           break;
                                                   }
                                               };

                parent.GestureRecognizers.Add(tapGestureRecognizer);

                this.TextColor = App.CurrentInstance.DependencyApplicationStyle.GetColorAccent();
            }

            if (this.Selected)
            {
                this.TextColor = Color.White;
            }

            return this;
        }

        public void IsSelected()
        {
            this.Selected = true;
        }
    }

    public static class ValueViewExtensions
    {
        public static LabelView Bold(this LabelView labelView)
        {
            labelView.FontAttributes |= FontAttributes.Bold;

            return labelView;
        }

        public static LabelView XAlign(this LabelView labelView, TextAlignment textAlignment)
        {
            labelView.XAlign = textAlignment;

            return labelView;
        }

        public static LabelView YAlign(this LabelView labelView, TextAlignment textAlignment)
        {
            labelView.YAlign = textAlignment;

            return labelView;
        }

        public static LabelView TextColor(this LabelView labelView, Color color)
        {
            labelView.TextColor = color;

            return labelView;
        }

        public static LabelView Font(this LabelView labelView, LabelDisplayType displayType)
        {
            labelView.DisplayType = displayType;

            return labelView;
        }

        public static LabelView InteractionEmail(this LabelView labelView)
        {
            labelView.InteractionType = LabelInteractionType.Email;

            return labelView;
        }

        public static LabelView InteractionPhone(this LabelView labelView)
        {
            labelView.InteractionType = LabelInteractionType.Phone;

            return labelView;
        }

        public static LabelView InteractionBrowser(this LabelView labelView)
        {
            labelView.InteractionType = LabelInteractionType.Browser;

            return labelView;
        }

        public static LabelView InteractionMap(this LabelView labelView, Object view)
        {
            labelView.InteractionType = LabelInteractionType.Map;

            labelView.View = view;

            return labelView;
        }

        public static LabelView _Disclaimer(this LabelView labelView)
        {
            labelView = labelView.Font(LabelDisplayType.Small);
            labelView = labelView.XAlign(TextAlignment.Center);
            labelView = labelView.TextColor(Color.Gray);

            return labelView;
        }
    }
}