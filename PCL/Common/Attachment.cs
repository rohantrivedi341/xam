using System;

namespace PCL.Common
{
    public class Attachment
    {
        public String Path { get; set; }
        public String Extension { get; set; }
        public String FileName { get; set; }

        public Attachment(String path, String extension, String fileName)
        {
            this.Path = path;
            this.Extension = extension;
            this.FileName = fileName;
        }
    }
}
