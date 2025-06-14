using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class SpinnerAssertionsV2 : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        await spinner.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var spinner = await GetSpinnerAsync("hidden").ConfigureAwait(false);
        await spinner.WaitForAsync().ConfigureAwait(false);

        await spinner.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        await spinner.ExpectV2().ToHaveTextAsync("Loading").ConfigureAwait(false);
    }

    private async Task<Spinner> GetSpinnerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"spinner--{storyName}")).ConfigureAwait(false);
        return new Spinner(Page.GetByTestId("SpinnerId"));
    }
}