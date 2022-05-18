using System;
namespace E2ETestCSharp.Utils.Config
{
	public interface IConfig
	{
		readonly static string APP_BASE_URL = ConfigManager.Instance.GetPropertyValue("appBaseUrl");
		readonly static string API_SERVER = ConfigManager.Instance.GetPropertyValue("apiServer");
	}
}

