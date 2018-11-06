using Xamarin.Forms;

namespace PCL.UI.CustomViews
{
    public class CV_ListView : ListView
    {
        public CV_ListView()
        {
            if (Device.Idiom == TargetIdiom.Tablet)
            {
                this.HasUnevenRows = true;
            }
        }
    }
}