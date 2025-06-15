using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class KebabExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var kebab = await GetKebabAsync("hidden").ConfigureAwait(false);
        await kebab.WaitForAsync().ConfigureAwait(false);

        await kebab.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var kebab = await GetKebabAsync("disabled").ConfigureAwait(false);
        await kebab.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainItems()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        await kebab.WaitToContainItemsAsync(new[] { "TODO 1", "TODO 2" })
            .ConfigureAwait(false);
    }

    private async Task<Kebab> GetKebabAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"kebab--{storyName}")).ConfigureAwait(false);
        return new Kebab(Page.GetByTestId("KebabId"));
    }
}