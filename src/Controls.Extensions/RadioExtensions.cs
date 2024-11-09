using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Radio radio,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await radio.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Radio radio,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await radio.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Radio radio,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await radio.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Radio radio,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await radio.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeCheckedAsync")]
    public static async Task WaitCheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.WaitToBeCheckedAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeUncheckedAsync")]
    public static async Task WaitUncheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.WaitToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveTextAsync")]
    public static async Task WaitTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.WaitToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await radio.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await radio.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this Radio radio,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Radio radio,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Radio radio,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Radio radio,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await radio.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Radio radio,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await radio.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}