using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class LoaderTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Loader_Is_Visible()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);
        await loader.WaitForAsync().ConfigureAwait(false);

        var actual = await loader.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Loader_Is_Not_Exists()
    {
        var visibleLoader = await GetLoaderAsync("default").ConfigureAwait(false);
        var notExistingLoader = new Loader(Page.GetByTestId("HiddenLoader"));
        await visibleLoader.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingLoader.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);

        var actual = await loader.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("Loading");
    }

    [Test]
    public async Task WaitLoading()
    {
        var loader = await GetLoaderAsync("wait-loading").ConfigureAwait(false);

        await loader.WaitLoadingAsync().ConfigureAwait(false);

        (await loader.RootLocator.IsVisibleAsync().ConfigureAwait(false)).Should().BeTrue();
    }

    [Test]
    public async Task WaitLoaded()
    {
        var loader = await GetLoaderAsync("hidden").ConfigureAwait(false);
        await loader.WaitForAsync().ConfigureAwait(false);

        await loader.WaitLoadedAsync().ConfigureAwait(false);

        (await loader.RootLocator.IsVisibleAsync().ConfigureAwait(false)).Should().BeFalse();
    }

    private async Task<Loader> GetLoaderAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"loader--{storyName}")).ConfigureAwait(false);
        return new Loader(Page.GetByTestId("LoaderId"));
    }
}