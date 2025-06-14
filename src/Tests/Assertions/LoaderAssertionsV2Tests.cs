using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class LoaderAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);
        await loader.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var loader = await GetLoaderAsync("hidden").ConfigureAwait(false);
        await loader.WaitForAsync().ConfigureAwait(false);

        await loader.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var loader = await GetLoaderAsync("default").ConfigureAwait(false);
        await loader.ExpectV2().ToHaveTextAsync("Loading").ConfigureAwait(false);
    }

    private async Task<Loader> GetLoaderAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"loader--{storyName}")).ConfigureAwait(false);
        return new Loader(Page.GetByTestId("LoaderId"));
    }
}