using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class FixtureWithUserSignedIn : PlaywrightTest
    {

        IBrowser browser;

        [OneTimeSetUp]
        public async Task LaunchBrowserAsync()
        {
            var firefox = Playwright.Firefox;
            browser = await firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        }

        IBrowserContext context;
        protected IPage page;

        [SetUp]
        public async Task CreatßeContextAndPage()
        {
            context = await browser.NewContextAsync();
            page = await context.NewPageAsync();

        }

        [TearDown]
        public async Task CloseContextAndPage()
        {
            await context.CloseAsync();
            await page.CloseAsync();

        }

        [OneTimeTearDown]
        public async Task CloseBrowserAsync()
        {
            await browser.CloseAsync();
        }
    }
}
