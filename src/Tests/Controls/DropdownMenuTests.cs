using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DropdownMenuTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DropdownMenu_Is_Visible()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitForAsync().ConfigureAwait(false);

        var actual = await dropdownMenu.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DropdownMenu_Is_Not_Exists()
    {
        var visibleDropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        var notExistingDropdownMenu = new DropdownMenu(Page.GetByTestId("HiddenDropdownMenu"));
        await visibleDropdownMenu.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingDropdownMenu.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_False_When_Menu_Is_Closed()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_True_When_Menu_Is_Opened()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.RootLocator.ClickAsync().ConfigureAwait(false);

        var actual = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task GetText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task SelectFirstByText_When_Menu_Is_Closed_After_Select()
    {
        var dropdown = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectFirstByTextAsync("TODO 1").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirstByText_With_Regex_When_Menu_Is_Closed_After_Select()
    {
        var dropdown = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectFirstByTextAsync(new Regex("^TO.*")).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirstByText_When_Menu_Is_Not_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("not-closed").ConfigureAwait(false);

        await dropdownMenu.SelectFirstByTextAsync("TODO 1", false).ConfigureAwait(false);

        var isOpened = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);
        isOpened.Should().BeTrue();

        var items = await dropdownMenu.GetMenuItemsAsync().ConfigureAwait(false);
        var checkbox = new Checkbox((await items.GetFirstItemAsync().ConfigureAwait(false)).ContentLocator);
        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirstByText_With_Regex_When_Menu_Is_Not_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("not-closed").ConfigureAwait(false);

        await dropdownMenu.SelectFirstByTextAsync(new Regex("^TO.*"), false).ConfigureAwait(false);

        var isOpened = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);
        isOpened.Should().BeTrue();

        var items = await dropdownMenu.GetMenuItemsAsync().ConfigureAwait(false);
        var checkbox = new Checkbox((await items.GetFirstItemAsync().ConfigureAwait(false)).ContentLocator);
        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex_When_Menu_Is_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdownMenu.SelectByIndexAsync(1).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex_When_Menu_Is_Not_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("not-closed").ConfigureAwait(false);

        await dropdownMenu.SelectByIndexAsync(0, false).ConfigureAwait(false);

        var isOpened = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);
        isOpened.Should().BeTrue();

        var items = await dropdownMenu.GetMenuItemsAsync().ConfigureAwait(false);
        var checkbox = new Checkbox((await items.GetFirstItemAsync().ConfigureAwait(false)).ContentLocator);
        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByDataTid_When_Menu_Is_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("with-menu-data-tid").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdownMenu.SelectByDataTidAsync("TODO2").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByDataTid_When_Menu_Is_Not_Closed_After_Select()
    {
        var dropdownMenu = await GetDropdownMenuAsync("not-closed-with-menu-data-tid").ConfigureAwait(false);

        await dropdownMenu.SelectByDataTidAsync("CheckboxId", false).ConfigureAwait(false);

        var isOpened = await dropdownMenu.IsMenuOpenedAsync().ConfigureAwait(false);
        isOpened.Should().BeTrue();

        var items = await dropdownMenu.GetMenuItemsAsync().ConfigureAwait(false);
        var checkbox = new Checkbox((await items.GetFirstItemAsync().ConfigureAwait(false)).ContentLocator);
        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdownMenu.ClickAsync().ConfigureAwait(false);

        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var dropdownMenu = await GetDropdownMenuAsync("with-tooltip").ConfigureAwait(false);
        await dropdownMenu.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdownMenu.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ButtonLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await dropdownMenu.FocusAsync().ConfigureAwait(false);
        await dropdownMenu.ButtonLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await dropdownMenu.BlurAsync().ConfigureAwait(false);
        await dropdownMenu.ButtonLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var dropdownMenu = await GetDropdownMenuAsync("with-tooltip").ConfigureAwait(false);
        await dropdownMenu.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await dropdownMenu.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task GetMenuItems()
    {
        var dropdown = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdown.GetMenuItemsAsync().ConfigureAwait(false);
        var items = await actual.GetItemsAsync().ConfigureAwait(false);
        var itemValues = await items.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        itemValues.Should().BeEquivalentTo("TODO 1", "Here goes the header", "TODO 2");
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var dropdown = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdown.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("DropdownMenuId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        var actual = await dropdownMenu.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    public async Task WaitItemWithText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitItemWithTextAsync("TODO 2").ConfigureAwait(false);
    }

    private async Task<DropdownMenu> GetDropdownMenuAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"dropdownmenu--{storyName}")).ConfigureAwait(false);
        return new DropdownMenu(Page.GetByTestId("DropdownMenuId"));
    }
}