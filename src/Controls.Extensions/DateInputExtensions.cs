using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DateInputExtensions
{
    public static async Task WaitEnabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dateInput.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dateInput.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this DateInput dateInput,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.WaitValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this DateInput dateInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitValueAbsenceAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await dateInput.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DateInput dateInput)
    {
        await dateInput.FocusAsync().ConfigureAwait(false);
        await dateInput.BlurAsync().ConfigureAwait(false);
    }
}