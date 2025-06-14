﻿using System.Threading.Tasks;

namespace Playwright.ReactUI.Controls.Assertions;

public class DateRangePickerAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly DateRangePicker dateRangePicker;

    public DateRangePickerAssertionsV2(DateRangePicker dateRangePicker)
        : base(dateRangePicker)
    {
        this.dateRangePicker = dateRangePicker;
    }

    public async Task ToHaveValuesAsync(string? from, string? to)
    {
        if (from != null)
        {
            await dateRangePicker.DatePickerStart.ExpectV2().ToHaveValueAsync(from).ConfigureAwait(false);
        }
        else
        {
            await dateRangePicker.DatePickerStart.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
        }

        if (to != null)
        {
            await dateRangePicker.DatePickerEnd.ExpectV2().ToHaveValueAsync(to).ConfigureAwait(false);
        }
        else
        {
            await dateRangePicker.DatePickerEnd.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
        }
    }

    public async Task ToBeEmptyAsync()
    {
        await dateRangePicker.DatePickerStart.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
        await dateRangePicker.DatePickerEnd.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }
}