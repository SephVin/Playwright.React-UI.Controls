using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class DatePicker : DateInput
{
    public DatePicker(ILocator context)
        : base(context)
    {
    }
}