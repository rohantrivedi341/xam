using PCL.DependencyServices;
using PCL.Hiv.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationHivStyle))]

namespace PCL.Hiv.DependencyServices
{
    public class DependencyApplicationHivStyle : IDependencyApplicationStyle
    {
        public Color GetColorAccent()
        {
            return Color.FromHex("#E01F16");
        }

        public Color GetColorPrimary()
        {
            return Color.FromHex("#005D28");
        }

        public Color GetColorPrimaryDark()
        {
            return Color.FromHex("#014D22");
        }
    }
}