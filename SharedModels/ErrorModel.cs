using Newtonsoft.Json;

namespace SharedModels
{
    public class ErrorModel
    {
        [JsonIgnore]
        public bool HasError { get => string.IsNullOrEmpty(LocalizedError) == false; set { } }

        [JsonIgnore]
        public string LocalizedError { get; set; }

        public ErrorModel(string localizedError)
        {
            LocalizedError = localizedError;
        }
    }
}
