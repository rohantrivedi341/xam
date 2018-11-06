using System;
using PCL.DependencyServices;
using PCL.Hiv.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationHivGeneral))]

namespace PCL.Hiv.DependencyServices
{
    public class DependencyApplicationHivGeneral : IDependencyApplicationGeneral
    {
#if DEBUG
        private const String BACKEND_URL = "http://mobileguidelines-test.azurewebsites.net/hiv/";
#else
        private const String BACKEND_URL = "http://mobileguidelines.azurewebsites.net/hiv/";
#endif

        public String GetApplicationName()
        {
#if DEBUG
            return "DEBUG - " + HivResources.ApplicationName;
#else
            return HivResources.ApplicationName;
#endif
        }

        public string GetApplicationVersion()
        {
            return "2.10";
        }

        public string GetGoogleAnalyticsTrackerId()
        {
            return "UA-46803204-5";
        }

        public String GetDatabaseName()
        {
            return "omp.guidance.hiv.db3";
        }

        public String GetBackendUrlLastest()
        {
            return DependencyApplicationHivGeneral.BACKEND_URL + "latest.json";
        }

        public String GetBackendUrlContent()
        {
            return DependencyApplicationHivGeneral.BACKEND_URL + "content/{0}.zip";
        }
    }
}