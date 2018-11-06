using System;
using PCL.DependencyServices;
using PCL.Msf.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationMsfGeneral))]

namespace PCL.Msf.DependencyServices
{
    public class DependencyApplicationMsfGeneral : IDependencyApplicationGeneral
    {
#if DEBUG
        private const String BACKEND_URL = "http://mobileguidelines-test.azurewebsites.net/msf/";
#else
        private const String BACKEND_URL = "http://mobileguidelines.azurewebsites.net/msf/";
#endif

        public string GetApplicationName()
        {
#if DEBUG
            return "DEBUG - " + MsfResources.ApplicationName;
#else
            return MsfResources.ApplicationName;
#endif
        }

        public string GetApplicationVersion()
        {
            return "2.3";
        }

        public string GetGoogleAnalyticsTrackerId()
        {
            return "UA-46803204-3";
        }

        public string GetDatabaseName()
        {
            return "omp.guidance.msf.db3";
        }

        public String GetBackendUrlLastest()
        {
            return DependencyApplicationMsfGeneral.BACKEND_URL + "latest.json";
        }

        public String GetBackendUrlContent()
        {
            return DependencyApplicationMsfGeneral.BACKEND_URL + "content/{0}.zip";
        }
    }
}