using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class RadioExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var radio = await GetRadioAsync("hidden").ConfigureAwait(false);
        await radio.WaitForAsync().ConfigureAwait(false);

        await radio.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var radio = await GetRadioAsync("disabled").ConfigureAwait(false);
        await radio.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var radio = await GetRadioAsync("error").ConfigureAwait(false);
        await radio.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var radio = await GetRadioAsync("warning").ConfigureAwait(false);
        await radio.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeChecked()
    {
        var radio = await GetRadioAsync("checked").ConfigureAwait(false);
        await radio.WaitToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUnchecked()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToHaveAttributeAsync("data-tid", "RadioId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var radio = await GetRadioAsync("with-value").ConfigureAwait(false);
        await radio.WaitToHaveValueAsync("RadioValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_With_Regex()
    {
        var radio = await GetRadioAsync("with-value").ConfigureAwait(false);
        await radio.WaitToHaveValueAsync(new Regex("^Radio.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveValueAsync("RadioValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.WaitNotToHaveValueAsync(new Regex("^Radio1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        await radio.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await radio.InputLocator.FocusAsync().ConfigureAwait(false);
        await radio.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Radio> GetRadioAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radio--{storyName}")).ConfigureAwait(false);
        return new Radio(Page.GetByTestId("RadioId"));
    }
}