using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class LoaderExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);
        await loader.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var loader = await GetLoaderAsync("hidden").ConfigureAwait(false);
        await loader.WaitForAsync().ConfigureAwait(false);

        await loader.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);
        await loader.WaitToHaveTextAsync("Loading").ConfigureAwait(false);
    }

    private async Task<Loader> GetLoaderAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"loader--{storyName}")).ConfigureAwait(false);
        return new Loader(Page.GetByTestId("LoaderId"));
    }
}