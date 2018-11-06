using System;

using PCL.Common;
using PCL.Common.Enum;
using PCL.Repository;
using PCL.UI.CustomViews;
using PCL.UI.Helpers;
using Plugin.Connectivity;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewItemCalculatorLink : ContentPageBase
    {
        private ViewModel _view;
        private ViewModel View => this._view ?? (this._view = new ViewModel(this));

        private new class ViewModel : ContentPageBase.ViewModel
        {

            public CV_WebView WebView;

            public Section Section;
            public StructureItem StructureItem;
            public ItemCalculator ItemCalculator;
            public ItemCalculatorLink ItemCalculatorLink;

            public ViewModel(ContentPageBase page) : base(page)
            {
            }
        }

        public ViewItemCalculatorLink()
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

            this.View.ItemCalculator = (ItemCalculator)this.BindingContext;

            // Get StructureItem
            this.View.StructureItem = this.View.RepositoryStructureItem.Get(this.View.ItemCalculator.StructureItemId);

            // Get Section
            this.View.Section = this.View.RepositorySection.Get(this.View.StructureItem.SectionId);

            // Get ItemCalculatorLink
            this.View.ItemCalculatorLink = this.View.RepositoryItemCalculatorLink.GetByItemCalculator(this.View.ItemCalculator.Id);

            switch (this.View.ItemCalculatorLink.Type)
            {
                case ItemCalculatorLinkType.Folder:
                    HtmlWebViewSource htmlSource = new HtmlWebViewSource();

                    // Set path
                    this.View.WebView.Url = String.Format("{0}/{1}/{2}/", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectoryForWebView(), this.View.Section.Location, this.View.ItemCalculatorLink.Link);
                    
                    if (Device.OS != TargetPlatform.iOS)
                    {
                        htmlSource.BaseUrl = this.View.WebView.Url;
                    }

                    // Get content of path
                    htmlSource.Html = App.CurrentInstance.DependencyPlatformIO.GetFileContent(String.Format("{0}/{1}/{2}/index.html", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectory(), this.View.Section.Location, this.View.ItemCalculatorLink.Link));

                    // Set source
                    this.View.WebView.Source = htmlSource;

                    break;
                case ItemCalculatorLinkType.Url:

                    // Set source
                    this.View.WebView.Source = this.View.ItemCalculatorLink.Link;

                    break;
            }

            // Set title
            this.Title = this.View.StructureItem.Title;

            // Create PrintWebView toolbar item
            ToolbarCommand.Print(this, this.View.StructureItem.Title, this.View.WebView);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Alert user when there is no internet connection
            if (!CrossConnectivity.Current.IsConnected)
            {
                this.DisplayAlert(PCLResources.ImportantInformation, PCLResources.NoInternetConnectionFormSubmit, PCLResources.OK);
            }
        }
    }
}