using System.Threading.Tasks;
using Microsoft.Playwright;

namespace E2ETestCSharp.POM
{
    public class SignInPage : BasePage
    {
        private readonly IPage _page;
        public readonly ILocator EmailInput;
        public readonly ILocator PasswordInput;
        public readonly ILocator SignInButton;
        static readonly string pageUrl = "/login";

        public SignInPage(IPage page) : base(page, pageUrl)
        {
            _page = page;
            EmailInput = page.Locator("[placeholder=\"Email\"]");
            PasswordInput = page.Locator("[placeholder=\"Password\"]");
            SignInButton = page.Locator("[type=\"submit\"]");
        }

        public async Task SignIn(string email, string password)
        {
            await EmailInput.FillAsync(email);
            await PasswordInput.FillAsync(password);
            await SignInButton.ClickAsync();
        }

        public override async Task GoTo()
        {
            await _page.GotoAsync(baseUrl);
            await new HomePage(_page).SignInLink.ClickAsync();
        }
    }
}
