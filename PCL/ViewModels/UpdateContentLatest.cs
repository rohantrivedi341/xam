using System;
using Newtonsoft.Json;

namespace PCL.ViewModels
{
    public class UpdateContentLatest
    {
        [JsonProperty("application_version")]
        public Int32 ApplicationVersion { get; set; }

        [JsonProperty("content_version")]
        public Int32 ContentVersion { get; set; }

        [JsonProperty("store")]
        public UpdateContentLatestStore Store { get; set; }
    }
}