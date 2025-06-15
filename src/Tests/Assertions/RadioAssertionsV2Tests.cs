using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class RadioAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var radio = await GetRadioAsync("hidden").ConfigureAwait(false);
        await radio.WaitForAsync().ConfigureAwait(false);

        await radio.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var radio = await GetRadioAsync("disabled").ConfigureAwait(false);
        await radio.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var radio = await GetRadioAsync("error").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var radio = await GetRadioAsync("warning").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        var radio = await GetRadioAsync("checked").ConfigureAwait(false);
        await radio.ExpectV2().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUnchecked()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveAttributeAsync("data-tid", "RadioId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var radio = await GetRadioAsync("with-value").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveValueAsync("RadioValue").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_With_Regex()
    {
        var radio = await GetRadioAsync("with-value").ConfigureAwait(false);
        await radio.ExpectV2().ToHaveValueAsync(new Regex("^Radio.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveValueAsync("RadioValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_With_Regex()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);
        await radio.ExpectV2().NotToHaveValueAsync(new Regex("^Radio1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var radio = await GetRadioAsync("default").ConfigureAwait(false);

        await radio.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await radio.InputLocator.FocusAsync().ConfigureAwait(false);
        await radio.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Radio> GetRadioAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radio--{storyName}")).ConfigureAwait(false);
        return new Radio(Page.GetByTestId("RadioId"));
    }
}