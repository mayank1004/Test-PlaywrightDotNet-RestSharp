using System;
using NUnit.Framework;
using RestSharp;
using E2ETestCSharp.Services;

namespace E2ETestCSharp.Tests.Fixtures
{
    public class APIFixtures
    {
        public ConduitClient client { set; get; }

        [SetUp]
        public void ApiTestSetup()
        {
            client = new ConduitClient();
        }
    }
}
