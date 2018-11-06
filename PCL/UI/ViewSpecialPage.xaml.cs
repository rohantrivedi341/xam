using System;
using PCL.Common;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewSpecialPage : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {
            public CV_WebView WebView;

            public Section Section;
            public SpecialPage SpecialPage;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewSpecialPage()
        {
            this.InitializeComponent();

            // Get WebView
            this.View.WebView = this.webView;

            // Set navigation handler
            this.View.WebView.Navigating += this.OnNavigating;

            // Create Search toolbar item
            ToolbarCommand.Search(this);

            // Create Home toolbar item
            ToolbarCommand.Home(this);
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            if (this.BindingContext.GetType() == typeof (SpecialPage))
            {
                this.View.SpecialPage = (SpecialPage) this.BindingContext;

                // Get Section
                this.View.Section = this.View.RepositorySection.Get(this.View.SpecialPage.SectionId);

                HtmlWebViewSource htmlSource = new HtmlWebViewSource();

                // Create path
                this.View.WebView.Url = String.Format("{0}/{1}/content/", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectoryForWebView(), this.View.Section.Location);

                if (Device.OS != TargetPlatform.iOS)
                {
                    htmlSource.BaseUrl = this.View.WebView.Url;
                }

                // Get content of path
                htmlSource.Html = App.CurrentInstance.DependencyPlatformIO.GetFileContent(String.Format("{0}/{1}/content/{2}", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory(), this.View.Section.Location, this.View.SpecialPage.FileName));

                // Set source
                this.View.WebView.Source = htmlSource;

                // Set title
                this.Title = this.View.SpecialPage.Title;
            }
        }

        private void OnNavigating(object sender, WebNavigatingEventArgs e)
        {
            switch (e.NavigationEvent)
            {
                case WebNavigationEvent.NewPage:

                    // Execute NewPage handler
                    e.Cancel = WebViewHandler.HandleNewPage(this, e.Url, this.View.Section, this.View.SpecialPage.Title);

                    break;
            }
        }
    }
}