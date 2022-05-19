using System.Threading.Tasks;
using E2ETestCSharp.POM;
using E2ETestCSharp.Tests.Fixtures;
using E2ETestCSharp.Utils.Config;
using NUnit.Framework;

namespace E2ETestCSharp.Tests.ConduitTests.E2ETests
{
    [Description("User can create a new post and ...")]
    [Parallelizable(ParallelScope.Self)]
    public class ConduitPostsTest : SignedInFixture
    {

        [Test, Description("User is displayed with new post link")]
        public async Task NewPostLinkIsDisplayed()
        {
            HomePage homePage = new HomePage(page);
            await homePage.GoTo();
            await Expect(homePage.NewPostLink).ToBeVisibleAsync();
        }
    }
}

