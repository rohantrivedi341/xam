using Android.App;
using Android.Content.PM;
using Android.OS;
using PCL;

namespace Droid.Phc
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            PCL.Phc.IncludeMe.Include = true;

            this.LoadApplication(new App());
        }
    }
}