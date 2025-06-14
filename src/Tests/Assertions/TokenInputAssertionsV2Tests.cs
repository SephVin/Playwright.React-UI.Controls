using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TokenInputAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var tokenInput = await GetTokenInputAsync("hidden").ConfigureAwait(false);
        await tokenInput.WaitForAsync().ConfigureAwait(false);

        await tokenInput.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("error").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("warning").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToHaveAttributeAsync("data-tid", "TokenInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        await tokenInput.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await tokenInput.RootLocator.ClickAsync().ConfigureAwait(false);
        await tokenInput.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainTokens()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);

        await tokenInput.ExpectV2().ToContainTokensAsync(new[] { "Second" }).ConfigureAwait(false);
        await tokenInput.ExpectV2().ToContainTokensAsync(new[] { "First", "Second" }).ConfigureAwait(false);
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}