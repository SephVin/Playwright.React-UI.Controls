using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class ToggleTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Toggle_Is_Visible()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitForAsync().ConfigureAwait(false);

        var actual = await toggle.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Toggle_Is_Not_Exists()
    {
        var visibleToggle = await GetToggleAsync("default").ConfigureAwait(false);
        var notExistingToggle = new Checkbox(Page.GetByTestId("HiddenToggle"));
        await visibleToggle.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingToggle.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Toggle_Is_Disabled()
    {
        var toggle = await GetToggleAsync("disabled").ConfigureAwait(false);

        var actual = await toggle.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Toggle_Is_Enabled()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Toggle_Is_Checked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);

        var actual = await toggle.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Toggle_Is_Unchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Toggle_With_Error()
    {
        var toggle = await GetToggleAsync("error").ConfigureAwait(false);

        var actual = await toggle.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Toggle_Without_Error()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Toggle_With_Warning()
    {
        var toggle = await GetToggleAsync("warning").ConfigureAwait(false);

        var actual = await toggle.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Toggle_Without_Warning()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task Click_Set_Checked_State_When_Toggle_Is_Unchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        await toggle.ClickAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click_Set_Unchecked_State_When_Toggle_Is_Checked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);

        await toggle.ClickAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Set_Checked_State_When_Toggle_Is_Unchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        await toggle.CheckAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Do_Nothing_When_Toggle_Is_Already_Checked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);

        await toggle.CheckAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Set_Unchecked_State_When_Toggle_Is_Checked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);

        await toggle.UncheckAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Do_Nothing_When_Toggle_Is_Already_Unchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        await toggle.UncheckAsync().ConfigureAwait(false);

        await toggle.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var toggle = await GetToggleAsync("with-tooltip").ConfigureAwait(false);
        await toggle.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await toggle.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var toggle = await GetToggleAsync("focus-and-blur").ConfigureAwait(false);
        await toggle.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await toggle.FocusAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await toggle.BlurAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var toggle = await GetToggleAsync("with-tooltip").ConfigureAwait(false);
        await toggle.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await toggle.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("ToggleId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        var actual = await toggle.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Toggle> GetToggleAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"toggle--{storyName}")).ConfigureAwait(false);
        return new Toggle(Page.GetByTestId("ToggleId"));
    }
}