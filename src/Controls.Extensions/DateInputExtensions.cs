using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DateInputExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await dateInput.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await dateInput.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DateInput dateInput,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await dateInput.WaitToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this DateInput dateInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await dateInput.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this DateInput dateInput,
        DateTime value,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await dateInput.WaitNotToHaveValueAsync(value.ToString(dateFormat), options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this DateInput dateInput,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await dateInput.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await dateInput.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await dateInput.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dateInput.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DateInput dateInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await dateInput.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task FocusAndBlurAsync(this DateInput dateInput)
    {
        await dateInput.FocusAsync().ConfigureAwait(false);
        await dateInput.BlurAsync().ConfigureAwait(false);
    }
}