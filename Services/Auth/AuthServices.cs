using System;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Utils;
using RestSharp;
using RestSharp.Serializers;

namespace E2ETestCSharp.Services.Auth
{
    public class AuthServices
    {

        readonly string loginEndpoint = "/api/users/login";
        readonly string USER_ENDPOINT = "/api/user";

        readonly RestClient _client;

        public AuthServices(RestClient client)
        {
            _client = client;
        }

        public async Task<RestResponse> SignInResponseAsync(string email, string password = "password")
        {
            RestRequest restRequest = new RestRequest(loginEndpoint);
            string jsonBody = $"{{\"user\":{{\"email\":\"{email}\",\"password\":\"{password}\"}}}}";
            restRequest.AddStringBody(jsonBody, ContentType.Json);
            RestResponse restResponse = await _client.PostAsync(restRequest);
            return restResponse;
        }
        //OR - if you would like  to use the models
        public async Task<RestResponse> SignInResponseUsingModelAsync(string email, string password = "password")
        {
            RestRequest restRequest = new RestRequest(loginEndpoint);
            UserManagement user = new UserManagement(new User(email, password));
            restRequest.AddBody(user);
            RestResponse restResponse = await _client.PostAsync(restRequest);
            return restResponse;
        }

        public async Task<string> GetUserToken(string username, string password = "password")
        {
            RestRequest restRequest = new RestRequest(loginEndpoint);
            string jsonBody = $"{{\"user\":{{\"email\":\"{username}\",\"password\":\"{password}\"}}}}";
            restRequest.AddStringBody(jsonBody, ContentType.Json);
            UserManagement restResponse = await _client.PostAsync<UserManagement>(restRequest);
            return restResponse.user.token;
        }

        public async Task<UserManagement> GetCurrentUser(string userToken)
        {
            RestRequest restRequest = new RestRequest(USER_ENDPOINT);
            restRequest.AddAuthorization(userToken);
            return await _client.GetAsync<UserManagement>(restRequest);
        }

    }
}
