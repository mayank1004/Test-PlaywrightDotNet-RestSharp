using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Services.Auth;
using E2ETestCSharp.Utils.Config;
using RestSharp;

namespace E2ETestCSharp.Services
{
    public class ConduitClient : IDisposable, IConfig, IUserConfig
    {
        private RestClient _client;

        private AuthServices auth;

        public ConduitClient()
        {
            clientRequestDefaultSetup();
            auth = new AuthServices(_client);
        }

        private void clientRequestDefaultSetup()
        {
            _client = new RestClient(IConfig.API_SERVER);
            Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>();
            _defaultHeaders.Add("Content-Type", "application/json");
            _defaultHeaders.Add("X-Requested-With", "XMLHttpRequest");
            _client.AddDefaultHeaders(_defaultHeaders);
        }

        public Task<RestResponse> UserSignInPOST(string username, string password) => auth.SignInResponseAsync(username, password);
        //OR with using Object Model class
        public Task<RestResponse> UserSignInWithObjectModelPOST(string username, string password) => auth.SignInResponseUsingModelAsync(username, password);

        public Task<string> GetUserAuthToken(string username, string password) => auth.GetUserToken(username, password);

        public Task<string> GetDefaultUserAuthToken() => GetUserAuthToken(IUserConfig.EMAIL, IUserConfig.TEST_PASSWORD);

        public async Task<User> GetCurrentUser(string username, string password)
        {
            string token = await auth.GetUserToken(username, password);
            UserManagement userManagement = await auth.GetCurrentUser(token);
            return userManagement.user;
        }

        public void Dispose()
        {
            _client?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
