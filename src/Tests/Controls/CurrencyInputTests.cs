using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class CurrencyInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_CurrencyInput_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await currencyInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_CurrencyInput_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var visibleCurrencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("UnknownCurrencyInputId"));
        await visibleCurrencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingCurrencyInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_CurrencyInput_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--disabled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_CurrencyInput_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_CurrencyInput_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--error")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_CurrencyInput_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_CurrencyInput_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--warning")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_CurrencyInput_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Input()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.ClickAsync().ConfigureAwait(false);

        await currencyInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetValue_Return_Empty_When_CurrencyInput_Is_Not_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_CurrencyInput_Is_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        var actual = await currencyInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("123,456");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await currencyInput.FillAsync("789,123").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("789,123").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync("123,456").ConfigureAwait(false);

        await currencyInput.FillAsync("789,123").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("789,123").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync("123,456").ConfigureAwait(false);

        await currencyInput.FillAsync(string.Empty).ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_CurrencyInput_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await currencyInput.PressAsync("1").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("1").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Clear_And_Add_Char_When_Value_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync("123,456").ConfigureAwait(false);

        await currencyInput.PressAsync("9").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("9").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await currencyInput.PressSequentiallyAsync("123,987").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("123,987").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Clean_And_Add_Value_When_Value_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync("123,456").ConfigureAwait(false);

        await currencyInput.PressSequentiallyAsync("82").ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync("82").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().ToHaveValueAsync("123,456").ConfigureAwait(false);

        await currencyInput.ClearAsync().ConfigureAwait(false);

        await currencyInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.FocusAsync().ConfigureAwait(false);

        await currencyInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.ClickAsync().ConfigureAwait(false);
        await currencyInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.BlurAsync().ConfigureAwait(false);

        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }
}