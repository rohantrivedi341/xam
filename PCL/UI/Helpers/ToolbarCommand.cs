using System;
using System.Collections.Generic;
using System.Linq;
using PCL.Common;
using PCL.DependencyServices;
using PCL.Repository;
using PCL.UI.CustomViews;
using Xamarin.Forms;

namespace PCL.UI.Helpers
{
    public static class ToolbarCommand
    {
        public static void Home(Page page)
        {
            if (Device.OS.Equals(TargetPlatform.Android))
            {
                page.ToolbarItems.Add(new ToolbarItem(PCLResources.Home, "toolbar_home.png", async () => { await page.Navigation.PopToRootAsync(); }, ToolbarItemOrder.Primary, 50));
            }
        }

        public static void Favorite(Page page, FavoriteRepository favoriteRepository, StructureItem structureItem)
        {
            if (!structureItem.Uuid.HasValue)
                return;
            
            Favorite favorite = favoriteRepository.GetByUuid(structureItem.Uuid.Value);
            
            ToolbarItem toolbarItem = new ToolbarItem();
            toolbarItem.Text = PCLResources.Favorite;
            toolbarItem.Icon = favorite != null ? "toolbar_favorite_on.png" : "toolbar_favorite_off.png";
            toolbarItem.Clicked += (s, e) =>
            {
                if (favorite != null)
                {
                    favoriteRepository.Delete(favorite);

                    toolbarItem.Icon = "toolbar_favorite_off.png";

                    favorite = null;
                }
                else
                {
                    favorite = new Favorite(structureItem.Uuid.Value, structureItem.Type, structureItem.Title, structureItem.SubTitle);
                    
                    favoriteRepository.Save(favorite);

                    toolbarItem.Icon = "toolbar_favorite_on.png";
                }
                
                App.CurrentInstance.ViewMain.UpdateFavorites();
            };

            toolbarItem.Order = ToolbarItemOrder.Primary;
            toolbarItem.Priority = 100;

            page.ToolbarItems.Add(toolbarItem);
        }

        public static void Information(ContentPageBase page)
        {
            List<SpecialPage> specialPages = page.ViewBase.RepositorySpecialPage.Get();

            if (!specialPages.Any())
            {
                return;
            }

            page.ToolbarItems.Add(new ToolbarItem(PCLResources.Information, "toolbar_information.png", async () =>
                                                                                                             {
                                                                                                                 List<String> titles = specialPages.Select(x => x.Title).ToList();
                                                                                                                 titles.Add(PCLResources.TechnicalInformation);

                                                                                                                 String selectedTitle = await page.DisplayActionSheet(PCLResources.Information, PCLResources.Cancel, null, titles.ToArray());

                                                                                                                 if (selectedTitle == null || selectedTitle.Equals(PCLResources.Cancel))
                                                                                                                 {
                                                                                                                     return;
                                                                                                                 }

                                                                                                                 if (!selectedTitle.Equals(PCLResources.TechnicalInformation))
                                                                                                                 {
                                                                                                                     await page.Navigation.PushAsync(new ViewSpecialPage
                                                                                                                     {
                                                                                                                         BindingContext = specialPages.Where(x => x.Title.Equals(selectedTitle)).SingleOrDefault()
                                                                                                                     });
                                                                                                                 }
                                                                                                                 else
                                                                                                                 {
                                                                                                                     await page.DisplayAlert(PCLResources.TechnicalInformation, String.Format("Application version\r\n{0}\r\n\r\nApplication build\r\n{1}\r\n\r\nContent version\r\n{2}", App.CurrentInstance.DependencyApplicationGeneral.GetApplicationVersion(), App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultInt32(DependencyPlatformPersistentStorageConstants.ApplicationVersion, 0), App.CurrentInstance.DependencyPlatformPersistentStorage.GetValueOrDefaultInt32(DependencyPlatformPersistentStorageConstants.ContentVersion, 0)), PCLResources.OK);
                                                                                                                 }
                                                                                                             }, ToolbarItemOrder.Primary, 100));
        }

        public static void Print(Page page, String name, CV_WebView webView)
        {
            page.ToolbarItems.Add(new ToolbarItem(PCLResources.Print, "toolbar_print.png", async () =>
                                                                                                 {
                                                                                                     if (!App.CurrentInstance.DependencyPlatformOpenExternal.Print(name, webView))
                                                                                                     {
                                                                                                         await page.DisplayAlert(PCLResources.NotSupported, PCLResources.PrintingNotSupported, PCLResources.OK);
                                                                                                     }
                                                                                                 }, ToolbarItemOrder.Primary, 500));
        }

        public static void Share(Page page, Action action)
        {
            page.ToolbarItems.Add(new ToolbarItem(PCLResources.Share, "toolbar_share.png", action, ToolbarItemOrder.Primary, 750));
        }

        public static void Search(Page page)
        {
            page.ToolbarItems.Add(new ToolbarItem(PCLResources.Search, "toolbar_search.png", async () => { await page.Navigation.PushAsync(new ViewSearch()); }, ToolbarItemOrder.Primary, 1000));
        }
    }
}