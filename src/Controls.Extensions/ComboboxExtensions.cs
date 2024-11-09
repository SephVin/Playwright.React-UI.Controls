using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ComboboxExtensions
{
    public static async Task FillAndSelectAsync(this Combobox combobox, string value)
    {
        await combobox.FillAsync(value).ConfigureAwait(false);
        await combobox.SelectAsync(value).ConfigureAwait(false);
    }

    public static async Task FillAndSelectFirstAsync(this Combobox combobox, string value)
    {
        await combobox.FillAsync(value).ConfigureAwait(false);
        await combobox.SelectFirstAsync(value).ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await combobox.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await combobox.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await combobox.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await combobox.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await combobox.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await combobox.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await combobox.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEmptyAsync")]
    public static async Task WaitValueAbsenceAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await combobox.WaitToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await combobox.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await combobox.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Combobox combobox,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await combobox.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Combobox combobox,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await combobox.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}