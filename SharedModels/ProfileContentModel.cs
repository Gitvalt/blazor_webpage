using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModels
{
    public class ProfileContentModel
    {
        [JsonIgnore]
        public bool HasError { get => Error?.HasError ?? false; set { } }

        [JsonIgnore]
        public ErrorModel Error { get; set; }

        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }
        
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }
        
        [JsonProperty(PropertyName = "profile_image")]
        public Image ProfileImage { get; set; }

        [JsonProperty(PropertyName = "links")]
        public ExternalLink[] ExternalLinks { get; set; }
        
        [JsonProperty(PropertyName = "skills")]
        public Skill[] Skills { get; set; }
        
        [JsonProperty(PropertyName = "experiences")]
        public Experience[] Experiences { get; set; }

        [JsonProperty(PropertyName = "educations")]
        public Education[] Educations { get; set; }

        [JsonConstructor]
        public ProfileContentModel()
        {
        }
    }

    public class ExternalLink
    {
        [JsonProperty(PropertyName = "logo")]
        public Image Logo { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        public ExternalLink()
        {
        }
    }

    public class Skill
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "values")]
        public string[] Values { get; set; }
    }

    public class Experience
    {
        [JsonProperty(PropertyName = "company")]
        public string Company { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "starts")]
        public int? Start { get; set; }

        [JsonProperty(PropertyName = "ends")]
        public int? End { get; set; }
    }

    public class Education
    {
        [JsonProperty(PropertyName = "school")]
        public string School { get; set; }
        
        [JsonProperty(PropertyName = "loc")]
        public string Location { get; set; }
        
        [JsonProperty(PropertyName = "duration")]
        public string Duration { get; set; }
        
        [JsonProperty(PropertyName = "order")]
        public int? Order { get; set; }
        
        [JsonProperty(PropertyName = "degree")]
        public string Degree { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }
    }
}
