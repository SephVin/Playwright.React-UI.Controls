using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DatePickerExtensions
{
    public static async Task WaitEnabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await datePicker.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this DatePicker datePicker,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await datePicker.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this DatePicker datePicker,
        DateTime value,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await datePicker.WaitValueAsync(value.ToString("dd.MM.yyyy"), options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this DatePicker datePicker,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await datePicker.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);

    public static async Task WaitValueAbsenceAsync(
        this DatePicker datePicker,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await datePicker.Expect().ToHaveTextAsync("  .  .    ", options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DatePicker datePicker)
    {
        await datePicker.FocusAsync().ConfigureAwait(false);
        await datePicker.BlurAsync().ConfigureAwait(false);
    }
}