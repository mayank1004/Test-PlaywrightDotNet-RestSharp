using System.Threading.Tasks;
using Microsoft.Playwright;

namespace E2ETestCSharp.POM
{
    public class SignInPage : BasePage
    {
        private readonly IPage _page;
        private readonly ILocator _emailInput;
        private readonly ILocator _passwordInput;
        private readonly ILocator _signinButton;
        static readonly string pageUrl = "/login";

        public SignInPage(IPage page) : base(page, pageUrl)
        {
            _page = page;
            _emailInput = page.Locator("[placeholder=\"Email\"]");
            _passwordInput = page.Locator("[placeholder=\"Password\"]");
            _signinButton = page.Locator("[type=\"submit\"]");
        }

        public async Task SignIn(string email, string password)
        {
            await _emailInput.FillAsync(email);
            await _passwordInput.FillAsync(password);
            await _signinButton.ClickAsync();
        }

        public override async Task GoTo()
        {
            await _page.GotoAsync(baseUrl);
            await new HomePage(_page)._signInLink.ClickAsync();
        }
    }
}
