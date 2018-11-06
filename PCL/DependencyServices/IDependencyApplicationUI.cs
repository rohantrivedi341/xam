using System;
using System.Threading.Tasks;
using PCL.Common;
using Xamarin.Forms;

namespace PCL.DependencyServices
{
    public interface IDependencyApplicationUI
    {
        Task CalculatorStart(Page page, String identifier);
        Task CalculatorStart(Page page, StructureItem structureItem);
        void SplashScreenFill(StackLayout stackLayoutTop, ref Double stackLayoutYTop, StackLayout stackLayoutMiddle, ref Double stackLayoutYMiddle, StackLayout stackLayoutBottom, ref Double stackLayoutYBottom, ImageSource ompSource);
        void SplashScreenSizeAllocated();
    }
}