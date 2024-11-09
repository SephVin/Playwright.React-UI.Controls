using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class HtmlButtonExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this HtmlButton button,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await button.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this HtmlButton button,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await button.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await button.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this HtmlButton button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await button.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this HtmlButton button,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this HtmlButton button,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}