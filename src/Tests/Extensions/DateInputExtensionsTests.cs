using System.Threading.Tasks;
using FluentAssertions.Extensions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class DateInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var dateInput = await GetDateInputAsync("hidden").ConfigureAwait(false);
        await dateInput.WaitForAsync().ConfigureAwait(false);

        await dateInput.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var dateInput = await GetDateInputAsync("disabled").ConfigureAwait(false);
        await dateInput.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var dateInput = await GetDateInputAsync("error").ConfigureAwait(false);
        await dateInput.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var dateInput = await GetDateInputAsync("warning").ConfigureAwait(false);
        await dateInput.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitToHaveAttributeAsync("data-tid", "DateInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.WaitToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_With_DateTime()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.WaitToHaveValueAsync(1.January(2024)).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.WaitNotToHaveValueAsync("01.02.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_With_DateTime()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.WaitNotToHaveValueAsync(1.February(2024)).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeEmpty()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.WaitNotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        await dateInput.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.RootLocator.FocusAsync().ConfigureAwait(false);
        await dateInput.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.FocusAndBlurAsync().ConfigureAwait(false);

        await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DateInput> GetDateInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dateinput--{storyName}")).ConfigureAwait(false);
        return new DateInput(Page.GetByTestId("DateInputId"));
    }
}