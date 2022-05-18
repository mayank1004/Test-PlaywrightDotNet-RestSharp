using System.Threading.Tasks;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class SignedInFixture : TestFixture
    {

        public override async Task<string> GetStateAsync()
        {
            string jwtToken = await ConduitClient.GetDefaultUserAuthToken();

            return $"{{\"cookies\":[],\"origins\":[{{\"origin\":\"https://superlative-fox-61a6f8.netlify.app\",\"localStorage\":[{{\"name\":\"jwt\",\"value\":\"{jwtToken}\"}}]}}]}}";

        }
    }
}

