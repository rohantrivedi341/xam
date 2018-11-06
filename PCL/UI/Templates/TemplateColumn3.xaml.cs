using System;
using PCL.UI.Templates.Views;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateColumn3 : StackLayout
    {
        public class TemplateColumn3View
        {
            public BaseView First;
            public BaseView Second;
            public BaseView Third;

            public Double FirstPercentage;
            public Double SecondPercentage;
            public Double ThirdPercentage;

            public Int32 Spacing;

            public TemplateColumn3View(BaseView first, BaseView second, BaseView third, Double firstPercentage, Double secondPercentage, Double thirdPercentage, Int32 spacing)
            {
                this.First = first;
                this.Second = second;
                this.Third = third;

                this.FirstPercentage = firstPercentage;
                this.SecondPercentage = secondPercentage;
                this.ThirdPercentage = thirdPercentage;

                this.Spacing = spacing;
            }
        }

        public TemplateColumn3View View;

        public BaseView First
        {
            get
            {
                return this.View.First;
            }
        }

        public BaseView Second
        {
            get
            {
                return this.View.Second;
            }
        }

        public BaseView Third
        {
            get
            {
                return this.View.Third;
            }
        }

        public Double WidthPercentage;
        public Boolean Selected;

        public TemplateColumn3(Double widthPercentage, Boolean selected)
        {
            this.InitializeComponent();

            this.Padding = new Thickness(10, 5);

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.Padding = new Thickness(10*1.5, 5*1.5);
            }

            this.WidthPercentage = widthPercentage;
            this.Selected = selected;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);

            if (this.View == null)
            {
                return;
            }

            ((View) this.First).WidthRequest = width*this.View.FirstPercentage - this.Padding.Left - this.Spacing*0.5;
            ((View) this.Second).WidthRequest = width*this.View.SecondPercentage - this.Spacing;
            ((View) this.Third).WidthRequest = width*this.View.ThirdPercentage - this.Padding.Right - this.Spacing*0.5;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (TemplateColumn3View))
            {
                this.View = (TemplateColumn3View) this.BindingContext;

                if (this.Selected)
                {
                    this.First.IsSelected();
                    this.Second.IsSelected();
                    this.Third.IsSelected();

                    this.BackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
                }

                this.Spacing = this.View.Spacing;

                Double width = (App.ScreenSize.Width*this.WidthPercentage);

                View firstView = this.First.Setup(this);
                firstView.WidthRequest = width*this.View.FirstPercentage - this.Padding.Left - this.Spacing*0.5;
                firstView.VerticalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(firstView);

                View secondView = this.Second.Setup(this);
                secondView.WidthRequest = width*this.View.SecondPercentage - this.Spacing;
                secondView.VerticalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(secondView);

                View thirdView = this.Third.Setup(this);
                thirdView.WidthRequest = width*this.View.ThirdPercentage - this.Padding.Right - this.Spacing*0.5;
                thirdView.VerticalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(thirdView);
            }
        }

        public static TemplateColumn3 Create(BaseView first, BaseView second, BaseView third, Double widthPercentage = 1.0, Double firstPercentage = 0.34, Double secondPercentage = 0.32, Double thirdPercentage = 0.34, Int32 spacing = 0, Boolean selected = false)
        {
            return new TemplateColumn3(widthPercentage, selected)
            {
                BindingContext = new TemplateColumn3View(first, second, third, firstPercentage, secondPercentage, thirdPercentage, spacing)
            };
        }
    }
}