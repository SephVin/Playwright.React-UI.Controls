using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TextareaExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await textarea.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await textarea.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Textarea textarea,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Textarea textarea,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}