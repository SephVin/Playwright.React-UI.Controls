using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ToggleExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var toggle = await GetToggleAsync("hidden").ConfigureAwait(false);
        await toggle.WaitForAsync().ConfigureAwait(false);

        await toggle.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var toggle = await GetToggleAsync("disabled").ConfigureAwait(false);
        await toggle.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var toggle = await GetToggleAsync("error").ConfigureAwait(false);
        await toggle.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var toggle = await GetToggleAsync("warning").ConfigureAwait(false);
        await toggle.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeChecked()
    {
        var toggle = await GetToggleAsync("checked").ConfigureAwait(false);
        await toggle.WaitToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUnchecked()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToHaveAttributeAsync("data-tid", "ToggleId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);
        await toggle.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var toggle = await GetToggleAsync("default").ConfigureAwait(false);

        await toggle.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await toggle.InputLocator.FocusAsync().ConfigureAwait(false);
        await toggle.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Toggle> GetToggleAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"toggle--{storyName}")).ConfigureAwait(false);
        return new Toggle(Page.GetByTestId("ToggleId"));
    }
}