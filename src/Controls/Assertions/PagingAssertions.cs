using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Assertions;

public class PagingAssertions : ILocatorAssertions
{
    private readonly ILocatorAssertions rootLocatorAssertions;
    private readonly ILocatorAssertions itemsLocatorAssertions;

    public PagingAssertions(
        ILocatorAssertions rootLocatorAssertions,
        ILocatorAssertions itemsLocatorAssertions)
    {
        this.rootLocatorAssertions = rootLocatorAssertions;
        this.itemsLocatorAssertions = itemsLocatorAssertions;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = null)
        => await rootLocatorAssertions.ToBeAttachedAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = null)
        => await rootLocatorAssertions.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = null)
        => await rootLocatorAssertions.ToHaveAttributeAsync(
            "tabindex",
            "-1",
            new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
        ).ConfigureAwait(false);

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = null)
        => await rootLocatorAssertions.ToBeEditableAsync(options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = null)
        => await rootLocatorAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = null)
        => await rootLocatorAssertions.Not.ToHaveAttributeAsync(
            "tabindex",
            "-1",
            new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
        ).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = null)
        => await rootLocatorAssertions.ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = null)
        => await rootLocatorAssertions.ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToBeInViewportAsync(LocatorAssertionsToBeInViewportOptions? options = null)
        => await rootLocatorAssertions.ToBeInViewportAsync(options).ConfigureAwait(false);

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = null)
        => await rootLocatorAssertions.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string expected, LocatorAssertionsToContainTextOptions? options = null)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex expected, LocatorAssertionsToContainTextOptions? options = null)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToContainTextOptions? options = null)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToContainTextOptions? options = null)
        => await rootLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleDescriptionAsync(
        string description,
        LocatorAssertionsToHaveAccessibleDescriptionOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleDescriptionAsync(
        Regex description,
        LocatorAssertionsToHaveAccessibleDescriptionOptions? options = default
    ) => await rootLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleErrorMessageAsync(
        string errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
        => await rootLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleErrorMessageAsync(
        Regex errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
        => await rootLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options).ConfigureAwait(false);

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
        LocatorAssertionsToHaveAttributeOptions? options = null)
        => await rootLocatorAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        Regex value,
        LocatorAssertionsToHaveAttributeOptions? options = null)
        => await rootLocatorAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(string expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(Regex expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToHaveClassOptions? options = null)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(IEnumerable<Regex> expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await rootLocatorAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveCountAsync(int count, LocatorAssertionsToHaveCountOptions? options = null)
        => await rootLocatorAssertions.ToHaveAttributeAsync("data-pagescount", count.ToString()).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, string value, LocatorAssertionsToHaveCSSOptions? options = null)
        => await rootLocatorAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, Regex value, LocatorAssertionsToHaveCSSOptions? options = null)
        => await rootLocatorAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(string id, LocatorAssertionsToHaveIdOptions? options = null)
        => await rootLocatorAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(Regex id, LocatorAssertionsToHaveIdOptions? options = null)
        => await rootLocatorAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveJSPropertyAsync(
        string name,
        object value,
        LocatorAssertionsToHaveJSPropertyOptions? options = null)
        => await rootLocatorAssertions.ToHaveJSPropertyAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveRoleAsync(AriaRole role, LocatorAssertionsToHaveRoleOptions? options = default)
        => await rootLocatorAssertions.ToHaveRoleAsync(role, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(IEnumerable<string> expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(IEnumerable<Regex> expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await rootLocatorAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = null)
        => await rootLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = null)
        => await rootLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = null)
        => await rootLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(IEnumerable<Regex> values, LocatorAssertionsToHaveValuesOptions? options = null)
        => await rootLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToMatchAriaSnapshotAsync(
        string expected,
        LocatorAssertionsToMatchAriaSnapshotOptions? options = null)
        => await rootLocatorAssertions.ToMatchAriaSnapshotAsync(expected, options).ConfigureAwait(false);

    public ILocatorAssertions Not => new PagingAssertions(rootLocatorAssertions.Not, itemsLocatorAssertions.Not);
}