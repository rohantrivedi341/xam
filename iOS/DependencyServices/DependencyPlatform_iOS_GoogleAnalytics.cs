using System;
using GoogleAnalytics.iOS;
using iOS.DependencyServices;
using PCL;
using PCL.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_iOS_GoogleAnalytics))]

namespace iOS.DependencyServices
{
    public class DependencyPlatform_iOS_GoogleAnalytics : IDependencyPlatformGoogleAnalytics
    {
        private IGAITracker tracker;

        private IGAITracker Tracker
        {
            get
            {
                if (this.tracker == null)
                {
                    this.tracker = GAI.SharedInstance.GetTracker(App.CurrentInstance.DependencyApplicationGeneral.GetGoogleAnalyticsTrackerId());
                    this.tracker.Set(GAIConstants.AppVersion, App.CurrentInstance.DependencyApplicationGeneral.GetApplicationVersion());
                }

                return this.tracker;
            }
        }

        public void LogScreen(String name)
        {
#if !DEBUG
            this.Tracker.Set(GAIConstants.ScreenName, name);
            this.Tracker.Send(GAIDictionaryBuilder.CreateScreenView().Build());
#endif
        }
    }
}