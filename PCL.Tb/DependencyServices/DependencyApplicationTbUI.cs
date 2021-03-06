﻿using System;
using PCL.Common;
using PCL.Database;
using PCL.DependencyServices;
using PCL.Tb.UI;
using PCL.Tb.Common;
using PCL.Tb.Common.View;
using PCL.Tb.DependencyServices;
using PCL.Tb.Repository;
using PCL.UI;
using Xamarin.Forms;
using ItemCalculator = PCL.Tb.Common.ItemCalculator;
using System.Threading.Tasks;

[assembly: Dependency(typeof(DependencyApplicationTbUI))]

namespace PCL.Tb.DependencyServices
{
    public class DependencyApplicationTbUI : IDependencyApplicationUI
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
                case ItemCalculatorType.AdultDsTbDosages:
                    await page.Navigation.PushAsync(new ViewCalculatorAdultDsTbDosagePhase()
                    {
                        BindingContext = new CalculatorAdultDsTbDosageView()
                    }, true);
                    break;
                case ItemCalculatorType.AdultIsoniazidePreventiveTherapy:
                    await page.Navigation.PushAsync(new ViewCalculatorAdultIsoniazidePreventiveTherapyArtTreatment()
                    {
                        BindingContext = new CalculatorAdultIsoniazidePreventiveTherapyView()
                    }, true);
                    break;
                case ItemCalculatorType.PaediatricDsTbDosages:
                    await page.Navigation.PushAsync(new ViewCalculatorPaediatricDsTbDosageCategory()
                    {
                        BindingContext = new CalculatorPaediatricDsTbDosageView()
                    }, true);
                    break;
                case ItemCalculatorType.PaediatricIsoniazidePreventiveTherapy:
                    await page.Navigation.PushAsync(new ViewCalculatorPaediatricIsoniazidePreventiveTherapyWeightGroup()
                    {
                        BindingContext = new CalculatorPaediatricIsoniazidePreventiveTherapyView()
                    }, true);
                    break;
                case ItemCalculatorType.Bmi:
                    await page.Navigation.PushAsync(new ViewCalculatorBmi()
                    {
                        BindingContext = new CalculatorBmiView()
                    }, true);
                    break;
                case ItemCalculatorType.TbTreatmentFollowUpDates:
                    await page.Navigation.PushAsync(new ViewCalculatorTbTreatmentFollowUpDateTreatmentDate()
                    {
                        BindingContext = new CalculatorTbTreatmentFollowUpDateView(itemCalculator)
                    }, true);
                    break;
                case ItemCalculatorType.MdrTreatmentFollowUpDates:
                    await page.Navigation.PushAsync(new ViewCalculatorMdrTreatmentFollowUpDateTreatmentDate()
                    {
                        BindingContext = new CalculatorMdrTreatmentFollowUpDateView(itemCalculator)
                    }, true);
                    break;
                case ItemCalculatorType.DrugInteraction:
                    await page.Navigation.PushAsync(new ViewCalculatorDrugInteractionEdl()
                    {
                        BindingContext = new CalculatorDrugInteractionView()
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
            }
            
            return true;
        }

        private class SplashScreen
        {
            public Image TopDoh { get; set; }

            public Xamarin.Forms.Label MiddleLabel1 { get; set; }

            public Xamarin.Forms.Label MiddleLabel2 { get; set; }

            public Image BottomMetropolitan { get; set; }

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
                Source = ImageSource.FromResource("PCL.Tb.Assets.ic_logo_doh.png"), HorizontalOptions = LayoutOptions.Center, HeightRequest = PCL.App.ScreenSize.Height*0.2, WidthRequest = PCL.App.ScreenSize.Width, Aspect = Aspect.AspectFit,
            };

            stackLayoutTop.Children.Add(this.SplashScreenView.TopDoh);

            // MIDDLE
            stackLayoutYMiddle = 0.45;

            this.SplashScreenView.MiddleLabel1 = new Xamarin.Forms.Label()
            {
                Text = TbResources.SplashTextLine1, HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 20, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center,
            };

            this.SplashScreenView.MiddleLabel2 = new Xamarin.Forms.Label()
            {
                Text = TbResources.SplashTextLine2, HorizontalOptions = LayoutOptions.FillAndExpand, FontAttributes = FontAttributes.Bold, FontSize = 20, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center,
            };

            stackLayoutMiddle.Children.Add(this.SplashScreenView.MiddleLabel1);
            stackLayoutMiddle.Children.Add(this.SplashScreenView.MiddleLabel2);

            // BOTTOM
            stackLayoutYBottom = 0.7;

            this.SplashScreenView.BottomMetropolitan = new Image()
            {
                Source = ImageSource.FromResource("PCL.Tb.Assets.ic_logo_metropolitan.png"), HorizontalOptions = LayoutOptions.Center, HeightRequest = PCL.App.ScreenSize.Height*0.08, Aspect = Aspect.AspectFit,
            };

            this.SplashScreenView.BottomSpace = new StackLayout()
            {
                HorizontalOptions = LayoutOptions.FillAndExpand, HeightRequest = PCL.App.ScreenSize.Height*0.05, WidthRequest = PCL.App.ScreenSize.Width,
            };

            this.SplashScreenView.BottomTOMPSA = new Image()
            {
                Source = ompSource, HorizontalOptions = LayoutOptions.Center, HeightRequest = PCL.App.ScreenSize.Height*0.07, WidthRequest = PCL.App.ScreenSize.Width, Aspect = Aspect.AspectFit,
            };

            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomMetropolitan);
            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomSpace);
            stackLayoutBottom.Children.Add(this.SplashScreenView.BottomTOMPSA);
        }

        public void SplashScreenSizeAllocated()
        {
            this.SplashScreenView.TopDoh.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.TopDoh.HeightRequest = PCL.App.ScreenSize.Height*0.2;

            this.SplashScreenView.MiddleLabel1.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.MiddleLabel2.WidthRequest = PCL.App.ScreenSize.Width;

            this.SplashScreenView.BottomMetropolitan.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.BottomMetropolitan.HeightRequest = PCL.App.ScreenSize.Height*0.08;

            this.SplashScreenView.BottomSpace.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.BottomSpace.HeightRequest = PCL.App.ScreenSize.Height*0.05;

            this.SplashScreenView.BottomTOMPSA.WidthRequest = PCL.App.ScreenSize.Width;
            this.SplashScreenView.BottomTOMPSA.HeightRequest = PCL.App.ScreenSize.Height*0.07;
        }
    }
}