using System;
using System.Threading.Tasks;
using E2ETestCSharp.Services;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class TestFixture : APIFixtures
    {
        protected IBrowser Browser { set; get; }

        [OneTimeSetUp]
        public void InitializeClientServices()
        {
            ConduitClient = new ConduitClient();
        }

        protected IPage page { set; get; }
        protected IBrowserContext context { set; get; }

        [SetUp]
        public async Task CreateContextAndPage()
        {
            Browser = await Playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });
            context = await Browser.NewContextAsync(new BrowserNewContextOptions { StorageState = await GetStateAsync() });
            page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task DisposeClientServicesAsync()
        {
            await context.CloseAsync();
            await Browser.CloseAsync();
        }


        [OneTimeTearDown]
        public void CloseBrowser()
        {
            ConduitClient.Dispose();
        }

        public virtual async Task<string> GetStateAsync()
        {

            return $"{{\"cookies\":[],\"origins\":[{{\"origin\":\"https://superlative-fox-61a6f8.netlify.app\",\"localStorage\":[]}}]}}";

        }
    }
}
