using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class AutocompleteExtensions
{
    public static async Task SelectFirstSuggestionAsync(
        this Autocomplete autocomplete,
        LocatorClickOptions? options = default)
        => await autocomplete.SelectSuggestionAsync(0, options).ConfigureAwait(false);

    public static async Task FillAndSelectFirstSuggestionAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorFillOptions? options = default)
    {
        await autocomplete.FillAsync(value, options).ConfigureAwait(false);
        await autocomplete.SelectFirstSuggestionAsync().ConfigureAwait(false);
    }

    public static async Task FillAndSelectSuggestionByIndexAsync(
        this Autocomplete autocomplete,
        string value,
        Index index,
        LocatorFillOptions? options = default)
    {
        await autocomplete.FillAsync(value, options).ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(index).ConfigureAwait(false);
    }

    public static async Task AppendTextAndSelectFirstSuggestionAsync(
        this Autocomplete autocomplete,
        string value,
        LocatorPressSequentiallyOptions? options = default)
    {
        await autocomplete.AppendTextAsync(value, options).ConfigureAwait(false);
        await autocomplete.SelectFirstSuggestionAsync().ConfigureAwait(false);
    }
}