using System.Threading.Tasks;
using E2ETestCSharp.POM;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.E2ETests
{
    public class LoginTests : PageTest
    {
        [Test]
        public async Task ShouldSignIn()
        {
            var signinPage = new SignInPage(Page);
            await signinPage.GoTo();
            await signinPage.SignIn("interview@start.com", "password");
            HomePage homePage = new HomePage(Page);
            await Expect(homePage._userProfileLink).ToBeVisibleAsync();

        }
    }
}