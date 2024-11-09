using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LinkExtensions
{
    [Obsolete("Use WaitToHaveTextAsync")]
    public static async Task WaitTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await link.WaitToHaveTextAsync(text, options).ConfigureAwait(false);

    [Obsolete("Use WaitToContainTextAsync")]
    public static async Task WaitTextContainsAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await link.WaitToContainTextAsync(text, options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Link link,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await link.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Link link,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await link.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await link.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await link.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await link.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await link.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Link link,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await link.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Link link,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await link.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveHrefAsync(
        this Link link,
        string href,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.Expect().ToHaveAttributeAsync("href", href, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveHrefAsync(
        this Link link,
        string href,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.Expect().Not.ToHaveAttributeAsync("href", href, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Link link,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await link.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Link link,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await link.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}