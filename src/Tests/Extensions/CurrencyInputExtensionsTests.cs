using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class CurrencyInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var currencyInput = await GetCurrencyInputAsync("hidden").ConfigureAwait(false);
        await currencyInput.WaitForAsync().ConfigureAwait(false);

        await currencyInput.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var currencyInput = await GetCurrencyInputAsync("disabled").ConfigureAwait(false);
        await currencyInput.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var currencyInput = await GetCurrencyInputAsync("error").ConfigureAwait(false);
        await currencyInput.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var currencyInput = await GetCurrencyInputAsync("warning").ConfigureAwait(false);
        await currencyInput.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitToHaveAttributeAsync("data-tid", "CurrencyInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.WaitToHaveValueAsync("9 999,23").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_After_Fill()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.FillAsync("1").ConfigureAwait(false);

        await currencyInput.WaitToHaveValueAsync("1,00").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.WaitNoToHaveValueAsync("12,23").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue_After_Fill()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.FillAsync("1").ConfigureAwait(false);

        await currencyInput.WaitNoToHaveValueAsync("12,23").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToBeEmpty()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.WaitNoToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        await currencyInput.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.InputLocator.FocusAsync().ConfigureAwait(false);
        await currencyInput.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.FocusAndBlurAsync().ConfigureAwait(false);

        await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<CurrencyInput> GetCurrencyInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"currencyinput--{storyName}")).ConfigureAwait(false);
        return new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
    }
}