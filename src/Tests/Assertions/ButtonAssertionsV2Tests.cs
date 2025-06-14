using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ButtonAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var button = await GetButtonAsync("hidden").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);

        await button.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var button = await GetButtonAsync("disabled").ConfigureAwait(false);
        await button.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var button = await GetButtonAsync("error").ConfigureAwait(false);
        await button.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var button = await GetButtonAsync("warning").ConfigureAwait(false);
        await button.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveAttributeAsync("data-tid", "ButtonId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);
        await button.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var button = await GetButtonAsync("default").ConfigureAwait(false);

        await button.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await button.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await button.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Button> GetButtonAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"button--{storyName}")).ConfigureAwait(false);
        return new Button(Page.GetByTestId("ButtonId"));
    }
}