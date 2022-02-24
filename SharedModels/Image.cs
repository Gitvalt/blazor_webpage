using Newtonsoft.Json;
using System;

namespace SharedModels
{
    [Serializable]
    public class Image
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        
        [JsonProperty(PropertyName = "alt", NullValueHandling = NullValueHandling.Ignore)]
        public string Alt { get; set; }

        [JsonProperty(PropertyName = "is_icon", NullValueHandling = NullValueHandling.Ignore)]
        public bool IsIcon { get; set; }

        [JsonProperty(PropertyName = "link", NullValueHandling = NullValueHandling.Ignore)]
        public string Hyperlink { get; set; }

        [JsonIgnore]
        public bool HasHyperlink { get => string.IsNullOrEmpty(Hyperlink) == false; set { } }
    }
}
