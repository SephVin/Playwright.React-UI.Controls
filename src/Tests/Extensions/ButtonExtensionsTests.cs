using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class ButtonExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var button = await GetButtonAsync("hidden").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);

        await button.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var button = await GetButtonAsync("disabled").ConfigureAwait(false);
        await button.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var button = await GetButtonAsync("error").ConfigureAwait(false);
        await button.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var button = await GetButtonAsync("warning").ConfigureAwait(false);
        await button.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToHaveAttributeAsync("data-tid", "ButtonId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);

        await button.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await button.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await button.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Button> GetButtonAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"button--{storyName}")).ConfigureAwait(false);
        return new Button(Page.GetByTestId("ButtonId"));
    }
}