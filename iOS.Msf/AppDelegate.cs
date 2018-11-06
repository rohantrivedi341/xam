using System;
using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using PCL;

namespace iOS.Msf
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        private UIWindow Window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSClassLibrary.Init(this.Window);

            PCL.Msf.IncludeMe.Include = true;

            this.LoadApplication(new App());

            Boolean baseFinishedLaunching = base.FinishedLaunching(app, options);

            iOSClassLibrary.InitSharedApplication(app);

            return baseFinishedLaunching;
        }
    }
}