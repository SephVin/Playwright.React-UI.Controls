using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class RadioTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Radio_Is_Visible()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitForAsync().ConfigureAwait(false);

        var actual = await radio.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Radio_Is_Not_Exists()
    {
        var visibleCheckbox = await GetRadioAsync("default").ConfigureAwait(false);
        var notExistingCheckbox = new Radio(Page.GetByTestId("HiddenCheckbox"));
        await visibleCheckbox.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingCheckbox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Radio_Is_Disabled()
    {
        var radio = await GetRadioAsync("disabled").ConfigureAwait(false);

        var actual = await radio.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Radio_Is_Enabled()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Radio_Is_Checked()
    {
        var radio = await GetRadioAsync("checked").ConfigureAwait(false);

        var actual = await radio.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Radio_Is_Unchecked()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Radio_With_Error()
    {
        var radio = await GetRadioAsync("error").ConfigureAwait(false);

        var actual = await radio.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Radio_Without_Error()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Radio_With_Warning()
    {
        var radio = await GetRadioAsync("warning").ConfigureAwait(false);

        var actual = await radio.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Radio_Without_Warning()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetValue_Return_Radio_Value_When_Value_Is_Set()
    {
        var radio = await GetRadioAsync("with-value").ConfigureAwait(false);

        var actual = await radio.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("RadioValue");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Value_Is_Not_Set()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Click_Set_Checked_State_When_Radio_Is_Unchecked()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        await radio.ClickAsync().ConfigureAwait(false);

        await radio.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click_Do_Nothing_When_Radio_Is_Checked()
    {
        var radio = await GetRadioAsync("checked").ConfigureAwait(false);

        await radio.ClickAsync().ConfigureAwait(false);

        await radio.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Set_Checked_State_When_Checkbox_Is_Unchecked()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        await radio.CheckAsync().ConfigureAwait(false);

        await radio.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Do_Nothing_When_Checkbox_Is_Already_Checked()
    {
        var radio = await GetRadioAsync("checked").ConfigureAwait(false);

        await radio.CheckAsync().ConfigureAwait(false);

        await radio.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var radio = await GetRadioAsync("with-tooltip").ConfigureAwait(false);
        await radio.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await radio.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var radio = await GetRadioAsync("focus-and-blur").ConfigureAwait(false);
        await radio.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await radio.FocusAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await radio.BlurAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var radio = await GetRadioAsync("with-tooltip").ConfigureAwait(false);
        await radio.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await radio.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("RadioId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        var actual = await radio.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Radio> GetRadioAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radio--{storyName}")).ConfigureAwait(false);
        return new Radio(Page.GetByTestId("RadioId"));
    }
}