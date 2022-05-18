using NUnit.Framework;
using E2ETestCSharp.Services;
using Microsoft.Playwright.NUnit;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class APIFixtures : PlaywrightTest
    {
        public ConduitClient ConduitClient { set; get; }

        [SetUp]
        public void ApiTestSetup()
        {
            ConduitClient = new ConduitClient();
        }

        [TearDown]
        public void ApiTestTearDown()
        {
            ConduitClient.Dispose();
        }
    }
}
