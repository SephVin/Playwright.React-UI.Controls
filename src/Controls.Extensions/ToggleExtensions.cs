using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ToggleExtensions
{
    public static async Task WaitToBeDisabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await toggle.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await toggle.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await toggle.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await toggle.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toggle.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toggle.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Toggle toggle,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toggle.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Toggle toggle,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toggle.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await toggle.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Toggle toggle,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await toggle.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Toggle toggle,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await toggle.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Toggle toggle,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await toggle.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await toggle.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await toggle.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}