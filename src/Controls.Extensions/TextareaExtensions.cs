using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TextareaExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await textarea.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await textarea.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await textarea.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await textarea.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Textarea textarea,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Textarea textarea,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}