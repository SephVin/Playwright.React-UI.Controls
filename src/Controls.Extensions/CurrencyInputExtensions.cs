using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class CurrencyInputExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await currencyInput.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await currencyInput.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this CurrencyInput currencyInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await currencyInput.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNoToHaveValueAsync(
        this CurrencyInput currencyInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await currencyInput.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await currencyInput.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNoToBeEmptyAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await currencyInput.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await currencyInput.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this CurrencyInput currencyInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await currencyInput.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this CurrencyInput currencyInput)
    {
        await currencyInput.FocusAsync().ConfigureAwait(false);
        await currencyInput.BlurAsync().ConfigureAwait(false);
    }
}