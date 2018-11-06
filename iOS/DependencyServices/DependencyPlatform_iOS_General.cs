using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using iOS.DependencyServices;
using PCL;
using PCL.DependencyServices;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_iOS_General))]

namespace iOS.DependencyServices
{
    public class DependencyPlatform_iOS_General : IDependencyPlatformGeneral
    {
        public Int32 GetBuildNumber()
        {
            return Int32.Parse(NSBundle.MainBundle.InfoDictionary[new NSString("CFBundleVersion")].ToString());
        }

        public String GetDbPath()
        {
			return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "..", "Library", App.CurrentInstance.DependencyApplicationGeneral.GetDatabaseName());
        }

        //public void HandlePermissions(TaskCompletionSource<Boolean> taskCompletionSource)
        //{
        //    taskCompletionSource.SetResult(true);
        //}
    }
}