using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class InputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Input_Is_Visible()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitForAsync().ConfigureAwait(false);

        var actual = await input.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Input_Is_Not_Exist()
    {
        var visibleInput = await GetInputAsync("default").ConfigureAwait(false);
        var notExistingInput = new Input(Page.GetByTestId("HiddenInput"));
        await visibleInput.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Input_Is_Disabled()
    {
        var input = await GetInputAsync("disabled").ConfigureAwait(false);

        var actual = await input.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Input_Is_Enabled()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Input_With_Error()
    {
        var input = await GetInputAsync("error").ConfigureAwait(false);

        var actual = await input.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Input_Without_Error()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Input_With_Warning()
    {
        var input = await GetInputAsync("warning").ConfigureAwait(false);

        var actual = await input.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Input_Without_Warning()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Input_Is_Filled()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);

        var actual = await input.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Input_Is_Not_Filled()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await input.FillAsync("newValue").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.FillAsync("newValue").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.FillAsync(string.Empty).ConfigureAwait(false);

        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_Input_Is_Empty()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await input.PressAsync("a").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.PressAsync("a").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("aTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await input.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("newValueTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.ClearAsync().ConfigureAwait(false);

        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.ClickAsync().ConfigureAwait(false);

        await input.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.FocusAsync().ConfigureAwait(false);
        await input.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await input.BlurAsync().ConfigureAwait(false);
        await input.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var input = await GetInputAsync("with-tooltip").ConfigureAwait(false);
        await input.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await input.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var input = await GetInputAsync("with-tooltip").ConfigureAwait(false);
        await input.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await input.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("InputId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        var actual = await input.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Input> GetInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"input--{storyName}")).ConfigureAwait(false);
        return new Input(Page.GetByTestId("InputId"));
    }
}