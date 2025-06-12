using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DatePickerTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DatePicker_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        await datePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await datePicker.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DatePicker_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var visibleDatePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        var notExistingDatePicker = new DatePicker(Page.GetByTestId("UnknownDatePickerId"));
        await visibleDatePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingDatePicker.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_DatePicker_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--disabled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_DatePicker_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_DatePicker_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--error")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_DatePicker_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_DatePicker_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--warning")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_DatePicker_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Empty_When_DatePicker_Value_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_DatePicker_Value_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("01.01.2024");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.FillAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.ExpectV2().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        await datePicker.ExpectV2().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.FillAsync("01.02.2024").ConfigureAwait(false);

        await datePicker.ExpectV2().ToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ClearAsync().ConfigureAwait(false);

        await datePicker.ExpectV2().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }
}