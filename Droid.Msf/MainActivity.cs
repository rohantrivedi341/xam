using Android.App;
using Android.Content.PM;
using Android.OS;
using PCL;

namespace Droid.Msf
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            PCL.Msf.IncludeMe.Include = true;

            this.LoadApplication(new App());
        }
    }
}