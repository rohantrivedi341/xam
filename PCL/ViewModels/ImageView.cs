using System;
using PCL.Common;

namespace PCL.ViewModels
{
    public class ImageView
    {
        public String Title { get; set; }

        public String Location { get; set; }

        private ImageView(String title, String location)
        {
            this.Title = title;
            this.Location = location;
        }

        public static ImageView Create(Section section, String title, String url)
        {
            return new ImageView(title, String.Format("{0}/{1}/content/{2}", App.CurrentInstance.DependencyPlatformIO.ExternalApplicationDirectoryForWebView(), section.Location, url));
        }
    }
}