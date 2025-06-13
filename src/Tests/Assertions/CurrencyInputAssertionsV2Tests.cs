using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class CurrencyInputAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var button = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var currencyInput = await GetCurrencyInputAsync("hidden").ConfigureAwait(false);
        await currencyInput.WaitForAsync().ConfigureAwait(false);

        await currencyInput.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var currencyInput = await GetCurrencyInputAsync("disabled").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var currencyInput = await GetCurrencyInputAsync("error").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var currencyInput = await GetCurrencyInputAsync("warning").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToHaveAttributeAsync("data-tid", "CurrencyInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToHaveValueAsync("9 999,23").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_After_Fill()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.FillAsync("1").ConfigureAwait(false);

        await currencyInput.ExpectV2().ToHaveValueAsync("1,00").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToHaveValueAsync("12,23").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_After_Fill()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.FillAsync("1").ConfigureAwait(false);

        await currencyInput.ExpectV2().NotToHaveValueAsync("12,23").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);
        await currencyInput.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var currencyInput = await GetCurrencyInputAsync("filled").ConfigureAwait(false);
        await currencyInput.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var currencyInput = await GetCurrencyInputAsync("default").ConfigureAwait(false);

        await currencyInput.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.InputLocator.FocusAsync().ConfigureAwait(false);
        await currencyInput.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<CurrencyInput> GetCurrencyInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"currencyinput--{storyName}")).ConfigureAwait(false);
        return new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
    }
}