using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using HomePage.Services;

namespace HomePage
{
    public class AppSettings
    {
        public bool ShowProjects { get; set; }
    }

    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            AppSettings appSettings = new AppSettings()
            {
                ShowProjects = false
            };

            var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.AcceptEncoding.Add(new System.Net.Http.Headers.StringWithQualityHeaderValue("utf-16"));
            builder.Services.AddSingleton(sp => httpClient);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("fi-FI");
            CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("fi-FI");

            builder.Services.AddLocalization(opts => { opts.ResourcesPath = "Resources"; });
            //builder.Services.AddScoped<IStringLocalizer<App>, StringLocalizer<App>>();
            builder.Services.AddSingleton<StringLocalizer<App>>();
            builder.Services.AddSingleton<LocalJSCallerManager>();
            builder.Services.AddSingleton<LogService>();
            builder.Services.AddSingleton<JsonContentLocalizationService>();
            builder.Services.AddSingleton<ContentService>();
            builder.Services.AddSingleton<AppSettings>(appSettings);

            var host = builder.Build();

            var logger = host.Services.GetService<LogService>();

            try
            {
                // Call "getLanguage" js function on index page
                var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
                var language = await jsInterop.InvokeAsync<string>("getLanguage");

                logger.Debug($"Found locale on startup: {language}");

                var culture = new CultureInfo(language);
                CultureInfo.DefaultThreadCurrentCulture = culture;
                CultureInfo.DefaultThreadCurrentUICulture = culture;
            }
            catch (Exception err)
            {
                logger.Error($"Fetching current localization from browser failed: {err.Message} {err.StackTrace}");
            }

            await host.RunAsync();
        }
    }
}