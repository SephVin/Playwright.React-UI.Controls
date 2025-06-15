using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class CheckboxExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await checkbox.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await checkbox.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await checkbox.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await checkbox.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await checkbox.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await checkbox.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await checkbox.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await checkbox.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await checkbox.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await checkbox.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await checkbox.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await checkbox.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Checkbox checkbox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await checkbox.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Checkbox checkbox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await checkbox.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await checkbox.ExpectV2().ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Checkbox checkbox,
        Regex regex,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await checkbox.ExpectV2().NotToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await checkbox.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await checkbox.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}