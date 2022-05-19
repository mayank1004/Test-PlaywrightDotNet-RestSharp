using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.ConduitTests.NeedRefactoring
{
    public class BadExamples : BrowserTest
    {
        IBrowserContext Context { set; get; }
        IPage Page { set; get; }


        [Test, Order(1)]
        public async Task Bad_LoginTestAsync()
        {

            Context = await Browser.NewContextAsync();
            Page = await Context.NewPageAsync();

            // navigating to home page
            await Page.GotoAsync("https://superlative-fox-61a6f8.netlify.app");
            await Page.Locator("[href='/login']").ClickAsync();
            await Page.Locator("input").First.FillAsync("interview@start.com");
            await Page.Locator("input").Nth(1).FillAsync("password");
            await Page.Locator("button").ClickAsync();
            await Expect(Page.Locator("[type=\"submit\"]")).Not.ToBeVisibleAsync();

        }

        [Test, Order(2)]
        public async Task Bad_CheckMyFavoriteArticles()
        {
            await Page.Locator("[href=\"/@John Doeee\"]").ClickAsync();
            await Page.Locator("[href=\"/@John Doeee/favorites\"]").ClickAsync();

            //Perform assertions
            await Expect(Page.Locator(".article-preview")).ToContainTextAsync("No articles are here... yet.");

            //Cleaning up
            await Page.CloseAsync();
            await Context.CloseAsync();
            await Browser.CloseAsync();
        }
    }
}