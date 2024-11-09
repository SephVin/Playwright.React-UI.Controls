using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class KebabExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await kebab.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await kebab.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await kebab.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await kebab.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);
}