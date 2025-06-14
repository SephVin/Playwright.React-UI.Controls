using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class CheckboxTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Checkbox_Is_Visible()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitForAsync().ConfigureAwait(false);

        var actual = await checkbox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Checkbox_Is_Not_Exists()
    {
        var visibleCheckbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("HiddenCheckbox"));
        await visibleCheckbox.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingCheckbox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Checkbox_Is_Disabled()
    {
        var checkbox = await GetCheckboxAsync("disabled").ConfigureAwait(false);

        var actual = await checkbox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Checkbox_Is_Enabled()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Checkbox_Is_Checked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Checkbox_Is_InitialIndeterminate()
    {
        var checkbox = await GetCheckboxAsync("initial-indeterminate").ConfigureAwait(false);

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Checkbox_Is_Unchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Checkbox_With_Error()
    {
        var checkbox = await GetCheckboxAsync("error").ConfigureAwait(false);

        var actual = await checkbox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Checkbox_Without_Error()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Checkbox_With_Warning()
    {
        var checkbox = await GetCheckboxAsync("warning").ConfigureAwait(false);

        var actual = await checkbox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Checkbox_Without_Warning()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetValue_Return_Checkbox_Value_When_Value_Is_Set()
    {
        var checkbox = await GetCheckboxAsync("with-value").ConfigureAwait(false);

        var actual = await checkbox.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("CheckboxValue");
    }

    [Test]
    public async Task GetValue_Return_Checkbox_Default_Value_When_Value_Is_Not_Set()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("on");
    }

    [Test]
    public async Task Click_Set_Checked_State_When_Checkbox_Is_Unchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        await checkbox.ClickAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click_Set_Unchecked_State_When_Checkbox_Is_Checked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);

        await checkbox.ClickAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Set_Checked_State_When_Checkbox_Is_Unchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        await checkbox.CheckAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Do_Nothing_When_Checkbox_Is_Already_Checked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);

        await checkbox.CheckAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Set_Unchecked_State_When_Checkbox_Is_Checked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);

        await checkbox.UncheckAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Do_Nothing_When_Checkbox_Is_Already_Unchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        await checkbox.UncheckAsync().ConfigureAwait(false);

        await checkbox.InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var checkbox = await GetCheckboxAsync("with-tooltip").ConfigureAwait(false);
        await checkbox.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await checkbox.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var checkbox = await GetCheckboxAsync("focus-and-blur").ConfigureAwait(false);
        await checkbox.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await checkbox.FocusAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await checkbox.BlurAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var checkbox = await GetCheckboxAsync("with-tooltip").ConfigureAwait(false);
        await checkbox.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await checkbox.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("CheckboxId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        var actual = await checkbox.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Checkbox> GetCheckboxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"checkbox--{storyName}")).ConfigureAwait(false);
        return new Checkbox(Page.GetByTestId("CheckboxId"));
    }
}