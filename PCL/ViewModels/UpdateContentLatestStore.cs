using System;
using Newtonsoft.Json;

namespace PCL.ViewModels
{
    public class UpdateContentLatestStore
    {
        [JsonProperty("android")]
        public DateTime? Android { get; set; }

        [JsonProperty("ios")]
        public DateTime? iOS { get; set; }

        [JsonProperty("windows_phone")]
        public DateTime? WindowsPhone { get; set; }
    }
}