using System;
using PCL.UI.Templates.Views;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateColumn1 : StackLayout
    {
        public class TemplateColumn1View
        {
            public BaseView First;
            public Double FirstPercentage;

            public TemplateColumn1View(BaseView first, Double firstPercentage)
            {
                this.First = first;
                this.FirstPercentage = firstPercentage;
            }
        }

        public TemplateColumn1View View;

        public BaseView First
        {
            get
            {
                return this.View.First;
            }
        }

        public Boolean Selected;

        public TemplateColumn1(Boolean selected)
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

            ((View) this.First).WidthRequest = width*this.View.FirstPercentage - this.Padding.Left - this.Padding.Right;
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (TemplateColumn1View))
            {
                this.View = (TemplateColumn1View) this.BindingContext;

                if (this.Selected)
                {
                    this.First.IsSelected();

                    this.BackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
                }

                Double width = App.ScreenSize.Width;

                View firstView = this.First.Setup(this);
                firstView.WidthRequest = width*this.View.FirstPercentage - this.Padding.Left - this.Padding.Right;
                firstView.VerticalOptions = LayoutOptions.FillAndExpand;

                this.Children.Add(firstView);
            }
        }

        public static TemplateColumn1 Create(BaseView first, Double firstPercentage = 1.0, Boolean selected = false)
        {
            return new TemplateColumn1(selected)
            {
                BindingContext = new TemplateColumn1View(first, firstPercentage)
            };
        }
    }
}