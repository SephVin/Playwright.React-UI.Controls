using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DropdownMenuExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this DropdownMenu dropdownMenu,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this DropdownMenu dropdownMenu,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await dropdownMenu.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainItemsAsync(
        this DropdownMenu dropdownMenu,
        string[] expectedItemsText,
        int timeoutInMilliseconds = 10000
    ) => await dropdownMenu.ExpectV2().ToContainItemsAsync(expectedItemsText, timeoutInMilliseconds)
        .ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dropdownMenu.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dropdownMenu.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}