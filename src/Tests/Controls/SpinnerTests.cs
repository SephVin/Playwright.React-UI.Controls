using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class SpinnerTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Spinner_Is_Visible()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        await spinner.WaitForAsync().ConfigureAwait(false);

        var actual = await spinner.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Spinner_Is_Not_Exists()
    {
        var visibleSpinner = await GetSpinnerAsync("default").ConfigureAwait(false);
        var notExistingSpinner = new Button(Page.GetByTestId("HiddenSpinner"));
        await visibleSpinner.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingSpinner.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var spinner = await GetSpinnerAsync("default").ConfigureAwait(false);

        var actual = await spinner.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("Loading");
    }

    [Test]
    public async Task WaitLoading()
    {
        var spinner = await GetSpinnerAsync("wait-loading").ConfigureAwait(false);

        await spinner.WaitLoadingAsync().ConfigureAwait(false);

        (await spinner.RootLocator.IsVisibleAsync().ConfigureAwait(false)).Should().BeTrue();
    }

    [Test]
    public async Task WaitLoaded()
    {
        var spinner = await GetSpinnerAsync("hidden").ConfigureAwait(false);
        await spinner.WaitForAsync().ConfigureAwait(false);

        await spinner.WaitLoadedAsync().ConfigureAwait(false);

        (await spinner.RootLocator.IsVisibleAsync().ConfigureAwait(false)).Should().BeFalse();
    }

    private async Task<Spinner> GetSpinnerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"spinner--{storyName}")).ConfigureAwait(false);
        return new Spinner(Page.GetByTestId("SpinnerId"));
    }
}