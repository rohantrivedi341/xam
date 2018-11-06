using System;
using System.IO;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using PCL;

namespace Droid.Tb
{
    [Activity(MainLauncher = true, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            PCL.Tb.IncludeMe.Include = true;

            this.LoadApplication(new App());
        }
    }
}