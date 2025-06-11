using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;

namespace Playwright.ReactUI.Controls;

public class DateRangePicker : ControlBase
{
    public DateRangePicker(ILocator rootLocator)
        : base(rootLocator)
    {
        DatePickerStart = new DatePicker(rootLocator.Locator("[data-tid='DateRangePicker__start']"));
        DatePickerEnd = new DatePicker(rootLocator.Locator("[data-tid='DateRangePicker__end']"));
    }

    public DatePicker DatePickerStart { get; }
    public DatePicker DatePickerEnd { get; }

    public async Task FillAsync(string? start, string? end)
    {
        if (start != null)
        {
            await DatePickerStart.FillAsync(start).ConfigureAwait(false);
        }

        if (end != null)
        {
            await DatePickerEnd.FillAsync(end).ConfigureAwait(false);
        }
    }

    public async Task ClearAsync()
    {
        await DatePickerStart.ClearAsync().ConfigureAwait(false);
        await DatePickerEnd.ClearAsync().ConfigureAwait(false);
    }

    public new DateRangePickerAssertions ExpectV2() => new(this);
}