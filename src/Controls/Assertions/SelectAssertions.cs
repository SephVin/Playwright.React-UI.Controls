using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class SelectAssertions : ILocatorAssertions
{
    private readonly ILocator buttonLocator;
    private readonly ILocatorAssertions buttonLocatorAssertions;
    private readonly ILocatorAssertions contextAssertions;
    private readonly ILocator contextLocator;
    private readonly ILocatorAssertions linkAssertions;
    private readonly ILocator linkLocator;

    public SelectAssertions(
        ILocator contextLocator,
        ILocatorAssertions contextAssertions,
        ILocator buttonLocator,
        ILocatorAssertions buttonLocatorAssertions,
        ILocator linkLocator,
        ILocatorAssertions linkAssertions)
    {
        this.contextLocator = contextLocator;
        this.contextAssertions = contextAssertions;
        this.buttonLocator = buttonLocator;
        this.buttonLocatorAssertions = buttonLocatorAssertions;
        this.linkLocator = linkLocator;
        this.linkAssertions = linkAssertions;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = null)
        => await contextAssertions.ToBeAttachedAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = null)
        => await contextAssertions.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = null)
    {
        await contextLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        if (await buttonLocator.IsVisibleAsync().ConfigureAwait(false))
        {
            await buttonLocatorAssertions.ToBeDisabledAsync(options).ConfigureAwait(false);
        }
        else
        {
            await linkAssertions.ToHaveAttributeAsync(
                "tabindex",
                "-1",
                new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
    }

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = null)
        => await contextAssertions.ToBeEditableAsync(options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = null)
        => await contextAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = null)
    {
        await contextLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        if (await buttonLocator.IsVisibleAsync().ConfigureAwait(false))
        {
            await buttonLocatorAssertions.ToBeEnabledAsync(options).ConfigureAwait(false);
        }
        else
        {
            await linkAssertions.Not.ToHaveAttributeAsync(
                "tabindex",
                "-1",
                new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = null)
        => await Task.FromException(new NotSupportedException("Not working in Select")).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = null)
        => await contextAssertions.ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToBeInViewportAsync(LocatorAssertionsToBeInViewportOptions? options = null)
        => await contextAssertions.ToBeInViewportAsync(options).ConfigureAwait(false);

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = null)
        => await contextAssertions.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string expected, LocatorAssertionsToContainTextOptions? options = null)
        => await contextAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex expected, LocatorAssertionsToContainTextOptions? options = null)
        => await contextAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToContainTextOptions? options = null)
        => await contextAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToContainTextOptions? options = null)
        => await contextAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = null)
        => await contextAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        Regex value,
        LocatorAssertionsToHaveAttributeOptions? options = null)
        => await contextAssertions.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(string expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await contextAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(Regex expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await contextAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToHaveClassOptions? options = null)
        => await contextAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveClassAsync(IEnumerable<Regex> expected, LocatorAssertionsToHaveClassOptions? options = null)
        => await contextAssertions.ToHaveClassAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveCountAsync(int count, LocatorAssertionsToHaveCountOptions? options = null)
        => await contextAssertions.ToHaveCountAsync(count, options).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, string value, LocatorAssertionsToHaveCSSOptions? options = null)
        => await contextAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveCSSAsync(string name, Regex value, LocatorAssertionsToHaveCSSOptions? options = null)
        => await contextAssertions.ToHaveCSSAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(string id, LocatorAssertionsToHaveIdOptions? options = null)
        => await contextAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveIdAsync(Regex id, LocatorAssertionsToHaveIdOptions? options = null)
        => await contextAssertions.ToHaveIdAsync(id, options).ConfigureAwait(false);

    public async Task ToHaveJSPropertyAsync(
        string name,
        object value,
        LocatorAssertionsToHaveJSPropertyOptions? options = null)
        => await contextAssertions.ToHaveJSPropertyAsync(name, value, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await contextAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await contextAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(IEnumerable<string> expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await contextAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(IEnumerable<Regex> expected, LocatorAssertionsToHaveTextOptions? options = null)
        => await contextAssertions.ToHaveTextAsync(expected, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = null)
        => await contextAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = null)
        => await contextAssertions.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = null)
        => await contextAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public async Task ToHaveValuesAsync(IEnumerable<Regex> values, LocatorAssertionsToHaveValuesOptions? options = null)
        => await contextAssertions.ToHaveValuesAsync(values, options).ConfigureAwait(false);

    public ILocatorAssertions Not => new SelectAssertions(
        contextLocator,
        contextAssertions.Not,
        buttonLocator,
        buttonLocatorAssertions.Not,
        linkLocator,
        linkAssertions.Not);
}