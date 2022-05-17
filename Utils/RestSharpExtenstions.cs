using System;
using RestSharp;

namespace E2ETestCSharp.Utils
{
    public static class RestSharpExtenstions
    {
        public static RestRequest AddAuthorization(this RestRequest request, string token)
        {
            return request.AddHeader("Authorization", $"Token {token}");
        }
    }
}
