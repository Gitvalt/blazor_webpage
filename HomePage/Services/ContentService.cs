using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using SharedModels;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HomePage.Services
{
    public class ContentService
    {
        public ContentService(HttpClient httpClient, Services.LocalJSCallerManager jsCaller, Services.JsonContentLocalizationService jsonLocalization, IStringLocalizer<App> contentLocalization)
        {
            if (httpClient is null)
            {
                throw new ArgumentNullException(nameof(httpClient));
            }

            if (jsCaller is null)
            {
                throw new ArgumentNullException(nameof(jsCaller));
            }

            if (jsonLocalization is null)
            {
                throw new ArgumentNullException(nameof(jsonLocalization));
            }

            if (contentLocalization is null)
            {
                throw new ArgumentNullException(nameof(contentLocalization));
            }

            HttpClient = httpClient;
            JsCaller = jsCaller;
            JsonLocalization = jsonLocalization;
            ContentLocalization = contentLocalization;
        }

        public HttpClient HttpClient { get; }
        public LocalJSCallerManager JsCaller { get; }
        public JsonContentLocalizationService JsonLocalization { get; }
        public IStringLocalizer<App> ContentLocalization { get; }

        public async Task<ProfileContentModel> LoadProfileData()
        {
            try
            {
                var locale = await JsCaller.GetLocale();

                var request = await JsonLocalization.GetContentForContext<ProfileContentModel>(HttpClient, locale);

                if (request.HasError)
                {
                    return new ProfileContentModel() { Error = new ErrorModel(request.Error) };
                }
                else if (request.Content == default(ProfileContentModel))
                {
                    return new ProfileContentModel() { Error = new ErrorModel(ContentLocalization.GetString("ContentLoadingFailed")) };
                }
                else
                {
                    if (request?.Content?.Projects?.Any() ?? false)
                    {
                        foreach (var item in request.Content.Projects)
                        {
                            item.DecodeData();
                        }
                    }

                    return request.Content;
                }
            }
            catch (Exception e)
            {
                return new ProfileContentModel()
                {
                    Error = new ErrorModel(string.Format(ContentLocalization.GetString("UnexpectedErrorFormat"), $"{e.Message}, {e.StackTrace}")),
                };
            }
        }
    }
}