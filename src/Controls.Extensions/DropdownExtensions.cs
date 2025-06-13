using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DropdownExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await dropdown.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await dropdown.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdown.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdown.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Dropdown dropdown,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdown.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Dropdown dropdown,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdown.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdown.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdown.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Dropdown dropdown,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdown.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Dropdown dropdown,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdown.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainItemsAsync(
        this Dropdown dropdown,
        string[] expectedItemsText,
        int timeoutInMilliseconds = 10000
    ) => await dropdown.ExpectV2().ToContainItemsAsync(expectedItemsText, timeoutInMilliseconds).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dropdown.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dropdown.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}