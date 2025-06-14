using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LinkExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Link link,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await link.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Link link,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await link.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await link.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await link.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await link.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await link.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await link.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await link.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await link.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await link.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToHaveHrefAsync(
        this Link link,
        string href,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.ExpectV2().ToHaveHrefAsync(href, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveHrefAsync(
        this Link link,
        string href,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await link.ExpectV2().NotToHaveHrefAsync(href, options).ConfigureAwait(false);

    public static async Task WaitToHaveHrefAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.ExpectV2().ToHaveHrefAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveHrefAsync(
        this Link link,
        Regex regex,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await link.ExpectV2().NotToHaveHrefAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Link link,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await link.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Link link,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await link.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}