using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class CurrencyInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_CurrencyInput_Is_Visible()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitForAsync().ConfigureAwait(false);

        var actual = await currencyInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_CurrencyInput_Is_Not_Exist()
    {
        var visibleCurrencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("HiddenCurrencyInput"));
        await visibleCurrencyInput.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingCurrencyInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_CurrencyInput_Is_Disabled()
    {
        var currencyInput = await GetCurrencyInputAsync("disabled").ConfigureAwait(false);

        var actual = await currencyInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_CurrencyInput_Is_Enabled()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_CurrencyInput_With_Error()
    {
        var currencyInput = await GetCurrencyInputAsync("error").ConfigureAwait(false);

        var actual = await currencyInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_CurrencyInput_Without_Error()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_CurrencyInput_With_Warning()
    {
        var currencyInput = await GetCurrencyInputAsync("warning").ConfigureAwait(false);

        var actual = await currencyInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_CurrencyInput_Without_Warning()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_CurrencyInput_Is_Filled()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);

        var actual = await currencyInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("9 999,23");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_CurrencyInput_Is_Not_Filled()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await currencyInput.FillAsync("1.23").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("1,23").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Overwrite_Existing_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);

        await currencyInput.FillAsync("8.23").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("8,23").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);

        await currencyInput.FillAsync("").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Press_AddChar_When_CurrencyInput_Is_Empty()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await currencyInput.PressAsync("1").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("1").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Clear_And_Add_Char_When_Value_Exists()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);

        await currencyInput.PressAsync("5").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("5").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await currencyInput.PressSequentiallyAsync("1.65").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("1,65").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Clear_And_Add_Value_When_Value_Exists()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);

        await currencyInput.PressSequentiallyAsync("2.45").ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToHaveValueAsync("2,45").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);

        await currencyInput.ClearAsync().ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.ClickAsync().ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.FocusAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.BlurAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var currencyInput = await GetCurrencyInputAsync("with-tooltip").ConfigureAwait(false);
        await currencyInput.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await currencyInput.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var currencyInput = await GetCurrencyInputAsync("with-tooltip").ConfigureAwait(false);
        await currencyInput.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await currencyInput.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("CurrencyInputId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        var actual = await currencyInput.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<CurrencyInput> GetCurrencyInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"currencyinput--{storyName}")).ConfigureAwait(false);
        return new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
    }
}