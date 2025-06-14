using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TokenInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var tokenInput = await GetTokenInputAsync("hidden").ConfigureAwait(false);
        await tokenInput.WaitForAsync().ConfigureAwait(false);

        await tokenInput.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled").ConfigureAwait(false);
        await tokenInput.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("error").ConfigureAwait(false);
        await tokenInput.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("warning").ConfigureAwait(false);
        await tokenInput.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitToHaveAttributeAsync("data-tid", "TokenInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToBeEmpty()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        await tokenInput.WaitNoToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await tokenInput.RootLocator.ClickAsync().ConfigureAwait(false);
        await tokenInput.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainTokens()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);

        await tokenInput.WaitToContainTokensAsync(new[] { "Second" }).ConfigureAwait(false);
        await tokenInput.WaitToContainTokensAsync(new[] { "First", "Second" }).ConfigureAwait(false);
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}