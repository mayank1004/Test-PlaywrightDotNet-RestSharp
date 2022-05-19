using Microsoft.Playwright;

namespace E2ETestCSharp.POM
{
    public class HomePage : BasePage
    {
        private readonly IPage _page;
        static readonly string pageUrl = "";

        public readonly ILocator UserProfileLink;
        public readonly ILocator SignInLink;
        public readonly ILocator NewPostLink;

        public HomePage(IPage page) : base(page, pageUrl)
        {
            _page = page;
            UserProfileLink = page.Locator(".user-pic");
            SignInLink = page.Locator("[href='/login']");
            NewPostLink = page.Locator(".ion-compose");
        }
    }
}
