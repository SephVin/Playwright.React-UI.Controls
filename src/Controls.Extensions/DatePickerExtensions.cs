using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DatePickerExtensions
{
    [Obsolete("WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await datePicker.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await datePicker.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await datePicker.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await datePicker.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this DatePicker datePicker,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default)
        => await datePicker.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this DatePicker datePicker,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await datePicker.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DatePicker datePicker,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default)
        => await datePicker.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DatePicker datePicker,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await datePicker.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEmptyAsync")]
    public static async Task WaitValueAbsenceAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await datePicker.WaitToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await datePicker.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DatePicker datePicker)
    {
        await datePicker.FocusAsync().ConfigureAwait(false);
        await datePicker.BlurAsync().ConfigureAwait(false);
    }

    public static async Task WaitToBeFocusedAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await datePicker.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await datePicker.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}