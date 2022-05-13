using System;
using Microsoft.Playwright;

namespace E2ETestCSharp.POM
{
    public class HomePage : BasePage
    {
        private readonly IPage _page;
        public readonly ILocator _userProfileLink;
        public readonly ILocator _signInLink;

        public HomePage(IPage page) : base(page, ".user-pic")
        {
            _page = page;
            _userProfileLink = page.Locator("[placeholder=\"Email\"]");
            _signInLink = page.Locator("[href='/login']");
        }
    }
}
