using System;
using PCL.UI.Templates.Views;
using Xamarin.Forms;

namespace PCL.UI.Templates
{
    public partial class TemplateRow2 : StackLayout
    {
        public class TemplateRow2View
        {
            public BaseView First;
            public BaseView Second;

            public TemplateRow2View(BaseView first, BaseView second)
            {
                this.First = first;
                this.Second = second;
            }
        }

        public TemplateRow2View View;

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

        public Double WidthPercentage;
        public Boolean Selected;

        public TemplateRow2(Double widthPercentage, Boolean selected)
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
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (TemplateRow2View))
            {
                this.View = (TemplateRow2View) this.BindingContext;

                if (this.Selected)
                {
                    this.View.First.IsSelected();
                    this.View.Second.IsSelected();

                    this.BackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
                }

                View firstView = this.First.Setup(this);
                this.Children.Add(firstView);

                View secondView = this.Second.Setup(this);
                this.Children.Add(secondView);
            }
        }

        public static TemplateRow2 Create(BaseView first, BaseView second, Double widthPercentage = 1.0, Boolean selected = false)
        {
            return new TemplateRow2(widthPercentage, selected)
            {
                BindingContext = new TemplateRow2View(first, second)
            };
        }
    }
}