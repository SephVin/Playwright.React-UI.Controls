using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class FxInputExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await fxInput.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await fxInput.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this FxInput fxInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await fxInput.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNoToHaveValueAsync(
        this FxInput fxInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await fxInput.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await fxInput.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNoToBeEmptyAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await fxInput.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await fxInput.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await fxInput.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task AppendTextAsync(
        this FxInput fxInput,
        string value,
        LocatorPressSequentiallyOptions? options = default)
    {
        await fxInput.FocusAsync().ConfigureAwait(false);
        await fxInput.PressAsync("End").ConfigureAwait(false);
        await fxInput.PressSequentiallyAsync(value, options).ConfigureAwait(false);
    }

    public static async Task WaitToBeAutoAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeHiddenOptions? options = default
    ) => await fxInput.ExpectV2().ToBeAutoAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeAutoAsync(
        this FxInput fxInput,
        LocatorAssertionsToBeVisibleOptions? options = default
    ) => await fxInput.ExpectV2().NotToBeAutoAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this FxInput fxInput)
    {
        await fxInput.FocusAsync().ConfigureAwait(false);
        await fxInput.BlurAsync().ConfigureAwait(false);
    }
}