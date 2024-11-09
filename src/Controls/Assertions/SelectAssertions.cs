using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Assertions;

public class SelectAssertions : ILocatorAssertions
{
    private readonly ILocatorAssertions rootLocatorAssertions;
    private readonly ILocatorAssertions buttonOrLinkLocatorAssertions;
    private readonly ILocatorAssertions selectLabelLocatorAssertions;
    private readonly ILocator buttonOrLinkLocator;

    public SelectAssertions(
        ILocatorAssertions rootLocatorAssertions,
        ILocatorAssertions buttonOrLinkLocatorAssertions,
        ILocatorAssertions selectLabelLocatorAssertions,
        ILocator buttonOrLinkLocator)
    {
        this.rootLocatorAssertions = rootLocatorAssertions;
        this.buttonOrLinkLocatorAssertions = buttonOrLinkLocatorAssertions;
        this.selectLabelLocatorAssertions = selectLabelLocatorAssertions;
        this.buttonOrLinkLocator = buttonOrLinkLocator;
    }

    public async Task ToBeAttachedAsync(LocatorAssertionsToBeAttachedOptions? options = null)
        => await rootLocatorAssertions.ToBeAttachedAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = null)
        => await rootLocatorAssertions.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToHaveAttributeAsync(
                DataVisualState.Disabled,
                "",
                new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
        else
        {
            await buttonOrLinkLocatorAssertions.ToBeDisabledAsync(options).ConfigureAwait(false);
        }
    }

    public async Task ToBeEditableAsync(LocatorAssertionsToBeEditableOptions? options = null)
        => await rootLocatorAssertions.ToBeEditableAsync(options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = null)
        => await rootLocatorAssertions.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.Not.ToHaveAttributeAsync(
                DataVisualState.Disabled,
                "",
                new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
        else
        {
            await buttonOrLinkLocatorAssertions.ToBeEnabledAsync(options).ConfigureAwait(false);
        }
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = null)
        => await buttonOrLinkLocatorAssertions.ToBeFocusedAsync().ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = null)
        => await rootLocatorAssertions.ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToBeInViewportAsync(LocatorAssertionsToBeInViewportOptions? options = null)
        => await rootLocatorAssertions.ToBeInViewportAsync(options).ConfigureAwait(false);

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = null)
        => await rootLocatorAssertions.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string expected, LocatorAssertionsToContainTextOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
    }

    public async Task ToContainTextAsync(Regex expected, LocatorAssertionsToContainTextOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
    }

    public async Task ToContainTextAsync(
        IEnumerable<string> expected,
        LocatorAssertionsToContainTextOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
    }

    public async Task ToContainTextAsync(
        IEnumerable<Regex> expected,
        LocatorAssertionsToContainTextOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToContainTextAsync(expected, options).ConfigureAwait(false);
        }
    }

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
        => await rootLocatorAssertions.ToHaveCountAsync(count, options).ConfigureAwait(false);

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
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValueAsync(Regex value, LocatorAssertionsToHaveValueOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToHaveTextAsync(value).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValuesAsync(
        IEnumerable<string> values,
        LocatorAssertionsToHaveValuesOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValuesAsync(IEnumerable<Regex> values, LocatorAssertionsToHaveValuesOptions? options = null)
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            await buttonOrLinkLocatorAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
        else
        {
            await selectLabelLocatorAssertions.ToHaveTextAsync(values).ConfigureAwait(false);
        }
    }

    public ILocatorAssertions Not => new SelectAssertions(
        rootLocatorAssertions.Not,
        buttonOrLinkLocatorAssertions.Not,
        selectLabelLocatorAssertions.Not,
        buttonOrLinkLocator);

    private async Task<bool> IsLinkAsync()
        => await buttonOrLinkLocator.GetAttributeAsync("type").ConfigureAwait(false) != "button";
}