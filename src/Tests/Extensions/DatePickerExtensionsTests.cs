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
    public async Task WaitToBeVisible()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var datePicker = await GetDatePickerAsync("hidden").ConfigureAwait(false);
        await datePicker.WaitForAsync().ConfigureAwait(false);

        await datePicker.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var datePicker = await GetDatePickerAsync("disabled").ConfigureAwait(false);
        await datePicker.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var datePicker = await GetDatePickerAsync("error").ConfigureAwait(false);
        await datePicker.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var datePicker = await GetDatePickerAsync("warning").ConfigureAwait(false);
        await datePicker.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitToHaveAttributeAsync("data-tid", "DatePickerId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.WaitToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_With_DateTime()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.WaitToHaveValueAsync(1.January(2024)).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.WaitNotToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_With_DateTime()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.WaitNotToHaveValueAsync(1.February(2024)).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeEmpty()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.WaitNotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        await datePicker.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.DatePickerInputLocator.FocusAsync().ConfigureAwait(false);
        await datePicker.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.DatePickerInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.FocusAndBlurAsync().ConfigureAwait(false);

        await datePicker.DatePickerInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DatePicker> GetDatePickerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"datepicker--{storyName}")).ConfigureAwait(false);
        return new DatePicker(Page.GetByTestId("DatePickerId"));
    }
}