using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ToggleAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var toggle = await GetToggleAsync("hidden").ConfigureAwait(false);
        await toggle.WaitForAsync().ConfigureAwait(false);

        await toggle.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var toggle = await GetToggleAsync("disabled").ConfigureAwait(false);
        await toggle.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var toggle = await GetToggleAsync("error").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var toggle = await GetToggleAsync("warning").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);
        await toggle.ExpectV2().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUnchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveAttributeAsync("data-tid", "ToggleId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        await toggle.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await toggle.InputLocator.FocusAsync().ConfigureAwait(false);
        await toggle.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Toggle> GetToggleAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"toggle--{storyName}")).ConfigureAwait(false);
        return new Toggle(Page.GetByTestId("ToggleId"));
    }
}