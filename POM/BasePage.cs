using Microsoft.Playwright;
using System.Threading.Tasks;

namespace E2ETestCSharp.POM
{
    public class BasePage
    {
        private readonly IPage _page;
        private readonly string _url;
        protected static string baseUrl = "https://superlative-fox-61a6f8.netlify.app";
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
