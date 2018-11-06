using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.OS;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Android.Util;
using PCL;
using PCL.Services;
using PCL.UI.Helpers;
using Xamarin;
using Xamarin.Forms;

namespace Droid
{
    public class BaseActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity, ActivityCompat.IOnRequestPermissionsResultCallback
    {
        public TaskCompletionSource<Boolean> PermissionsTaskCompletionSource;
        public Boolean PermissionsAsked;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Forms.Init(this, bundle);
            FormsMaps.Init(this, bundle);

            this.DetermineScreenSize();
        }

        public override void OnConfigurationChanged(Configuration newConfig)
        {
            base.OnConfigurationChanged(newConfig);

            this.DetermineScreenSize();
        }

        public void OnRequestPermissionsResult(Int32 requestCode, String[] permissions, Permission[] grantResults)
        {
            this.HandlePermissions();
        }

        private void DetermineScreenSize()
        {
            App.ScreenSize = new Rectangle(0, 0, this.Resources.DisplayMetrics.WidthPixels / this.Resources.DisplayMetrics.Density, this.Resources.DisplayMetrics.HeightPixels / this.Resources.DisplayMetrics.Density);
        }

        public void HandlePermissions()
        {
            List<String> notGrantedPermissions = new List<String>();

            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessNetworkState) != Permission.Granted)
                notGrantedPermissions.Add(Manifest.Permission.AccessNetworkState);
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.AccessWifiState) != Permission.Granted)
                notGrantedPermissions.Add(Manifest.Permission.AccessWifiState);
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.Internet) != Permission.Granted)
                notGrantedPermissions.Add(Manifest.Permission.Internet);
            if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
                notGrantedPermissions.Add(Manifest.Permission.WriteExternalStorage);

            if (notGrantedPermissions.Any())
            {
                if (!this.PermissionsAsked)
                {
                    RunOnUiThread(() =>
                                  {
                                      AlertDialog.Builder alert = new AlertDialog.Builder(this);
                                      alert.SetTitle(PCLResources.RequestingPermissions);
                                      alert.SetMessage(PCLResources.RequestingPermissionsMessage);
                                      alert.SetPositiveButton(PCLResources.Next, (sender, args) => ActivityCompat.RequestPermissions(this, notGrantedPermissions.ToArray(), 1));
                                      alert.Show();
                                  });

                    this.PermissionsAsked = true;
                }
                else
                {
                    ActivityCompat.RequestPermissions(this, notGrantedPermissions.ToArray(), 1);
                }
            }
            else
            {
                this.PermissionsTaskCompletionSource.SetResult(true);
            }
        }
    }
}