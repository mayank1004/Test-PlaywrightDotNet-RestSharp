using System;
using System.Net;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Services.Auth;
using E2ETestCSharp.Tests.Fixtures;
using E2ETestCSharp.Utils.Config;
using NUnit.Framework;
using RestSharp;

namespace E2ETestCSharp.Tests.ConduitTests.APITests
{
    public class AuthServiceTests : APIFixtures, IConfig
    {
        [TestCase("interview@start.com", "password")]
        public async Task SignIn(string username, string password)

        {
            var response = await client.UserSignInPOST(username, password);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase("interview@start.com", "password")]
        public async Task GetCurrentUser(string email, string password)

        {
            User user = await client.GetCurrentUser(email, password);
            Assert.AreEqual(email, user.email);
        }

    }
}
