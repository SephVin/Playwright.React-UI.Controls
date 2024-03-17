using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DatePickerTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DatePicker_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        await datePicker.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await datePicker.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DatePicker_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var visibleDatePicker = new DatePicker(Page.GetByTestId("DatePickerId"));
        var notExistingDatePicker = new DatePicker(Page.GetByTestId("UnknownDatePickerId"));
        await visibleDatePicker.Expect().ToBeVisibleAsync().ConfigureAwait(false);

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
    public async Task Click_Should_Focus_Into_DatePicker()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("DatePickerId");
        var datePicker = new DatePicker(context);

        await datePicker.ClickAsync().ConfigureAwait(false);

        await context.Locator("noscript").Expect().ToHaveCountAsync(1).ConfigureAwait(false);
    }

    [Test]
    public async Task GetSelectedValue_Return_Empty_When_DatePicker_Value_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetSelectedValue_Return_Value_When_DatePicker_Value_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("24.08.2022");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.FillAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.Expect().ToHaveTextAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.FillAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.Expect().ToHaveTextAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--filled")).ConfigureAwait(false);
        var datePicker = new DatePicker(Page.GetByTestId("DatePickerId"));

        await datePicker.ClearAsync().ConfigureAwait(false);

        await datePicker.Expect().ToHaveTextAsync("  .  .    ").ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("DatePickerId");
        var datePicker = new DatePicker(context);

        await datePicker.FocusAsync().ConfigureAwait(false);

        await context.Locator("noscript").Expect().ToHaveCountAsync(1).ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("datepicker--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("DatePickerId");
        var datePicker = new DatePicker(context);
        await datePicker.ClickAsync().ConfigureAwait(false);
        await context.Locator("noscript").Expect().ToHaveCountAsync(1).ConfigureAwait(false);

        await datePicker.BlurAsync().ConfigureAwait(false);

        await context.Locator("noscript").Expect().ToHaveCountAsync(0).ConfigureAwait(false);
    }
}