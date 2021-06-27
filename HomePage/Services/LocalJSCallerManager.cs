using Microsoft.JSInterop;
using SharedModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HomePage.Services
{
    /// <summary>
    /// Call Javascript functions on index.html page.
    /// </summary>
    public class LocalJSCallerManager
    {
        public IJSRuntime Runtime { get; }
        public LogService logService { get; }

        public LocalJSCallerManager(IJSRuntime runtime, LogService _logService)
        {
            Runtime = runtime;
            logService = _logService;
        }

        public async Task<string> GetLocale()
        {
            var a = await Runtime.InvokeAsync<string>("getLanguage");

            if (string.IsNullOrEmpty(a))
            {
                logService?.Debug("Locale could not be fetched. Uses default");
                return "fi";
            }
            else
            {
                var b = new CultureInfo(a, false);
                logService?.Debug($"Current locale is {b.TwoLetterISOLanguageName}");
                return b.TwoLetterISOLanguageName;
            }
        }

        public async Task SetLocale(string newLocale)
        {
            await Runtime.InvokeAsync<string>("setLanguage", newLocale);
            logService?.Debug($"Changed locale. New locale is {newLocale}");
        }
        
        public async Task SetAndRefreshLocale(string newLocale)
        {
            await SetLocale(newLocale);
            logService?.Debug($"Requesting window reload");
            await Runtime.InvokeAsync<string>("location.reload");
        }
        
        public async Task SwitchTheme()
        {
            await Runtime.InvokeAsync<string>("switchTheme");
            logService?.Debug($"Switching page theme"); 
        }
        
        public async Task<string> GetCurrentTheme()
        {
            var theme = await Runtime.InvokeAsync<string>("getCurrentTheme");
            logService?.Debug($"Found current theme: {theme}");
            return theme;
        }

        public async Task<string> GetRecordedTheme()
        {
            var theme = await Runtime.InvokeAsync<string>("readThemeRecord");
            logService?.Debug($"Found recorded theme: {theme}");
            return theme;
        }

        public async Task SetTheme(string theme)
        {
            await Runtime.InvokeAsync<string>("setTheme", theme);
        }
    }
}
