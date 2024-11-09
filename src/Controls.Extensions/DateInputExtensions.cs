using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DateInputExtensions
{
    [Obsolete("WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dateInput.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dateInput.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dateInput.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dateInput.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this DateInput dateInput,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this DateInput dateInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DateInput dateInput,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DateInput dateInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEmptyAsync")]
    public static async Task WaitValueAbsenceAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await dateInput.WaitToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await dateInput.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DateInput dateInput)
    {
        await dateInput.FocusAsync().ConfigureAwait(false);
        await dateInput.BlurAsync().ConfigureAwait(false);
    }

    public static async Task WaitToBeFocusedAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dateInput.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dateInput.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}