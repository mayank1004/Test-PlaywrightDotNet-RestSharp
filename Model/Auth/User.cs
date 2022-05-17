using System;
namespace E2ETestCSharp.Model.Auth
{
    public class User
    {
        public User()
        {
        }
        public string email { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string bio { get; set; }
        public string image { get; set; }
        public string token { get; set; }
    }
}
