using System;
using PCL.UI.Templates.Views;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateColumn2 : StackLayout
    {
        public class TemplateColumn2View
        {
            public BaseView First;
            public BaseView Second;

            public Double FirstPercentage;
            public Double SecondPercentage;

            public Int32 Spacing;

            public TemplateColumn2View(BaseView first, BaseView second, Double firstPercentage, Double secondPercentage, Int32 spacing)
            {
                this.First = first;
                this.Second = second;
                this.FirstPercentage = firstPercentage;
                this.SecondPercentage = secondPercentage;
                this.Spacing = spacing;
            }
        }

        public TemplateColumn2View View;

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

        public Boolean Selected;

        public TemplateColumn2(Boolean selected)
        {
            this.InitializeComponent();

            this.Padding = new Thickness(10, 5);

            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.Padding = new Thickness(10*1.5, 5*1.5);
            }

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
            ((View) this.Second).WidthRequest = width*this.View.SecondPercentage - this.Padding.Right - this.Spacing*0.5;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (TemplateColumn2View))
            {
                this.View = (TemplateColumn2View) this.BindingContext;

                if (this.Selected)
                {
                    this.First.IsSelected();
                    this.Second.IsSelected();

                    this.BackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
                }

                this.Spacing = this.View.Spacing;

                Double width = App.ScreenSize.Width;

                View firstView = this.First.Setup(this);
                firstView.WidthRequest = width*this.View.FirstPercentage - this.Padding.Left - this.Spacing*0.5;
                firstView.VerticalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(firstView);

                View secondView = this.Second.Setup(this);
                secondView.WidthRequest = width*this.View.SecondPercentage - this.Padding.Right - this.Spacing*0.5;
                secondView.VerticalOptions = LayoutOptions.FillAndExpand;
                this.Children.Add(secondView);
            }
        }

        public static TemplateColumn2 Create(BaseView first, BaseView second, Double firstPercentage = 0.5, Double secondPercentage = 0.5, Int32 spacing = 0, Boolean selected = false)
        {
            return new TemplateColumn2(selected)
            {
                BindingContext = new TemplateColumn2View(first, second, firstPercentage, secondPercentage, spacing)
            };
        }
    }
}