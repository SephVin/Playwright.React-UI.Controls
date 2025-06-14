using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class AutocompleteExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await autocomplete.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await autocomplete.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await autocomplete.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNoToHaveValueAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await autocomplete.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await autocomplete.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNoToBeEmptyAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await autocomplete.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await autocomplete.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Autocomplete autocomplete,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await autocomplete.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task FillAndSelectFirstSuggestionAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorFillOptions? options = default)
    {
        await autocomplete.FillAsync(value, options).ConfigureAwait(false);
        await autocomplete.SelectFirstSuggestionAsync().ConfigureAwait(false);
    }

    public static async Task FillAndSelectSuggestionAsync(
        this Autocomplete autocomplete,
        string value,
        int index,
        LocatorFillOptions? options = default)
    {
        await autocomplete.FillAsync(value, options).ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(index).ConfigureAwait(false);
    }

    public static async Task FocusAndBlurAsync(this Autocomplete autocomplete)
    {
        await autocomplete.FocusAsync().ConfigureAwait(false);
        await autocomplete.BlurAsync().ConfigureAwait(false);
    }

    public static async Task AppendTextAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorPressSequentiallyOptions? options = default)
    {
        await autocomplete.FocusAsync().ConfigureAwait(false);
        await autocomplete.PressAsync("End").ConfigureAwait(false);
        await autocomplete.PressSequentiallyAsync(value, options).ConfigureAwait(false);
    }
}