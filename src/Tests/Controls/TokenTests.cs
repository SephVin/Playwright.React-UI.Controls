using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TokenTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Token_Is_Visible()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Token_Is_Not_Exists()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.FillAsync("First").ConfigureAwait(false);
        await tokenInput.SelectAsync("First").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();
        await token.RemoveAsync().ConfigureAwait(false);

        var actual = await token.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Token_Is_Disabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Token_Is_Enabled()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Token_With_Error()
    {
        var tokenInput = await GetTokenInputAsync("error-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Token_Without_Error()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Token_With_Warning()
    {
        var tokenInput = await GetTokenInputAsync("warning-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Token_Without_Warning()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("First");
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("Token__root");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var tokenInput = await GetTokenInputAsync("error-token").ConfigureAwait(false);
        await tokenInput.FillAsync("Second").ConfigureAwait(false);
        await tokenInput.SelectAsync("Second").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokens = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var token = tokens.First();

        var actual = await token.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}