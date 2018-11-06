using System;
using PCL.Common;
using PCL.UI.CustomViews;

namespace PCL.DependencyServices
{
    public interface IDependencyPlatformOpenExternal
    {
        Boolean Browser(String websiteUrl);
        Boolean Email(String emailAddress = null, String subject = null, String body = null, Attachment attachment = null);
        Boolean Phone(String phoneNumber);
        Boolean Print(String name, CV_WebView webView);
        Boolean Print(String name, Attachment attachment);
    }
}