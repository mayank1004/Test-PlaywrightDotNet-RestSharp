using System;
using System.Threading.Tasks;
using E2ETestCSharp.Utils.Enums;
using Microsoft.Playwright;

namespace E2ETestCSharp.Utils
{
    public class BrowserManager
    {
        public BrowserManager()
        {
        }

        public async Task<IBrowser> LaunchBrowserAsync(IPlaywright playwright, BrowserTypeEnum browserTypeEnum, bool isHeadless, float slowMoTime)
        {
            switch (browserTypeEnum)
            {
                case BrowserTypeEnum.CHROMIUM:
                    return await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = isHeadless,
                        SlowMo = slowMoTime,
                    });
                case BrowserTypeEnum.FIREFOX:
                    return await playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = isHeadless,
                        SlowMo = slowMoTime,
                    });
                default:
                    return await playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions
                    {
                        Headless = isHeadless,
                        SlowMo = slowMoTime,
                    });
            }
        }
    }
}
