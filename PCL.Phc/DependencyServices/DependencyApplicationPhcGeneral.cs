using System;
using PCL.DependencyServices;
using PCL.Phc.DependencyServices;
using PCL.Phc.Repository;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationPhcGeneral))]

namespace PCL.Phc.DependencyServices
{
    public class DependencyApplicationPhcGeneral : IDependencyApplicationGeneral
    {
#if DEBUG
        private const String BACKEND_URL = "http://mobileguidelines-test.azurewebsites.net/phc/";
#else
        private const String BACKEND_URL = "http://mobileguidelines.azurewebsites.net/phc/";
#endif

        public string GetApplicationName()
        {
#if DEBUG
            return "DEBUG - " + PhcResources.ApplicationName;
#else
            return PhcResources.ApplicationName;
#endif
        }

        public string GetApplicationVersion()
        {
            return "2.4";
        }

        public string GetGoogleAnalyticsTrackerId()
        {
            return "UA-46803204-9";
        }

        public string GetDatabaseName()
        {
            return "omp.guidance.phc.db3";
        }

        public String GetBackendUrlLastest()
        {
            return DependencyApplicationPhcGeneral.BACKEND_URL + "latest.json";
        }

        public String GetBackendUrlContent()
        {
            return DependencyApplicationPhcGeneral.BACKEND_URL + "content/{0}.zip";
        }
    }
}