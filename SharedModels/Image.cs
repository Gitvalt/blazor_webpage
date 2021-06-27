using Newtonsoft.Json;
using System;

namespace SharedModels
{
    [Serializable]
    public class Image
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }
        
        [JsonProperty(PropertyName = "alt")]
        public string Alt { get; set; }

        [JsonProperty(PropertyName = "is_icon")]
        public bool IsIcon { get; set; }

        [JsonProperty(PropertyName = "link")]
        public string Hyperlink { get; set; }

        [JsonIgnore]
        public bool HasHyperlink { get => string.IsNullOrEmpty(Hyperlink) == false; set { } }
    }
}
