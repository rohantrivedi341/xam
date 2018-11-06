using System;
using Android.Gms.Analytics;
using Droid.DependencyServices;
using PCL;
using PCL.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_Droid_GoogleAnalytics))]

namespace Droid.DependencyServices
{
    public class DependencyPlatform_Droid_GoogleAnalytics : IDependencyPlatformGoogleAnalytics
    {
        private Tracker tracker;

        private Tracker Tracker
        {
            get
            {
                if (this.tracker == null)
                {
                    this.tracker = GoogleAnalytics.GetInstance(Forms.Context).NewTracker(App.CurrentInstance.DependencyApplicationGeneral.GetGoogleAnalyticsTrackerId());
                    this.tracker.SetAppVersion(App.CurrentInstance.DependencyApplicationGeneral.GetApplicationVersion());
                }

                return this.tracker;
            }
        }

        public void LogScreen(String name)
        {
#if !DEBUG
            this.Tracker.SetScreenName(name);
            this.Tracker.Send(new HitBuilders.ScreenViewBuilder().Build());
#endif
        }
    }
}