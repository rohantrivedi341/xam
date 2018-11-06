using System;
using PCL.DependencyServices;
using PCL.Tb.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationTbGeneral))]

namespace PCL.Tb.DependencyServices
{
    public class DependencyApplicationTbGeneral : IDependencyApplicationGeneral
    {
#if DEBUG
        private const String BACKEND_URL = "http://mobileguidelines-test.azurewebsites.net/tb/";
#else
        private const String BACKEND_URL = "http://mobileguidelines.azurewebsites.net/tb/";
#endif

        public String GetApplicationName()
        {
#if DEBUG
            return "DEBUG - " + TbResources.ApplicationName;
#else
            return TbResources.ApplicationName;
#endif
        }

        public string GetApplicationVersion()
        {
            return "1.0";
        }

        public string GetGoogleAnalyticsTrackerId()
        {
            return "UA-46803204-11";
        }

        public String GetDatabaseName()
        {
            return "omp.guidance.tb.db3";
        }

        public String GetBackendUrlLastest()
        {
            return DependencyApplicationTbGeneral.BACKEND_URL + "latest.json";
        }

        public String GetBackendUrlContent()
        {
            return DependencyApplicationTbGeneral.BACKEND_URL + "content/{0}.zip";
        }
    }
}