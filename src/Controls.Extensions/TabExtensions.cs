using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TabExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeActiveAsync")]
    public static async Task WaitActiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeActiveAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeInactiveAsync")]
    public static async Task WaitInactiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeInactiveAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Tab tab,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tab.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Tab tab,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tab.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Tab tab,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tab.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Tab tab,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tab.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Tab tab,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await tab.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Tab tab,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await tab.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeActiveAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.ExpectV2().ToHaveAttributeAsync(DataVisualState.Active, options: options).ConfigureAwait(false);

    public static async Task WaitToBeInactiveAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Active, options: options).ConfigureAwait(false);
}