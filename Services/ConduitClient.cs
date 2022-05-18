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
        readonly RestClient _client;

        readonly Dictionary<string, string> _defaultHeaders = new Dictionary<string, string>();

        public ConduitClient()
        {
            _client = new RestClient(IConfig.API_SERVER);
            _defaultHeaders.Add("Content-Type", "application/json");
            _defaultHeaders.Add("X-Requested-With", "XMLHttpRequest");
            _client.AddDefaultHeaders(_defaultHeaders);
        }


        public Task<RestResponse> UserSignInPOST(string username, string password)
        {
            AuthServices auth = new AuthServices(_client);
            return auth.SignInResponseAsync(username, password);
        }

        public Task<String> GetUserAuthToken(string username, string password)
        {
            AuthServices auth = new AuthServices(_client);
            return auth.GetUserToken(username, password);
        }

        public async Task<String> GetDefaultUserAuthToken()
        {
            return await GetUserAuthToken(IUserConfig.EMAIL, IUserConfig.TEST_PASSWORD);
        }

        public async Task<User> GetCurrentUser(string username, string password)
        {
            AuthServices auth = new AuthServices(_client);
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
