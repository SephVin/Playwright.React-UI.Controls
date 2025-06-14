using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TokenAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var tokenInput = await GetTokenInputAsync("hidden").ConfigureAwait(false);
        await tokenInput.FillAsync("First").ConfigureAwait(false);
        await tokenInput.SelectAsync("First").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();
        await token.RemoveAsync().ConfigureAwait(false);

        await token.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("error-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("warning-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveAttributeAsync("data-tid", "Token__root").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToHaveTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToHaveTextAsync(new Regex("^Firs1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToContainTextAsync("Fir").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().ToContainTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToContainTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        await token.ExpectV2().NotToContainTextAsync(new Regex("^Firs1.*")).ConfigureAwait(false);
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}