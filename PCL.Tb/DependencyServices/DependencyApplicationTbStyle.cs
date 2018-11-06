using PCL.DependencyServices;
using PCL.Tb.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationTbStyle))]

namespace PCL.Tb.DependencyServices
{
    public class DependencyApplicationTbStyle : IDependencyApplicationStyle
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