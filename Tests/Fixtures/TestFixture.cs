using System;
using System.Threading.Tasks;
using E2ETestCSharp.Services;
using E2ETestCSharp.Utils;
using E2ETestCSharp.Utils.Config;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class TestFixture : APIFixtures, IConfig
    {
        protected IBrowser Browser { set; get; }

        readonly static bool IsBrowserHeadless = Environment.GetEnvironmentVariable("TEST_CONDUIT_ENV") == "CI";

        protected IPage page { set; get; }
        protected IBrowserContext context { set; get; }

        [SetUp]
        public async Task CreateContextAndPage()
        {
            Browser = await new BrowserManager().LaunchBrowserAsync(Playwright, Utils.Enums.BrowserTypeEnum.FIREFOX, IsBrowserHeadless, 50);
            context = await Browser.NewContextAsync(new BrowserNewContextOptions { StorageState = await GetStateAsync() });
            page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task DisposeClientServicesAsync()
        {
            await context.CloseAsync();
            await Browser.CloseAsync();
        }

        public virtual async Task<string> GetStateAsync()
        {

            return $"{{\"cookies\":[],\"origins\":[{{\"origin\":\"{IConfig.APP_BASE_URL}\",\"localStorage\":[]}}]}}";

        }
    }
}
