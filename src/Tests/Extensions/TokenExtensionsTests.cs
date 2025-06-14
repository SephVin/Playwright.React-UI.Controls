using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TokenExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var tokenInput = await GetTokenInputAsync("hidden").ConfigureAwait(false);
        await tokenInput.FillAsync("First").ConfigureAwait(false);
        await tokenInput.SelectAsync("First").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();
        await token.RemoveAsync().ConfigureAwait(false);

        await token.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("error-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("warning-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveAttributeAsync("data-tid", "Token__root").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToHaveTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToHaveTextAsync(new Regex("^Firs1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToContainTextAsync("Fir").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitToContainTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToContainTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.WaitNotToContainTextAsync(new Regex("^Firs1.*")).ConfigureAwait(false);
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}