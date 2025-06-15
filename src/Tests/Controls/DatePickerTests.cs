using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DatePickerTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DatePicker_Is_Visible()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitForAsync().ConfigureAwait(false);

        var actual = await datePicker.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DatePicker_Is_Not_Exists()
    {
        var visibleDatePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        var notExistingDatePicker = new DatePicker(Page.GetByTestId("UnknownDatePickerId"));
        await visibleDatePicker.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingDatePicker.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_DatePicker_Is_Disabled()
    {
        var datePicker = await GetDatePickerAsync("disabled").ConfigureAwait(false);

        var actual = await datePicker.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_DatePicker_Is_Enabled()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_DatePicker_With_Error()
    {
        var datePicker = await GetDatePickerAsync("error").ConfigureAwait(false);

        var actual = await datePicker.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_DatePicker_Without_Error()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_DatePicker_With_Warning()
    {
        var datePicker = await GetDatePickerAsync("warning").ConfigureAwait(false);

        var actual = await datePicker.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_DatePicker_Without_Warning()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_DatePicker_Value_Is_Not_Empty()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("01.01.2024");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_DatePicker_Value_Is_Empty()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        await datePicker.FillAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.FillAsync("01.02.2024").ConfigureAwait(false);

        await datePicker.NativeInputLocator.Expect().ToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await datePicker.FillAsync(string.Empty).ConfigureAwait(false);

        await datePicker.NativeInputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);

        await datePicker.ClearAsync().ConfigureAwait(false);

        await datePicker.NativeInputLocator.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.ClickAsync().ConfigureAwait(false);

        await datePicker.DatePickerInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var datePicker = await GetDatePickerAsync("with-tooltip").ConfigureAwait(false);
        await datePicker.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await datePicker.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.DatePickerInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.FocusAsync().ConfigureAwait(false);
        await datePicker.DatePickerInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.BlurAsync().ConfigureAwait(false);
        await datePicker.DatePickerInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var datePicker = await GetDatePickerAsync("with-tooltip").ConfigureAwait(false);
        await datePicker.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await datePicker.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var dateInput = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await dateInput.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var dateInput = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await dateInput.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("DatePickerId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        var actual = await datePicker.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<DatePicker> GetDatePickerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"datepicker--{storyName}")).ConfigureAwait(false);
        return new DatePicker(Page.GetByTestId("DatePickerId"));
    }
}