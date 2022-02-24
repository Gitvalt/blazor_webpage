using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharedModels
{
    public class ProfileContentModel
    {
        [JsonIgnore]
        public bool HasError
        { get => Error?.HasError ?? false; set { } }

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

        [JsonProperty(PropertyName = "projects")]
        public ProjectWrapper[] Projects { get; set; }

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

    public enum ProjectType
    {
        Default = 0,
        Personal = 1,
        Work = 2,
        School = 3,
    }

    public abstract class BaseProject : IBaseProject
    {
        private string[] _tags;

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "desc")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "tags", NullValueHandling = NullValueHandling.Ignore)]
        public string[] Tags { get => _tags ?? new string[] { }; set => _tags = value; }

        [JsonProperty(PropertyName = "created", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? CreatedDate { get; set; }

        [JsonProperty(PropertyName = "typeid")]
        public int ProjectTypeID { get; set; }

        [JsonProperty(PropertyName = "project_images", NullValueHandling = NullValueHandling.Ignore)]
        public Image[] Images { get; set; }

        [JsonProperty(PropertyName = "data", NullValueHandling = NullValueHandling.Ignore)]
        public string Data { get; set; }

        [JsonProperty(PropertyName = "ext_link", NullValueHandling = NullValueHandling.Ignore)]
        public Hyperlink ExternalLink { get; set; }

        protected BaseProject()
        {
            ExternalLink = ExternalLink ?? new Hyperlink();
        }

        public virtual void DecodeData()
        { }

        public virtual void EncodeData()
        { }
    }

    public class ProjectWrapper : BaseProject
    {
        public class SchoolDataModel
        {
            [JsonProperty(PropertyName = "group_size")]
            public int GroupSize { get; set; }
        }

        [JsonIgnore]
        public Guid TmpID { get; set; }

        [JsonIgnore]
        public SchoolDataModel SchoolParameters { get; set; }

        public ProjectWrapper()
        {
            SchoolParameters = SchoolParameters ?? new SchoolDataModel();
            TmpID = Guid.NewGuid();
        }

        public override void EncodeData()
        {
            var data = new
            {
                school = SchoolParameters,
            };

            Data = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
            });
        }

        public override void DecodeData()
        {
            var data = new
            {
                school = default(SchoolDataModel),
            };

            if (string.IsNullOrEmpty(Data))
                return;

            data = JsonConvert.DeserializeAnonymousType(Data, data);

            SchoolParameters = data?.school;
        }
    }

    public class Hyperlink
    {
        [JsonProperty(PropertyName = "link", NullValueHandling = NullValueHandling.Ignore)]
        public string Link { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
    }
}