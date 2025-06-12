using System.Threading.Tasks;
using FluentAssertions.Extensions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class DatePickerExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var visibleDatePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        var notExistingDatePicker = new DatePicker(Page.GetByTestId("UnknownDatePickerId"));
        await visibleDatePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDatePicker.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--error")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--warning")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("DatePickerId");
        var datePicker = new DatePicker(context);
        await context.Locator("noscript").Expect().ToHaveCountAsync(0).ConfigureAwait(false);

        await datePicker.FocusAndBlurAsync().ConfigureAwait(false);

        await context.Locator("noscript").Expect().ToHaveCountAsync(0).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue_With_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue_With_DateTime()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToHaveValueAsync(1.January(2024)).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--disabled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.WaitToBeDisabledAsync().ConfigureAwait(false);
    }
}