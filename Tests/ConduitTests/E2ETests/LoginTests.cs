using System.Threading.Tasks;
using E2ETestCSharp.POM;
using E2ETestCSharp.Tests.Fixtures;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.E2ETests
{
    public class LoginTests : TestFixture
    {
        [Test]
        public async Task ShouldSignIn()
        {
            var signinPage = new SignInPage(page);
            await signinPage.GoTo();
            await signinPage.SignIn("interview@start.com", "password");
            HomePage homePage = new HomePage(page);
            await Expect(homePage._userProfileLink).ToBeVisibleAsync();

        }
    }
}