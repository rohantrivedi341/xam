using System;
using System.Linq;
using PCL.Common;
using PCL.ViewModels;
using Xamarin.Forms;

namespace PCL.UI.Helpers
{
    public static class WebViewHandler
    {
        public static Boolean HandleNewPage(ContentPageBase page, String url, Section section = null, String title = null)
        {
            if (url.StartsWith("image:"))
            {
                page.Navigation.PushAsync(new ViewImage
                {
                    BindingContext = ImageView.Create(section, title, url.Substring("image:".Length))
                }, true);

                return true;
            }

            if (url.StartsWith("calculator:"))
            {
                App.CurrentInstance.DependencyApplicationUI.CalculatorStart(page, url.Substring("calculator:".Length));

                return true;
            }

            if (url.StartsWith("mailto:"))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Email(url.Substring("mailto:".Length));

                return true;
            }

            if (url.StartsWith("http") || url.StartsWith("www"))
            {
                App.CurrentInstance.DependencyPlatformOpenExternal.Browser(url);

                return true;
            }

            if (url.EndsWith(".html"))
            {
                ItemPage itemPage = page.ViewBase.RepositoryItemPage.Get(url.Split('/').Last());

                if (itemPage == null)
                {
                    return false;
                }

                StructureItem structureItem = page.ViewBase.RepositoryStructureItem.Get(itemPage.StructureItemId);

                page.Navigation.PushAsync(new ViewItemPage
                {
                    BindingContext = structureItem
                }, true);

                return true;
            }

            return false;
        }
    }
}