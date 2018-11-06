using Xamarin.Forms;

namespace PCL.DependencyServices
{
    public interface IDependencyApplicationStyle
    {
        Color GetColorAccent();
        Color GetColorPrimary();
        Color GetColorPrimaryDark();
    }
}