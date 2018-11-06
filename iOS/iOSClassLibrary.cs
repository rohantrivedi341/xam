using Foundation;
using iOS.DependencyServices;
using PCL;
using UIKit;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace iOS
{
    public static class iOSClassLibrary
    {
        public static void Init(UIWindow window)
        {
            Forms.Init();
            FormsMaps.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);

            App.ScreenSize = new Rectangle();
            App.ScreenSize.Height = UIScreen.MainScreen.Bounds.Height;
            App.ScreenSize.Width = UIScreen.MainScreen.Bounds.Width;
        }

		public static void InitSharedApplication(UIApplication app)
        {
            UIApplication.SharedApplication.KeyWindow.TintColor = App.CurrentInstance.DependencyApplicationStyle.GetColorPrimaryDark().ToUIColor();
            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);
            UIApplication.SharedApplication.SetStatusBarHidden(false, false);

            UIDevice.Notifications.ObserveOrientationDidChange(iOSClassLibrary.ObserveOrientationDidChangeHandler);
        }

        private static void ObserveOrientationDidChangeHandler(object s, NSNotificationEventArgs e)
        {
            App.ScreenSize = new Rectangle();
            App.ScreenSize.Height = UIScreen.MainScreen.Bounds.Height;
            App.ScreenSize.Width = UIScreen.MainScreen.Bounds.Width;
        }
    }
}