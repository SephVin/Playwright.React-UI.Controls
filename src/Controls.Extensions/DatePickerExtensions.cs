using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DatePickerExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await datePicker.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await datePicker.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DatePicker datePicker,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await datePicker.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DatePicker datePicker,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await datePicker.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this DatePicker datePicker,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await datePicker.WaitNotToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this DatePicker datePicker,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await datePicker.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await datePicker.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await datePicker.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await datePicker.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await datePicker.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DatePicker datePicker)
    {
        await datePicker.FocusAsync().ConfigureAwait(false);
        await datePicker.BlurAsync().ConfigureAwait(false);
    }
}