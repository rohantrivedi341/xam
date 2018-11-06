using System;

namespace PCL.DependencyServices
{
    public interface IDependencyApplicationGeneral
    {
        String GetApplicationName();
        String GetApplicationVersion();
        String GetGoogleAnalyticsTrackerId();
        String GetDatabaseName();
        String GetBackendUrlLastest();
        String GetBackendUrlContent();
    }
}