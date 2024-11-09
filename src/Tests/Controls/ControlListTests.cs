using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class ControlListTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_List_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await list.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await list.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_List_Is_Not_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var visibleList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        var notExistingList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await visibleList.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingList.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetItems()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        var actual = await list.GetItemsAsync().ConfigureAwait(false);

        var text = await actual.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);
        text.Should().BeEquivalentTo("TODO 1", "TODO 2", "TODO 3");
    }

    [Test]
    public async Task GetItem_By_Index()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        var actual = await list.GetItemAsync(1).ConfigureAwait(false);

        (await actual.GetTextAsync().ConfigureAwait(false)).Should().Be("TODO 2");
    }

    [Test]
    public async Task GetItem_By_Predicate()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        var actual = await list
            .GetItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == "TODO 2")
            .ConfigureAwait(false);

        (await actual.GetValueAsync().ConfigureAwait(false)).Should().Be("2");
    }

    [Test]
    public async Task ClickItem_By_Index()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.ClickItemAsync(1).ConfigureAwait(false);

        var item = await list.GetItemAsync(1).ConfigureAwait(false);
        await item.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ClickItem_By_Predicate()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.ClickItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == "TODO 2")
            .ConfigureAwait(false);

        var item = await list.GetItemAsync(1).ConfigureAwait(false);
        await item.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Count()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        var actual = await list.CountAsync().ConfigureAwait(false);

        actual.Should().Be(3);
    }
}