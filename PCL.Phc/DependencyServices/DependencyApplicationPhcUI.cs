using System;
using System.Threading.Tasks;
using PCL.Common;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Phc.Common;
using PCL.Phc.Common.View;
using PCL.Phc.DependencyServices;
using PCL.Phc.Repository;
using PCL.Phc.UI;
using PCL.Repository;
using PCL.UI;
using Xamarin.Forms;
using ItemCalculator = PCL.Phc.Common.ItemCalculator;

[assembly: Dependency(typeof (DependencyApplicationPhcUI))]

namespace PCL.Phc.DependencyServices
{
    public class DependencyApplicationPhcUI : IDependencyApplicationUI
    {
        public Task CalculatorStart(Page page, String identifier)
        {
            return this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).Get(identifier));
        }

        public Task CalculatorStart(Page page, StructureItem structureItem)
        {
            return this.CalculatorStart(page, new ItemCalculatorRepository(SQLiteConnectionDatabase.NewConnection()).GetByStructureItem(structureItem.Id));
        }

        private async Task<Boolean> CalculatorStart(Page page, ItemCalculator itemCalculator)
        {
            switch (itemCalculator.Type)
            {
                case ItemCalculatorType.PaediatricDosages:
                    await page.Navigation.PushAsync(new ViewCalculatorPaediatricDosageMedicine()
                    {
                        BindingContext = new CalculatorPaediatricDosageView()
                    }, true);

                    break;
                case ItemCalculatorType.MedicineCosting:
                    await page.Navigation.PushAsync(new ViewCalculatorMedicineCostingGeneric()
                    {
                        BindingContext = new CalculatorMedicineCostingView()
                    }, true);
                    break;
                case ItemCalculatorType.DrugStockOut:
                    await page.Navigation.PushAsync(new ViewItemCalculatorLink()
                    {
                        BindingContext = itemCalculator
                    }, true);
                    break;
                case ItemCalculatorType.SuspectedAdverseDrugReaction:
                    await page.Navigation.PushAsync(new ViewItemCalculatorLink()
                    {
                        BindingContext = itemCalculator
                    }, true);
                    break;
                case ItemCalculatorType.Icd10Codes:
                    await page.Navigation.PushAsync(new ViewCalculatorIcd10CodesChapter()
                    {
                        BindingContext = new CalculatorIcd10View()
                    }, true);
                    break;
                case ItemCalculatorType.CardiovascularRisk:
                    await page.Navigation.PushAsync(new ViewCalculatorCardiovascularRiskSex()
                    {
                        BindingContext = new CalculatorCardiovascularRiskView()
                    }, true);
                    break;
            }

            return true;
        }

        private class SplashScreen
        {
            public Image TopDoh { get; set; }

            public Xamarin.Forms.Label MiddleLabel1 { get; set; }

            public Xamarin.Forms.Label MiddleLabel2 { get; set; }

            public Xamarin.Forms.Label MiddleLabel3 { get; set; }

            public Image BottomMRC { get; set; }

            public StackLayout BottomSpace { get; set; }

            public Image BottomTOMPSA { get; set; }
        }

        private SplashScreen SplashScreenView = new SplashScreen();

        public void SplashScreenFill(StackLayout stackLayoutTop, ref Double stackLayoutYTop, StackLayout stackLayoutMiddle, ref Double stackLayoutYMiddle, StackLayout stackLayoutBottom, ref Double stackLayoutYBottom, ImageSource ompSource)
        {
            // TOP
            stackLayoutYTop = 0.1;

            this.SplashScreenView.TopDoh = new Image()
            {
                Source = ImageSource.FromResource("PCL.Phc.Assets.ic_logo_doh.png"),
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = App.ScreenSize.Height*0.2,
                WidthRequest = App.ScreenSize.Width,
                Aspect = Aspect.AspectFit,
            };

            stackLayoutTop.Children.Add(this.SplashScreenView.TopDoh);

            // MIDDLE
            stackLayoutYMiddle = 0.4;

            this.SplashScreenView.MiddleLabel1 = new Xamarin.Forms.Label()
            {
                Text = PhcResources.SplashTextLine1,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            this.SplashScreenView.MiddleLabel2 = new Xamarin.Forms.Label()
            {
                Text = PhcResources.SplashTextLine2,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            this.SplashScreenView.MiddleLabel3 = new Xamarin.Forms.Label()
            {
                Text = PhcResources.SplashTextLine3,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                FontAttributes = FontAttributes.Bold,
                FontSize = 18,
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
            };

            stackLayoutMiddle.Children.Add(this.SplashScreenView.MiddleLabel1);
            stackLayoutMiddle.Children.Add(this.SplashScreenView.MiddleLabel2);
            stackLayoutMiddle.Children.Add(this.SplashScreenView.MiddleLabel3);

            // BOTTOM
            stackLayoutYBottom = 0.65;

            this.SplashScreenView.BottomMRC = new Image()
            {
                Source = ImageSource.FromResource("PCL.Phc.Assets.ic_logo_mrc.png"),
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = App.ScreenSize.Height*0.15,
                Aspect = Aspect.AspectFit,
            };

            this.SplashScreenView.BottomSpace = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = App.ScreenSize.Height*0.03,
                WidthRequest = App.ScreenSize.Width,
            };

            this.SplashScreenView.BottomTOMPSA = new Image()
            {
                Source = ompSource,
                HorizontalOptions = LayoutOptions.Center,
                HeightRequest = App.ScreenSize.Height*0.07,
                WidthRequest = App.ScreenSize.Width,
                Aspect = Aspect.AspectFit,
            };

            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomMRC);
            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomSpace);
            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomTOMPSA);
        }

        public void SplashScreenSizeAllocated()
        {
            this.SplashScreenView.TopDoh.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.TopDoh.HeightRequest = App.ScreenSize.Height*0.2;

            this.SplashScreenView.MiddleLabel1.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.MiddleLabel2.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.MiddleLabel3.WidthRequest = App.ScreenSize.Width;

            this.SplashScreenView.BottomMRC.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.BottomMRC.HeightRequest = App.ScreenSize.Height*0.15;

            this.SplashScreenView.BottomSpace.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.BottomSpace.HeightRequest = App.ScreenSize.Height*0.03;

            this.SplashScreenView.BottomTOMPSA.WidthRequest = App.ScreenSize.Width;
            this.SplashScreenView.BottomTOMPSA.HeightRequest = App.ScreenSize.Height*0.07;
        }
    }
}