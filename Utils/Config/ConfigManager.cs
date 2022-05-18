
using System.IO;
using Microsoft.Extensions.Configuration;

namespace E2ETestCSharp.Utils.Config
{
    // Thread safe singleton calss
    public sealed class ConfigManager
	{
        private readonly IConfiguration _config;
        ConfigManager() {
            string settingPath = Path.GetFullPath(Path.Combine(@"../../../appsettings.json"));
            _config = new ConfigurationBuilder().AddJsonFile(settingPath).Build();
        }
        private static readonly object lock1 = new object ();  
        private static ConfigManager instance = null;
        public static ConfigManager Instance
        {
            get
            {
                lock (lock1)
                    {
                        if (instance == null)
                        {
                            instance = new ConfigManager();
                        }
                        return instance;
                    }
            }
        }

        public string GetPropertyValue(string key)
        {
            return _config[key];
        }
        
	}
}

