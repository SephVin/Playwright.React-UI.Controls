﻿using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Assertions;

public class DropdownAssertions : ILocatorAssertions
{
    private readonly ILocatorAssertions buttonLocator;
    private readonly ILocatorAssertions rootLocatorAssertions;

    public DropdownAssertions(
        ILocatorAssertions rootLocatorAssertions,
        ILocatorAssertions buttonLocator)
    {
        this.rootLocatorAssertions = rootLocatorAssertions;
        this.buttonLocator = buttonLocator;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = default)
        => await rootLocatorAssertions.ToBeAttachedAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await buttonLocator.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await buttonLocator.ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = default)
        => await buttonLocator.ToBeEditableAsync(options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await buttonLocator.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await buttonLocator.ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await buttonLocator.ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
        => await buttonLocator.ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToBeInViewportAsync(LocatorAssertionsToBeInViewportOptions? options = default)
        => await buttonLocator.ToBeInViewportAsync().ConfigureAwait(false);

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await buttonLocator.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string expected, LocatorAssertionsToContainTextOptions? options = default)
        => await buttonLocator.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex expected, LocatorAssertionsToContainTextOptions? options = default)
        => await buttonLocator.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToContainTextOptions? options = default)
        => await buttonLocator.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToContainTextOptions? options = default)
        => await buttonLocator.ToContainTextAsync(expected, options).ConfigureAwait(false);

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
        => await buttonLocator.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex expected, LocatorAssertionsToHaveTextOptions? options = default)
        => await buttonLocator.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await buttonLocator.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await buttonLocator.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await buttonLocator.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = default)
        => await buttonLocator.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
        => await buttonLocator.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<Regex> values,
        LocatorAssertionsToHaveValuesOptions? options = default)
        => await buttonLocator.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public ILocatorAssertions Not => new DateInputAssertions(
        rootLocatorAssertions.Not,
        buttonLocator.Not);
}