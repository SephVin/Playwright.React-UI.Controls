using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ButtonExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Button button,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await button.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Button button,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await button.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Button button,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await button.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Button button,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await button.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveTextAsync")]
    public static async Task WaitTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.WaitToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await button.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await button.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Button button,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Button button,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}