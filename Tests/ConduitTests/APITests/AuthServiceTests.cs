using System;
using System.Net;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Services.Auth;
using E2ETestCSharp.Tests.Fixtures;
using NUnit.Framework;
using RestSharp;

namespace E2ETestCSharp.Tests.ConduitTests.APITests
{
    public class AuthServiceTests : APIFixtures
    {
        [TestCase("interview@start.com", "password")]
        public async Task SignIn(string username, string password)

        {
            var response = await client.UserSignInPOST(username, password);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [TestCase("interview@start.com", "password")]
        public async Task GetCurrentUser(string username, string password)

        {
            User user = await client.GetCurrentUser(username, password);
            Assert.AreEqual(user.username, "interview");
        }

        [Test]
        public async Task GetArticles()

        {
            /*
            //Creating request to get data from server

            RestRequest restRequest = new RestRequest("api/articles");

            // Executing request to server and checking server response.

            RestResponse restResponse = await RestClient.GetAsync(restRequest);

            // Extracting output data from received response

            string response = restResponse.Content;

            // Verifiying reponse contains text “London”

            Console.WriteLine(response);
            Assert.AreEqual(HttpStatusCode.OK, restResponse.StatusCode);
            */
        }

    }
}
