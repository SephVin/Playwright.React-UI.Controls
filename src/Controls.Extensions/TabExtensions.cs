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
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await tab.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Tab tab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await tab.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Tab tab,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await tab.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Tab tab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await tab.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeActiveAsync")]
    public static async Task WaitActiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeActiveAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeInactiveAsync")]
    public static async Task WaitInactiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.WaitToBeInactiveAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeActiveAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().ToHaveAttributeAsync(DataVisualState.Active, "", options).ConfigureAwait(false);

    public static async Task WaitToBeInactiveAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().Not.ToHaveAttributeAsync(DataVisualState.Active, "", options).ConfigureAwait(false);
}