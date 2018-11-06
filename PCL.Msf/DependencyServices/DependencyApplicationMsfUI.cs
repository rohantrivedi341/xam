using System;
using PCL.Common;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Msf.Common;
using PCL.Msf.DependencyServices;
using PCL.Msf.Repository;
using PCL.Repository;
using PCL.UI;
using Xamarin.Forms;
using System.Threading.Tasks;
using ItemCalculator = PCL.Msf.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationMsfUI))]

namespace PCL.Msf.DependencyServices
{
    public class DependencyApplicationMsfUI : IDependencyApplicationUI
    {
        async public Task CalculatorStart(Page page, String identifier)
        {
            this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).Get(identifier));
        }

        async public Task CalculatorStart(Page page, StructureItem structureItem)
        {
            this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).GetByStructureItem(structureItem.Id));
        }

        async private Task CalculatorStart(Page page, ItemCalculator itemCalculator)
        {
            switch (itemCalculator.Type)
            {
                case ItemCalculatorType.Telemedicine:
                    page.Navigation.PushAsync(new ViewItemCalculatorLink()
                    {
                        BindingContext = itemCalculator
                    }, true);

                    break;
            }
        }

        private class SplashScreen
        {
            public Image TopMsf { get; set; }

            public Image BottomTOMPSA { get; set; }
        }

        private SplashScreen SplashScreenView = new SplashScreen();

        public void SplashScreenFill(StackLayout stackLayoutTop, ref Double stackLayoutYTop, StackLayout stackLayoutMiddle, ref Double stackLayoutYMiddle, StackLayout stackLayoutBottom, ref Double stackLayoutYBottom, ImageSource ompSource)
        {
            // TOP
            stackLayoutYTop = 0.1;

            this.SplashScreenView.TopMsf = new Image()
            {
                Source = ImageSource.FromResource("PCL.Msf.Assets.ic_logo_msf.png"),
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = PCL.App.ScreenSize.Height*0.4,
                WidthRequest = PCL.App.ScreenSize.Width,
                Aspect = Aspect.AspectFit,
            };

            stackLayoutTop.Children.Add(this.SplashScreenView.TopMsf);

            // MIDDLE
            stackLayoutYMiddle = 0.6;

            // BOTTOM
            stackLayoutYBottom = 0.8;

            this.SplashScreenView.BottomTOMPSA = new Image()
            {
                Source = ompSource,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = PCL.App.ScreenSize.Height*0.1,
                WidthRequest = PCL.App.ScreenSize.Width,
                Aspect = Aspect.AspectFit,
            };

            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomTOMPSA);
        }

        public void SplashScreenSizeAllocated()
        {
            this.SplashScreenView.TopMsf.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.TopMsf.HeightRequest = PCL.App.ScreenSize.Height*0.4;

            this.SplashScreenView.BottomTOMPSA.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.BottomTOMPSA.HeightRequest = PCL.App.ScreenSize.Height*0.1;
        }
    }
}