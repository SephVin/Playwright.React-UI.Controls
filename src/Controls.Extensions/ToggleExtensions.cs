using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ToggleExtensions
{
    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await toggle.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await toggle.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await toggle.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await toggle.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeCheckedAsync")]
    public static async Task WaitCheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.WaitToBeCheckedAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeUncheckedAsync")]
    public static async Task WaitUncheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.WaitToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await toggle.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await toggle.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}