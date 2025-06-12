using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class HtmlButtonExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this HtmlButton button,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await button.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this HtmlButton button,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await button.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this HtmlButton button,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this HtmlButton button,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this HtmlButton button,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this HtmlButton button,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this HtmlButton button,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await button.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this HtmlButton button,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await button.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}