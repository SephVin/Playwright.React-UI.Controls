using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TabExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await tab.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await tab.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

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

    public static async Task WaitToHaveTextAsync(
        this Tab tab,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tab.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Tab tab,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tab.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

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

    public static async Task WaitToContainTextAsync(
        this Tab tab,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tab.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Tab tab,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tab.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

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
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await tab.ExpectV2().ToHaveAttributeAsync(DataVisualState.Active, options: options).ConfigureAwait(false);

    public static async Task WaitToBeInactiveAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await tab.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Active, options: options).ConfigureAwait(false);
}