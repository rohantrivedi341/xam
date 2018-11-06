using PCL.DependencyServices;
using PCL.Phc.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationPhcStyle))]

namespace PCL.Phc.DependencyServices
{
    public class DependencyApplicationPhcStyle : IDependencyApplicationStyle
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