using System.Net;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Tests.Fixtures;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.ConduitTests.APITests
{
    [Parallelizable(ParallelScope.Self)]
    public class AuthServiceTests : APIFixtures
    {
        [TestCase("interview@start.com", "password"), Description("Validate POST User Sign in API")]
        public async Task SignIn(string username, string password)

        {
            var response = await ConduitClient.UserSignInWithObjectModelPOST(username, password);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        // OR without using user Model class, just passing the request payload as a string
        [TestCase("interview@start.com", "password"), Description("Validate POST User Sign in API")]
        public async Task SignInWithoutUsingModelClass(string username, string password)

        {
            var response = await ConduitClient.UserSignInPOST(username, password);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }


        [TestCase("interview@start.com", "password"), Description("Validate GET CurrentUser API")]
        public async Task GetCurrentUser(string email, string password)

        {
            User user = await ConduitClient.GetCurrentUser(email, password);
            Assert.AreEqual(email, user.email);
        }

    }
}
