using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DropdownTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Dropdown_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        await dropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await dropdown.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Dropdown_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var visibleDropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        var notExistingDropdown = new Dropdown(Page.GetByTestId("UnknownDropdownId"));
        await visibleDropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingDropdown.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Dropdown_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--disabled")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Dropdown_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Dropdown_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--error")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Dropdown_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Dropdown_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--warning")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Dropdown_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var actual = await dropdown.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Open_Menu()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.ClickAsync().ConfigureAwait(false);
        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task SelectByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.SelectByTextAsync("TODO 2").ConfigureAwait(false);

        await Page.GetByTestId("StaticToast").GetByTestId("ToastView__root")
            .Expect()
            .ToHaveTextAsync("Clicked TODO 2")
            .ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByText_When_Menu_Is_Not_Closed_After_Select()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--not-closed")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.SelectByTextAsync("TODO", isMenuClosedAfterSelect: false).ConfigureAwait(false);
        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task SelectByText_Throws_When_IsMenuClosedAfterSelect_Is_True_But_Menu_Is_Not_Closed()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--not-closed")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        Assert.ThrowsAsync<PlaywrightException>(() => dropdown.SelectByTextAsync("TODO"));
    }

    [Test]
    public async Task SelectByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.SelectByIndexAsync(1).ConfigureAwait(false);

        await Page.GetByTestId("StaticToast").GetByTestId("ToastView__root")
            .Expect()
            .ToHaveTextAsync("Clicked TODO 2")
            .ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex_When_Menu_Is_Not_Closed_After_Select()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--not-closed")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.SelectByIndexAsync(0, isMenuClosedAfterSelect: false).ConfigureAwait(false);
        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task SelectByIndex_Throws_When_IsMenuClosedAfterSelect_Is_True_But_Menu_Is_Not_Closed()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--not-closed")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        Assert.ThrowsAsync<PlaywrightException>(() => dropdown.SelectByIndexAsync(0));
    }

    [Test]
    public async Task GetText_Return_Button_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        var text = await dropdown.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TODO");
    }

    [Test]
    public async Task WaitItemWithText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitItemWithTextAsync("TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task OpenDropdownIfNeeded_Should_Open_Dropdown_When_It_Closed()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.OpenDropdownIfNeededAsync().ConfigureAwait(false);
        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task OpenDropdownIfNeeded_Should_Not_Closed_Dropdown_When_It_Opened()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.ClickAsync().ConfigureAwait(false);
        var actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);
        actual.Should().BeTrue();
        await dropdown.OpenDropdownIfNeededAsync().ConfigureAwait(false);
        actual = await dropdown.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }
}