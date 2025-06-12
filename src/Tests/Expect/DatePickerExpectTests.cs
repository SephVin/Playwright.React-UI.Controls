using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class DatePickerExpectTests : TestsBase
{
    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--disabled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var visibleDatePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        var notExistingDatePicker = new DatePicker(Page.GetByTestId("UnknownDatePickerId"));
        await visibleDatePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDatePicker.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToHaveAttributeAsync("data-tid", "DatePickerId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().NotToHaveAttributeAsync("type", "not-DatePickerId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ExpectV2().NotToHaveValueAsync("24.08.2022").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        await datePicker.FocusAsync().ConfigureAwait(false);

        await datePicker.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        await datePicker.FocusAsync().ConfigureAwait(false);
        await datePicker.BlurAsync().ConfigureAwait(false);

        await datePicker.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);
    }
}