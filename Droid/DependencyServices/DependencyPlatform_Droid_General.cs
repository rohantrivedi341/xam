using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Android;
using Android.App;
using Android.Content.PM;
using Android.Support.V4.App;
using Android.Support.V4.Content;
using Droid.DependencyServices;
using PCL;
using PCL.DependencyServices;
using PCL.UI.Helpers;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_Droid_General))]

namespace Droid.DependencyServices
{
    public class DependencyPlatform_Droid_General : IDependencyPlatformGeneral
    {
        public Int32 GetBuildNumber()
        {
            return Forms.Context.PackageManager.GetPackageInfo(Forms.Context.PackageName, 0).VersionCode;
        }

        public String GetDbPath()
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), App.CurrentInstance.DependencyApplicationGeneral.GetDatabaseName());
        }
        
        //public void HandlePermissions(TaskCompletionSource<Boolean> taskCompletionSource)
        //{
        //    ((BaseActivity)Forms.Context).PermissionsTaskCompletionSource = taskCompletionSource;
        //    ((BaseActivity)Forms.Context).HandlePermissions();
        //}
    }
}