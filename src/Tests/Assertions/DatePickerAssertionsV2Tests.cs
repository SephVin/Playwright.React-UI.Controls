using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class DatePickerAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var datePicker = await GetDatePickerAsync("hidden").ConfigureAwait(false);
        await datePicker.WaitForAsync().ConfigureAwait(false);

        await datePicker.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var datePicker = await GetDatePickerAsync("disabled").ConfigureAwait(false);
        await datePicker.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var datePicker = await GetDatePickerAsync("error").ConfigureAwait(false);
        await datePicker.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var datePicker = await GetDatePickerAsync("warning").ConfigureAwait(false);
        await datePicker.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().ToHaveAttributeAsync("data-tid", "DatePickerId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.ExpectV2().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);
        await datePicker.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var datePicker = await GetDatePickerAsync("filled").ConfigureAwait(false);
        await datePicker.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var datePicker = await GetDatePickerAsync("default").ConfigureAwait(false);

        await datePicker.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await datePicker.DatePickerInputLocator.FocusAsync().ConfigureAwait(false);
        await datePicker.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DatePicker> GetDatePickerAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"datepicker--{storyName}")).ConfigureAwait(false);
        return new DatePicker(Page.GetByTestId("DatePickerId"));
    }
}