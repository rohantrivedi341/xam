using System;
using System.Threading.Tasks;
using PCL.Common;
using PCL.Database;
using PCL.DependencyServices;
using PCL.DohReporting.Common;
using PCL.DohReporting.DependencyServices;
using PCL.DohReporting.Repository;
using PCL.UI;
using PCL.UI.Helpers;
using Xamarin.Forms;
using ItemCalculator = PCL.DohReporting.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationDohReportingUI))]

namespace PCL.DohReporting.DependencyServices
{
    public class DependencyApplicationDohReportingUI : IDependencyApplicationUI
    {
        async public Task CalculatorStart(Page page, String identifier)
        {
            this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).Get(identifier));
        }

        async public Task CalculatorStart(Page page, StructureItem structureItem)
        {
            this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).GetByStructureItem(structureItem.Id));
        }

        async public Task CalculatorStart(Page page, ItemCalculator itemCalculator)
        {
            switch (itemCalculator.Type)
            {
                case ItemCalculatorType.DrugStockOut_Public:
                    page.Navigation.PushAsync(new ViewItemCalculatorLink()
                    {
                        BindingContext = itemCalculator
                    }, true);

                    break;
                case ItemCalculatorType.DrugStockOut_HealthWorker:
                    page.Navigation.PushAsync(new ViewItemCalculatorLink()
                    {
                        BindingContext = itemCalculator
                    }, true);

                    break;
            }
        }

        public void SplashScreenFill(StackLayout stackLayoutTop, ref Double stackLayoutYTop, StackLayout stackLayoutMiddle, ref Double stackLayoutYMiddle, StackLayout stackLayoutBottom, ref Double stackLayoutYBottom, ImageSource ompSource)
        {
            // TOP
            stackLayoutTop.Children.Add(new Image()
            {
                Source = ImageSource.FromResource("PCL.Hiv.Assets.ic_logo_doh.png"),
                HeightRequest = PCL.App.ScreenSize.Height*0.2,
                Aspect = Aspect.AspectFit,
            });

            // MIDDLE
            stackLayoutYMiddle = 0.4;

            // BOTTOM
            stackLayoutYBottom = 0.8;

            stackLayoutBottom.Children.Add(new Image()
            {
                Source = ompSource,
                HeightRequest = App.ScreenSize.Height*0.05,
                WidthRequest = App.ScreenSize.Width*0.8,
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false),
                Aspect = Aspect.AspectFit,
            });
        }

        public void SplashScreenSizeAllocated()
        {
            throw new NotImplementedException();
        }
    }
}