using System;
using System.IO;
using System.IO.Compression;
using Foundation;
using iOS.DependencyServices;
using PCL;
using PCL.DependencyServices;
using PCL.Services;
using PCL.UI.Helpers;
using Xamarin.Forms;

[assembly: Dependency(typeof (DependencyPlatform_iOS_IO))]

namespace iOS.DependencyServices
{
    public class DependencyPlatform_iOS_IO : IDependencyPlatformIO
    {
        public String GetFileContent(String path)
        {
            return File.ReadAllText(path);
        }

        public String ExternalApplicationDirectory()
        {
            return Path.Combine(NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User)[0].Path, "Content") + "/";
        }
        
        public String ExternalApplicationDirectoryForWebView()
        {
            return String.Format("file://{0}", this.ExternalApplicationDirectory());
        }

        public void ClearDirectory(String path)
        {
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }

            Directory.CreateDirectory(path);
        }

        public void SaveFile(UpdateContentService updateContentService, Stream stream, String location)
        {
            Double receivedBytes = 0;

            Int32 oldPercentage = -1;

            using (Stream zipFile = File.Create(location))
            {
                Byte[] buffer = new Byte[1024];

                Int32 currentReadLength;

                while ((currentReadLength = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    zipFile.Write(buffer, 0, currentReadLength);

                    receivedBytes += currentReadLength;

                    Int32 percentage = (Int32) (receivedBytes/stream.Length*100.0);

                    if (percentage == oldPercentage)
                    {
                        continue;
                    }

                    MessagingCenter.Send(updateContentService, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateDownloading, String.Format(PCLResources.ProgressPercentage, percentage)));

                    oldPercentage = percentage;
                }
            }
        }

        public void Unzip(UpdateContentService updateContentService, String zipFile, String extractLocation)
        {
            using (ZipArchive zip = ZipFile.Open(zipFile, ZipArchiveMode.Read))
            {
                Double amountOfEntries = zip.Entries.Count;

                Int32 extractedEntries = 0;

                Int32 oldPercentage = -1;

                foreach (ZipArchiveEntry entry in zip.Entries)
                {
                    extractedEntries++;

                    try
                    {
                        String fullName = Path.Combine(extractLocation, entry.FullName);

                        if (String.IsNullOrEmpty(entry.Name))
                        {
                            Directory.CreateDirectory(fullName);
                        }
                        else
                        {
                            entry.ExtractToFile(fullName);
                        }
                    }
                    catch (Exception e)
                    {
                    }

                    Int32 percentage = (Int32) (extractedEntries/amountOfEntries*100.0);

                    if (percentage == oldPercentage)
                    {
                        continue;
                    }

                    MessagingCenter.Send(updateContentService, MessagingCenterConstants.UpdateContentService, new MessagingCenterMessage(MessagingCenterConstants.UpdateContentServiceRequestContentUpdateExtracting, String.Format(PCLResources.ProgressPercentage, percentage)));

                    oldPercentage = percentage;
                }
            }
        }

        public Stream FileRead(String fileName)
        {
            return File.Open(fileName, FileMode.Open);
        }

        public Stream FileCreate(String fileName)
        {
            return File.Open(fileName, FileMode.Create);
        }
    }
}