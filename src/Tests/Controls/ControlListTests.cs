using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class ControlListTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_List_Is_Visible()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.WaitForAsync().ConfigureAwait(false);

        var actual = await list.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_List_Is_Not_Visible()
    {
        var visibleList = await GetControlListAsync("default").ConfigureAwait(false);
        var notExistingList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await visibleList.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingList.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetItems()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetItemsAsync().ConfigureAwait(false);

        var text = await actual.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);
        text.Should().BeEquivalentTo("TODO 1", "TODO 2", "TODO 3");
    }

    [Test]
    public async Task GetItems_By_Predicate()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetItemsAsync(
            async x =>
            {
                var radio = await x.GetTextAsync().ConfigureAwait(false);

                return radio is "TODO 1" or "TODO 2";
            }
        ).ConfigureAwait(false);

        var text = await actual.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);
        text.Should().BeEquivalentTo("TODO 1", "TODO 2");
    }

    [Test]
    public async Task GetFirstItem()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetFirstItemAsync().ConfigureAwait(false);

        (await actual.GetTextAsync().ConfigureAwait(false))
            .Should()
            .BeEquivalentTo("TODO 1");
    }

    [Test]
    public async Task GetLastItem()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetLastItemAsync().ConfigureAwait(false);

        (await actual.GetTextAsync().ConfigureAwait(false))
            .Should()
            .BeEquivalentTo("TODO 3");
    }

    [Test]
    public async Task GetItem_By_Index()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetItemAsync(1).ConfigureAwait(false);

        (await actual.GetTextAsync().ConfigureAwait(false))
            .Should()
            .Be("TODO 2");
    }

    [Test]
    public async Task GetFirstItem_By_Predicate()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list
            .GetFirstItemAsync(async x => (await x.GetTextAsync().ConfigureAwait(false)).Contains("TODO"))
            .ConfigureAwait(false);

        (await actual.GetValueAsync().ConfigureAwait(false)).Should().Be("1");
    }

    [Test]
    public async Task GetItem_By_Predicate()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list
            .GetItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == "TODO 2")
            .ConfigureAwait(false);

        (await actual.GetValueAsync().ConfigureAwait(false)).Should().Be("2");
    }

    [Test]
    public async Task Count()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.CountAsync().ConfigureAwait(false);

        actual.Should().Be(3);
    }

    [Test]
    public async Task Hover()
    {
        var list = await GetControlListAsync("with-tooltip").ConfigureAwait(false);
        await list.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await list.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var list = await GetControlListAsync("with-tooltip").ConfigureAwait(false);
        await list.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await list.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttributeValue_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("RootId");
    }

    [Test]
    public async Task GetAttributeValue_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttributeValue_Return_Null_When_Attribute_Not_Exist()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        var actual = await list.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    public async Task ClickItem_By_Index()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        await list.ClickItemAsync(1).ConfigureAwait(false);

        var item = await list.GetItemAsync(1).ConfigureAwait(false);
        await item.RootLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ClickItem_By_Predicate()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);

        await list.ClickItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == "TODO 2")
            .ConfigureAwait(false);

        var item = await list.GetItemAsync(1).ConfigureAwait(false);
        await item.RootLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
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