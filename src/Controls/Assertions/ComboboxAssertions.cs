using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Assertions;

public class ComboboxAssertions : ILocatorAssertions
{
    private readonly Combobox combobox;
    private readonly ILocatorAssertions inputLikeTextAssertions;
    private readonly ILocatorAssertions nativeInputLocatorAssertions;
    private readonly ILocatorAssertions rootLocatorAssertions;

    public ComboboxAssertions(
        Combobox combobox,
        ILocatorAssertions rootLocatorAssertions,
        ILocatorAssertions nativeInputLocatorAssertions,
        ILocatorAssertions inputLikeTextAssertions)
    {
        this.combobox = combobox;
        this.rootLocatorAssertions = rootLocatorAssertions;
        this.nativeInputLocatorAssertions = nativeInputLocatorAssertions;
        this.inputLikeTextAssertions = inputLikeTextAssertions;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = default)
        => await rootLocatorAssertions.ToBeAttachedAsync().ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await nativeInputLocatorAssertions.ToBeCheckedAsync().ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await nativeInputLocatorAssertions.ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = default)
        => await nativeInputLocatorAssertions.ToBeEditableAsync().ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);
        }
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await nativeInputLocatorAssertions.ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await nativeInputLocatorAssertions.ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
        => await rootLocatorAssertions.ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToBeInViewportAsync(LocatorAssertionsToBeInViewportOptions? options = default)
        => await rootLocatorAssertions.ToBeInViewportAsync().ConfigureAwait(false);

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await rootLocatorAssertions.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string expected, LocatorAssertionsToContainTextOptions? options = default)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex expected, LocatorAssertionsToContainTextOptions? options = default)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToContainTextOptions? options = default)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToContainTextOptions? options = default)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleDescriptionAsync(
        string description,
        LocatorAssertionsToHaveAccessibleDescriptionOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleDescriptionAsync(
        Regex description,
        LocatorAssertionsToHaveAccessibleDescriptionOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleNameAsync(
        string name,
        LocatorAssertionsToHaveAccessibleNameOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleNameAsync(name, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleNameAsync(
        Regex name,
        LocatorAssertionsToHaveAccessibleNameOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleNameAsync(name, options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await rootLocatorAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        Regex value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await rootLocatorAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(string expected, LocatorAssertionsToHaveClassOptions? options = default)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(Regex expected, LocatorAssertionsToHaveClassOptions? options = default)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToHaveClassOptions? options = default)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToHaveClassOptions? options = default)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveCountAsync(int count, LocatorAssertionsToHaveCountOptions? options = default)
        => await rootLocatorAssertions.ToHaveCountAsync(count, options).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, string value, LocatorAssertionsToHaveCSSOptions? options = default)
        => await rootLocatorAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, Regex value, LocatorAssertionsToHaveCSSOptions? options = default)
        => await rootLocatorAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(string id, LocatorAssertionsToHaveIdOptions? options = default)
        => await rootLocatorAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(Regex id, LocatorAssertionsToHaveIdOptions? options = default)
        => await rootLocatorAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveJSPropertyAsync(
        string name,
        object value,
        LocatorAssertionsToHaveJSPropertyOptions? options = default)
        => await rootLocatorAssertions.ToHaveJSPropertyAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveRoleAsync(AriaRole role, LocatorAssertionsToHaveRoleOptions? options = null)
        => await rootLocatorAssertions.ToHaveRoleAsync(role, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string expected, LocatorAssertionsToHaveTextOptions? options = default)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex expected, LocatorAssertionsToHaveTextOptions? options = default)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValuesAsync(
        IEnumerable<Regex> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
    }

    public async Task ToHaveAccessibleErrorMessageAsync(
        string errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options)
                .ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options)
                .ConfigureAwait(false);
        }
    }

    public async Task ToHaveAccessibleErrorMessageAsync(
        Regex errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options)
                .ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options)
                .ConfigureAwait(false);
        }
    }

    public async Task ToMatchAriaSnapshotAsync(
        string expected,
        LocatorAssertionsToMatchAriaSnapshotOptions? options = null)
    {
        if (await combobox.IsFocusedAsync().ConfigureAwait(false))
        {
            await nativeInputLocatorAssertions.ToMatchAriaSnapshotAsync(expected, options)
                .ConfigureAwait(false);
        }
        else
        {
            await inputLikeTextAssertions.ToMatchAriaSnapshotAsync(expected, options)
                .ConfigureAwait(false);
        }
    }

    public ILocatorAssertions Not
        => new ComboboxAssertions(
            combobox,
            rootLocatorAssertions.Not,
            nativeInputLocatorAssertions.Not,
            inputLikeTextAssertions.Not);
}