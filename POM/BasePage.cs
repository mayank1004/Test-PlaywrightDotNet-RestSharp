using E2ETestCSharp.Utils.Config;
using Microsoft.Playwright;
using System.Threading.Tasks;

namespace E2ETestCSharp.POM
{
    public class BasePage : IConfig
    {
        private readonly IPage _page;
        private readonly string _url;
        protected static string baseUrl = IConfig.APP_BASE_URL;
        public BasePage(IPage page, string url)
        {
            _page = page;
            _url = url;

        }
        public virtual async Task GoTo()
        {
            await _page.GotoAsync(baseUrl + _url);
        }
    }
}
