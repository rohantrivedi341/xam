using System;
using PCL.DependencyServices;
using PCL.DependencyServices;
using PCL.Repository;
using PCL.UI;
using Xamarin.Forms;

namespace PCL
{
    public class App : Application
    {
        public static App CurrentInstance;

        public IDependencyApplicationDatabase DependencyApplicationDatabase;
        public IDependencyApplicationGeneral DependencyApplicationGeneral;
        public IDependencyApplicationStyle DependencyApplicationStyle;
        public IDependencyApplicationUI DependencyApplicationUI;
        public IDependencyApplicationUpdateContent DependencyApplicationUpdateContent;

        public IDependencyPlatformGeneral DependencyPlatformGeneral;
        public IDependencyPlatformGoogleAnalytics DependencyPlatformGoogleAnalytics;
        public IDependencyPlatformIO DependencyPlatformIO;
        public IDependencyPlatformOpenExternal DependencyPlatformOpenExternal;
        public IDependencyPlatformPersistentStorage DependencyPlatformPersistentStorage;

        public ViewMain ViewMain;

        public static Rectangle ScreenSize;

        public App()
        {
            App.CurrentInstance = this;

            this.DependencyApplicationDatabase = DependencyService.Get<IDependencyApplicationDatabase>();
            this.DependencyApplicationGeneral = DependencyService.Get<IDependencyApplicationGeneral>();
            this.DependencyApplicationStyle = DependencyService.Get<IDependencyApplicationStyle>();
            this.DependencyApplicationUI = DependencyService.Get<IDependencyApplicationUI>();
            this.DependencyApplicationUpdateContent = DependencyService.Get<IDependencyApplicationUpdateContent>();

            this.DependencyPlatformGeneral = DependencyService.Get<IDependencyPlatformGeneral>();
            this.DependencyPlatformGoogleAnalytics = DependencyService.Get<IDependencyPlatformGoogleAnalytics>();
            this.DependencyPlatformIO = DependencyService.Get<IDependencyPlatformIO>();
            this.DependencyPlatformOpenExternal = DependencyService.Get<IDependencyPlatformOpenExternal>();
            this.DependencyPlatformPersistentStorage = DependencyService.Get<IDependencyPlatformPersistentStorage>();
            
            ViewSplash page = new ViewSplash();
            page.Title = App.CurrentInstance.DependencyApplicationGeneral.GetApplicationName();

            NavigationPage navigationPage = new NavigationPage(page);
            navigationPage.BarBackgroundColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark();
            navigationPage.BarTextColor = Color.White;

            this.MainPage = navigationPage;
        }
    }
}