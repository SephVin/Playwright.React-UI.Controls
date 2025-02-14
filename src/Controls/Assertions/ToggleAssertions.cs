using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Assertions;

public class ToggleAssertions : ILocatorAssertions
{
    private readonly ILocatorAssertions inputLocatorAssertions;
    private readonly ILocatorAssertions rootLocatorAssertions;

    public ToggleAssertions(ILocatorAssertions rootLocatorAssertions, ILocatorAssertions inputLocatorAssertions)
    {
        this.rootLocatorAssertions = rootLocatorAssertions;
        this.inputLocatorAssertions = inputLocatorAssertions;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = default)
        => await rootLocatorAssertions.ToBeAttachedAsync().ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await inputLocatorAssertions.ToBeCheckedAsync().ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await inputLocatorAssertions.ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = default)
        => await inputLocatorAssertions.ToBeEditableAsync().ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await inputLocatorAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await inputLocatorAssertions.ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await inputLocatorAssertions.ToBeFocusedAsync(options).ConfigureAwait(false);

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
    ) => await inputLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleDescriptionAsync(
        Regex description,
        LocatorAssertionsToHaveAccessibleDescriptionOptions? options = default
    ) => await inputLocatorAssertions.ToHaveAccessibleDescriptionAsync(description, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleNameAsync(
        string name,
        LocatorAssertionsToHaveAccessibleNameOptions? options = default
    ) => await inputLocatorAssertions.ToHaveAccessibleNameAsync(name, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleNameAsync(
        Regex name,
        LocatorAssertionsToHaveAccessibleNameOptions? options = default
    ) => await inputLocatorAssertions.ToHaveAccessibleNameAsync(name, options).ConfigureAwait(false);

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

    public async Task ToHaveAccessibleErrorMessageAsync(
        string errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
        => await rootLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options).ConfigureAwait(false);

    public async Task ToHaveAccessibleErrorMessageAsync(
        Regex errorMessage,
        LocatorAssertionsToHaveAccessibleErrorMessageOptions? options = null)
        => await rootLocatorAssertions.ToHaveAccessibleErrorMessageAsync(errorMessage, options).ConfigureAwait(false);

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

    public async Task ToHaveRoleAsync(AriaRole role, LocatorAssertionsToHaveRoleOptions? options = default)
        => await inputLocatorAssertions.ToHaveRoleAsync(role, options).ConfigureAwait(false);

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
        => await inputLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = default)
        => await inputLocatorAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
        => await inputLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<Regex> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
        => await inputLocatorAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToMatchAriaSnapshotAsync(
        string expected,
        LocatorAssertionsToMatchAriaSnapshotOptions? options = null)
        => await inputLocatorAssertions.ToMatchAriaSnapshotAsync(expected, options).ConfigureAwait(false);

    public ILocatorAssertions Not => new CheckboxAssertions(rootLocatorAssertions.Not, inputLocatorAssertions.Not);
}