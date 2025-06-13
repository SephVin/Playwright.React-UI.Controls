using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class DateInputAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var dateInput = await GetDateInputAsync("hidden").ConfigureAwait(false);
        await dateInput.WaitForAsync().ConfigureAwait(false);

        await dateInput.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var dateInput = await GetDateInputAsync("disabled").ConfigureAwait(false);
        await dateInput.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var dateInput = await GetDateInputAsync("error").ConfigureAwait(false);
        await dateInput.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var dateInput = await GetDateInputAsync("warning").ConfigureAwait(false);
        await dateInput.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().ToHaveAttributeAsync("data-tid", "DateInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.ExpectV2().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        await dateInput.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.RootLocator.FocusAsync().ConfigureAwait(false);
        await dateInput.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DateInput> GetDateInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dateinput--{storyName}")).ConfigureAwait(false);
        return new DateInput(Page.GetByTestId("DateInputId"));
    }
}