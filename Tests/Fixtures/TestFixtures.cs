using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.Fixtures
{
	[Parallelizable(ParallelScope.Self)]
	public class TestFixtures
	{
		public TestFixtures()
		{
		}

		IPlaywright playwright;
		IBrowser browser;

		[OneTimeSetUp]
		public async Task LaunchBrowserAsync()
        {
			playwright = await Playwright.CreateAsync();
			var firefox = playwright.Firefox;
			browser = await firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
		}

        protected IPage Page;
		IBrowserContext context;

		[SetUp]
		public async Task CreateContextAndPage()
        {
			context = await browser.NewContextAsync();
			Page = await context.NewPageAsync();

        }

		[TearDown]
		public async Task CloseContext()
		{
            await context.CloseAsync();
			await Page.CloseAsync();
		}


		[OneTimeTearDown]
		public async Task CloseBrowser()
        {
			await browser.CloseAsync();
		}
	}
}

