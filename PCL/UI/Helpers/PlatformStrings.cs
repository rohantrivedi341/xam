using System;
using Xamarin.Forms;

namespace PCL.UI.Helpers
{
    public static class PlatformStrings
    {
        public static String GetApplicationUpdateAvailable()
        {
            String text = String.Empty;

            switch (Device.OS)
            {
                case TargetPlatform.Other:
                    break;
                case TargetPlatform.iOS:
                    text = PCLResources.ApplicationUpdateAvailable_iOS;
                    break;
                case TargetPlatform.Android:
                    text = PCLResources.ApplicationUpdateAvailable_Android;
                    break;
                case TargetPlatform.WinPhone:
                    break;
                case TargetPlatform.Windows:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return text;
        }

        public static String GetApplicationUpdateRequired()
        {
            String text = String.Empty;

            switch (Device.OS)
            {
                case TargetPlatform.Other:
                    break;
                case TargetPlatform.iOS:
                    text = PCLResources.ApplicationUpdateRequired_iOS;
                    break;
                case TargetPlatform.Android:
                    text = PCLResources.ApplicationUpdateRequired_Android;
                    break;
                case TargetPlatform.WinPhone:
                    break;
                case TargetPlatform.Windows:
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return text;
        }
    }
}