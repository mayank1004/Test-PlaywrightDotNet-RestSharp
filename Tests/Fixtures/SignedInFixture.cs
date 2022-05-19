using System;
using System.Threading.Tasks;
using E2ETestCSharp.Model.Auth;
using E2ETestCSharp.Utils.Config;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class SignedInFixture : TestFixture, IConfig
    {

        public override async Task<string> GetStateAsync()
        {
            UserManagement newUser = await ConduitClient.CreateNewUser();
            Console.WriteLine($"New user email is: {newUser.user.email}");
            string jwtToken = newUser.user.token;

            return $"{{\"cookies\":[],\"origins\":[{{\"origin\":\"{IConfig.APP_BASE_URL}\",\"localStorage\":[{{\"name\":\"jwt\",\"value\":\"{jwtToken}\"}}]}}]}}";

        }
    }
}

