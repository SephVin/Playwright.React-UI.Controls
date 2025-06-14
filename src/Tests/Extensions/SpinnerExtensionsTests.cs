using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class SpinnerExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        await spinner.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var spinner = await GetSpinnerAsync("hidden").ConfigureAwait(false);
        await spinner.WaitForAsync().ConfigureAwait(false);

        await spinner.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        await spinner.WaitToHaveTextAsync("Loading").ConfigureAwait(false);
    }

    private async Task<Spinner> GetSpinnerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"spinner--{storyName}")).ConfigureAwait(false);
        return new Spinner(Page.GetByTestId("SpinnerId"));
    }
}