using System;
using Foundation;
using PCL;
using UIKit;
using Xamarin.Forms.Platform.iOS;

namespace iOS.Tb
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        private UIWindow Window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            iOSClassLibrary.Init(this.Window);

            PCL.Tb.IncludeMe.Include = true;

            this.LoadApplication(new App());

            Boolean baseFinishedLaunching = base.FinishedLaunching(app, options);

            iOSClassLibrary.InitSharedApplication(app);

            return baseFinishedLaunching;
        }
    }
}