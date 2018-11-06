using PCL.DependencyServices;
using PCL.Msf.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationMsfStyle))]

namespace PCL.Msf.DependencyServices
{
    public class DependencyApplicationMsfStyle : IDependencyApplicationStyle
    {
        public Color GetColorAccent()
        {
            return Color.FromHex("#eb1f28");
        }

        public Color GetColorPrimary()
        {
            return Color.FromHex("#e2001a");
        }

        public Color GetColorPrimaryDark()
        {
            return Color.FromHex("#eb1f28");
        }
    }
}