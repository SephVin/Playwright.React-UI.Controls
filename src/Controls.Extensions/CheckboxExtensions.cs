using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class CheckboxExtensions
{
    [Obsolete("Use WaitToBeCheckedAsync")]
    public static async Task WaitCheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.WaitToBeCheckedAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeUncheckedAsync")]
    public static async Task WaitUncheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.WaitToBeUncheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await checkbox.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await checkbox.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await checkbox.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await checkbox.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Checkbox checkbox,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Checkbox checkbox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Checkbox checkbox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await checkbox.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await checkbox.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}