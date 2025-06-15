using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ButtonExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Button button,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await button.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Button button,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await button.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Button button,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Button button,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await button.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Button button,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Button button,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await button.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Button button,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await button.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Button button,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await button.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}