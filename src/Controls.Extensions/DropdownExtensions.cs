using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DropdownExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dropdown.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dropdown.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dropdown.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dropdown.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveTextAsync")]
    public static async Task WaitTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.WaitToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdown.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdown.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}