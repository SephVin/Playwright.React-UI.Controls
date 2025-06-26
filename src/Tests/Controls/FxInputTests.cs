using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class FxInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_FxInput_Is_Visible()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitForAsync().ConfigureAwait(false);

        var actual = await fxInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_FxInput_Is_Not_Exist()
    {
        var visibleFxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        var notExistingFxInput = new FxInput(Page.GetByTestId("HiddenFxInput"));
        await visibleFxInput.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingFxInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_FxInput_Is_Disabled()
    {
        var fxInput = await GetFxInputAsync("disabled").ConfigureAwait(false);

        var actual = await fxInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_FxInput_Is_Enabled()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsAuto_Return_True_WHen_FxInput_In_AutoMode()
    {
        var fxInput = await GetFxInputAsync("auto").ConfigureAwait(false);

        var actual = await fxInput.IsAutoAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsAuto_Return_False_When_FxInput_In_Default_Mode()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.IsAutoAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_FxInput_With_Error()
    {
        var fxInput = await GetFxInputAsync("error").ConfigureAwait(false);

        var actual = await fxInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_FxInput_Without_Error()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_FxInput_With_Warning()
    {
        var fxInput = await GetFxInputAsync("warning").ConfigureAwait(false);

        var actual = await fxInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_FxInput_Without_Warning()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_FxInput_Is_Filled()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);

        var actual = await fxInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_FxInput_Is_Not_Filled()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await fxInput.FillAsync("newValue").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.FillAsync("newValue").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.FillAsync(string.Empty).ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_FxInput_Is_Empty()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await fxInput.PressAsync("a").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.PressAsync("a").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("aTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await fxInput.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("newValueTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.ClearAsync().ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.ClickAsync().ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.FocusAsync().ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.BlurAsync().ConfigureAwait(false);
        await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task SetAuto_Should_Change_Value_On_Auto()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.SetAutoAsync().ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("auto").ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var fxInput = await GetFxInputAsync("with-tooltip").ConfigureAwait(false);
        await fxInput.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await fxInput.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var fxInput = await GetFxInputAsync("with-tooltip").ConfigureAwait(false);
        await fxInput.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await fxInput.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("FxInputId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        var actual = await fxInput.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<FxInput> GetFxInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"fxinput--{storyName}")).ConfigureAwait(false);
        return new FxInput(Page.GetByTestId("FxInputId"));
    }
}