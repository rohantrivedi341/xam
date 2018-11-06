using System;
using PCL.Database;
using PCL.DependencyServices;
using PCL.DohReporting.DependencyServices;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyApplicationDohReportingGeneral))]

namespace PCL.DohReporting.DependencyServices
{
    public class DependencyApplicationDohReportingGeneral : IDependencyApplicationGeneral
    {
#if DEBUG
        private const String BACKEND_URL = "http://mobileguidelines-test.azurewebsites.net/doh-reporting/";
#else
        private const String BACKEND_URL = "http://mobileguidelines.azurewebsites.net/doh-reporting/";
#endif

        public string GetApplicationName()
        {
#if DEBUG
            return "DEBUG - " + DohReportingResources.ApplicationName;
#else
            return DohReportingResources.ApplicationName;
#endif
        }

        public string GetApplicationVersion()
        {
            return "0.1";
        }

        public string GetGoogleAnalyticsTrackerId()
        {
            return "UA-46803204-10";
        }

        public string GetDatabaseName()
        {
            return "omp.guidance.doh-reporting.db3";
        }

        public SQLiteConnectionDatabase GetDatabase(String dbPath)
        {
            return new SQLiteConnectionDatabase(dbPath);
        }

        public String GetBackendUrlLastest()
        {
            return DependencyApplicationDohReportingGeneral.BACKEND_URL + "latest.json";
        }

        public String GetBackendUrlContent()
        {
            return DependencyApplicationDohReportingGeneral.BACKEND_URL + "content/{0}.zip";
        }
    }
}