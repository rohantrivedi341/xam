using System;
using PCL.UI.Helpers;
using PCL.ViewModels;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewImage : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public WebView WebView;

            public ImageView ImageView;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewImage()
        {
            this.InitializeComponent();

            // Get WebView
            this.View.WebView = this.webView;

            // Create Search toolbar item
            ToolbarCommand.Search(this);

            // Create Home toolbar item
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (ImageView))
            {
                this.View.ImageView = (ImageView) this.BindingContext;

                // Set source
                this.View.WebView.Source = new HtmlWebViewSource
                {
                    Html = String.Format("<html><meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=10.0;\"><body><img src=\"{0}\"/></body></html>", this.View.ImageView.Location)
                };

                // Set title
                this.Title = this.View.ImageView.Title;
            }
        }
    }
}