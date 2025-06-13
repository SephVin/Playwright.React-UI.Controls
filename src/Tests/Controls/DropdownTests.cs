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

public class DropdownTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Dropdown_Is_Visible()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);

        var actual = await dropdown.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Dropdown_Is_Not_Exists()
    {
        var visibleDropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        var notExistingDropdown = new Button(Page.GetByTestId("HiddenDropdown"));
        await visibleDropdown.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingDropdown.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Dropdown_Is_Disabled()
    {
        var dropdown = await GetDropdownAsync("disabled").ConfigureAwait(false);

        var actual = await dropdown.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Dropdown_Is_Enabled()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_False_When_Menu_Is_Closed()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_True_When_Menu_Is_Opened()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.RootLocator.ClickAsync().ConfigureAwait(false);

        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_True_When_Dropdown_With_Error()
    {
        var dropdown = await GetDropdownAsync("error").ConfigureAwait(false);

        var actual = await dropdown.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Dropdown_Without_Error()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Dropdown_With_Warning()
    {
        var dropdown = await GetDropdownAsync("warning").ConfigureAwait(false);

        var actual = await dropdown.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Dropdown_Without_Warning()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task SelectFirstByText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectFirstByTextAsync("TODO 1").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirstByText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectFirstByTextAsync(new Regex("^TODO.*")).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectByIndexAsync(1).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByDataTid()
    {
        var dropdown = await GetDropdownAsync("with-menu-data-tid").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.SelectByDataTidAsync("TODO2").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ButtonLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.ClickAsync().ConfigureAwait(false);

        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
        await dropdown.ButtonLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var dropdown = await GetDropdownAsync("with-tooltip").ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ButtonLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await dropdown.FocusAsync().ConfigureAwait(false);
        await dropdown.ButtonLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await dropdown.BlurAsync().ConfigureAwait(false);
        await dropdown.ButtonLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var dropdown = await GetDropdownAsync("with-tooltip").ConfigureAwait(false);
        await dropdown.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await dropdown.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task GetMenuItems()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

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
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("DropdownId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        var actual = await dropdown.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    public async Task WaitItemWithText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitItemWithTextAsync("TODO 2").ConfigureAwait(false);
    }

    private async Task<Dropdown> GetDropdownAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dropdown--{storyName}")).ConfigureAwait(false);
        return new Dropdown(Page.GetByTestId("DropdownId"));
    }
}