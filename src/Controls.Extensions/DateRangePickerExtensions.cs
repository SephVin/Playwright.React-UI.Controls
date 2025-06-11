using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DateRangePickerExtensions
{
    public static async Task WaitToHaveValuesAsync(
        this DateRangePicker dateRangePicker,
        DateTime start,
        DateTime end,
        string dateFormat = "dd.MM.yyyy",
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await dateRangePicker.WaitToHaveValuesAsync(start.ToString(dateFormat), end.ToString(dateFormat))
        .ConfigureAwait(false);

    public static async Task WaitToHaveValuesAsync(
        this DateRangePicker dateRangePicker,
        string? start,
        string? end
    ) => await dateRangePicker.ExpectV2().ToHaveValuesAsync(start, end).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(this DateRangePicker dateRangePicker)
        => await dateRangePicker.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
}