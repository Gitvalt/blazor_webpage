using Microsoft.Extensions.Localization;
using Newtonsoft.Json;
using System;
using System.Globalization;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace HomePage.Services
{
    /// <summary>
    /// Service that reads profile content from json
    /// </summary>
    public class JsonContentLocalizationService
    {
        private readonly IStringLocalizer<App> localizers;

        private readonly LogService logService;

        public JsonContentLocalizationService()
        {
        }

        public JsonContentLocalizationService(StringLocalizer<App> localizers, LogService logService)
        {
            this.localizers = localizers;
            this.logService = logService;
        }

        public enum Locales
        {
            fi,
            en,
        }

        public async Task<LocaleRespone<T>> GetContentForContext<T>(HttpClient client, string locale) where T : class
        {
            string path = "";

            var culture = new CultureInfo(locale, false);

            switch (culture?.TwoLetterISOLanguageName.ToLower())
            {
                case "fi":
                    path = GetProfilePath(Locales.fi);
                    break;

                case "ena":
                case "en":
                    path = GetProfilePath(Locales.en);
                    break;
            }

            if (string.IsNullOrEmpty(path))
            {
                return new LocaleRespone<T>(localizers.GetString("NotFound"));
            }
            else
            {
                try
                {
                    var a = await client.GetStringAsync(path);
                    var b = JsonConvert.DeserializeObject<T>(a);
                    return new LocaleRespone<T>(b);
                }
                catch (Exception e)
                {
                    return new LocaleRespone<T>(string.Format(localizers.GetString("UnexpectedErrorFormat"), e.Message));
                }
            }
        }

        private static string GetProfilePath(Locales locale)
        {
            return locale switch
            {
                Locales.fi => "strings/fi-FI.json",
                Locales.en => "strings/en-EN.json",
                _ => null,
            };
        }

        public class LocaleRespone<T>
        {
            public LocaleRespone(string error)
            {
                Error = error;
            }

            public LocaleRespone(T content)
            {
                Content = content;
            }

            public T Content { get; set; }

            public string Error { get; set; }

            public bool HasError
            { get => string.IsNullOrEmpty(Error) == false; set { } }
        }
    }
}