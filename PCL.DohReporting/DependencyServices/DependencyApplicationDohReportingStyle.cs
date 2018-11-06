using PCL.DependencyServices;
using PCL.DohReporting.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationDohReportingStyle))]

namespace PCL.DohReporting.DependencyServices
{
    public class DependencyApplicationDohReportingStyle : IDependencyApplicationStyle
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