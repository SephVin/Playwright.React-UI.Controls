using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ControlListExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var list = await GetControlListAsync("hidden").ConfigureAwait(false);
        await list.WaitForAsync().ConfigureAwait(false);

        await list.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveCount()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.WaitToHaveCountAsync(3).ConfigureAwait(false);
    }

    [Test]
    public async Task ClickFirstItem()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        await list.ClickFirstItemAsync().ConfigureAwait(false);

        var items = await list.GetItemsAsync().ConfigureAwait(false);
        await items.First().RootLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ClickLastItem()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        await list.ClickLastItemAsync().ConfigureAwait(false);

        var items = await list.GetItemsAsync().ConfigureAwait(false);
        await items.Last().RootLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetSingleItem()
    {
        var list = await GetControlListAsync("single-element").ConfigureAwait(false);

        var actual = await list.GetSingleItemAsync().ConfigureAwait(false);

        await actual.RootLocator.Expect().ToHaveTextAsync("TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task GetSingleItem_By_Predicate()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list
            .GetSingleItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == "TODO 2")
            .ConfigureAwait(false);

        await actual.RootLocator.Expect().ToHaveTextAsync("TODO 2").ConfigureAwait(false);
    }

    private async Task<ControlList<Radio>> GetControlListAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"controllist--{storyName}")).ConfigureAwait(false);

        return new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
    }
}