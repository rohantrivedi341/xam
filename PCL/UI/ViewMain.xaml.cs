using System;
using System.Collections.Generic;
using PCL.Common;
using PCL.Common.Enum;
using PCL.Database;
using PCL.Repository;
using Xamarin.Forms;

namespace PCL.UI
{
    public partial class ViewMain : TabbedPage
    {
        public ViewMain SetTitle(String title)
        {
            this.Title = title;

            App.CurrentInstance.ViewMain = this;

            return this;
        }

        public ViewMain()
        {
            this.InitializeComponent();

            // Get Sections which needs to be displayed in tabbar
            List<Section> sections = new SectionRepository(SQLiteConnectionDatabase.NewConnection()).GetDisplayedInMenu();

            // Make top NavigationPage invisible on iOS, because iOS has two NavigationPages
            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }

            foreach (Section section in sections)
            {
                Page page = this.CreatePage(section);

                // Nest list in NavigationPage on iOS
                if (Device.OS.Equals(TargetPlatform.iOS))
                {
                    NavigationPage navigationPage = new NavigationPage(page);
                    navigationPage.Title = section.Title;
                    navigationPage.Icon = section.Icon;
                    navigationPage.BarBackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
                    navigationPage.BarTextColor = Color.White;

                    this.Children.Add(navigationPage);
                }
                else
                {
                    this.Children.Add(page);
                }
            }
            
            this.CurrentPage = this.Children[1];
        }

        public Page CreatePage(Section section)
        {
            ViewStructureItemList viewStructureItemList = new ViewStructureItemList();
            viewStructureItemList.BindingContext = section;
            viewStructureItemList.Title = section.Title;

            return viewStructureItemList;
        }

        public async void UpdateFavorites()
        {
            Section favoriteSection = new SectionRepository(SQLiteConnectionDatabase.NewConnection()).GetFavoriteSection();

            if (favoriteSection == null)
                return;

            Page page = this.CreatePage(favoriteSection);

            // Nest list in NavigationPage on iOS
            if (Device.OS.Equals(TargetPlatform.iOS))
            {
                NavigationPage navigationPage = (NavigationPage)this.Children[0];
                
                // Add new favorites page at the beginning
                navigationPage.Navigation.InsertPageBefore(page, navigationPage.Navigation.NavigationStack[0]);
                
                // Pop to root
                await navigationPage.PopToRootAsync();
            }
            else
            {
                this.Children[0] = page;
            }
        }
    }
}