using Microsoft.Playwright;

namespace E2ETestCSharp.POM
{
    public class HomePage : BasePage
    {
        private readonly IPage _page;
        static readonly string pageUrl = "";

        public readonly ILocator _userProfileLink;
        public readonly ILocator _signInLink;
        public readonly ILocator _newPostLink;

        public HomePage(IPage page) : base(page, pageUrl)
        {
            _page = page;
            _userProfileLink = page.Locator(".user-pic");
            _signInLink = page.Locator("[href='/login']");
            _newPostLink = page.Locator(".ion-compose");
        }
    }
}
