using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class SelectExtensions
{
    [Obsolete("Uae WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(this Select select)
        => await select.WaitToBeEnabledAsync().ConfigureAwait(false);

    [Obsolete("Uae WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(this Select select)
        => await select.WaitToBeDisabledAsync().ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(this Select select)
        => await select.Expect().ToBeEnabledAsync().ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(this Select select)
        => await select.Expect().ToBeDisabledAsync().ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await select.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await select.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await select.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToContainValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToContainTextOptions? options = default)
        => await select.Expect().ToContainTextAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToContainValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToContainTextOptions? options = default)
        => await select.Expect().Not.ToContainTextAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Select select,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await select.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Select select,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await select.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}