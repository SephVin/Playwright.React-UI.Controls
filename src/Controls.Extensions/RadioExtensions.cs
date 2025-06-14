using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Radio radio,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await radio.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Radio radio,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await radio.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radio.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radio.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await radio.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await radio.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await radio.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await radio.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await radio.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await radio.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await radio.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await radio.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Radio radio,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await radio.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Radio radio,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await radio.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await radio.ExpectV2().ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Radio radio,
        Regex regex,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await radio.ExpectV2().NotToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Radio radio,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await radio.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Radio radio,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await radio.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}