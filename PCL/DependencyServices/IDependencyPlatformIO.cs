using System;
using System.IO;
using PCL.Services;

namespace PCL.DependencyServices
{
    public interface IDependencyPlatformIO
    {
        String GetFileContent(String path);
        String ExternalApplicationDirectory();
        String ExternalApplicationDirectoryForWebView();
        void ClearDirectory(String path);
        void SaveFile(UpdateContentService updateContentService, Stream stream, String location);
        void Unzip(UpdateContentService updateContentService, String zipFile, String extractLocation);
        Stream FileRead(String fileName);
        Stream FileCreate(String fileName);
    }
}