using System.Threading.Tasks;
using E2ETestCSharp.POM;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.E2ETests
{
    public class LoginTests : PlaywrightTest
    {
        [Test]
        public async Task ShouldSignIn()
        {
            var chromium = Playwright.Chromium;
            var browser = await chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50,
            });
            var Page = await browser.NewPageAsync();
            var signinPage = new SignInPage(Page);
            await signinPage.GoTo();
            await signinPage.SignIn("interview@start.com", "password");
            HomePage homePage = new HomePage(Page);
            await Expect(homePage._userProfileLink).ToBeVisibleAsync();

        }
    }
}