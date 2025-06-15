using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TokenInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Token_Is_Visible()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.WaitForAsync().ConfigureAwait(false);

        var actual = await tokenInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Token_Is_Not_Exists()
    {
        var visibleTokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        var notExistingTokenInput = new TokenInput(Page.GetByTestId("HiddenTokenInput"));
        await visibleTokenInput.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingTokenInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Token_Is_Disabled()
    {
        var tokenInput = await GetTokenInputAsync("disabled").ConfigureAwait(false);

        var actual = await tokenInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Token_Is_Enabled()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Token_With_Error()
    {
        var tokenInput = await GetTokenInputAsync("error").ConfigureAwait(false);

        var actual = await tokenInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Token_Without_Error()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Token_With_Warning()
    {
        var tokenInput = await GetTokenInputAsync("warning").ConfigureAwait(false);

        var actual = await tokenInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Token_Without_Warning()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Tokens_Are_Empty_When_TokenInput_Is_Empty()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.Tokens.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Tokens_Are_Not_Empty_When_TokenInput_Is_Not_Empty()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);

        tokenNames.Should().BeEquivalentTo("First", "Second");
    }

    [Test]
    public async Task Fill_Empty_Value_And_SelectFirst()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync(string.Empty).ConfigureAwait(false);
        await tokenInput.SelectFirstAsync("First").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("First");
    }

    [Test]
    public async Task Fill_Value_And_SelectFirst()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync("Th").ConfigureAwait(false);
        await tokenInput.SelectFirstAsync("Fifth").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Fifth");
    }

    [Test]
    public async Task Fill_Value_And_SelectFirst_With_Multiple_Selects()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync("Th").ConfigureAwait(false);
        await tokenInput.SelectFirstAsync("Fifth").ConfigureAwait(false);
        await tokenInput.FillAsync("First").ConfigureAwait(false);
        await tokenInput.SelectFirstAsync("First").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Fifth", "First");
    }

    [Test]
    public async Task Fill_Empty_Value_And_Select()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync(string.Empty).ConfigureAwait(false);
        await tokenInput.SelectAsync("First").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("First");
    }

    [Test]
    public async Task Fill_Value_And_Select()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync("Th").ConfigureAwait(false);
        await tokenInput.SelectAsync("Fifth").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Fifth");
    }

    [Test]
    public async Task Fill_Value_And_Select_First_With_Multiple_Selects()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync("Th").ConfigureAwait(false);
        await tokenInput.SelectAsync("Fifth").ConfigureAwait(false);
        await tokenInput.FillAsync("First").ConfigureAwait(false);
        await tokenInput.SelectAsync("First").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Fifth", "First");
    }

    [Test]
    public async Task Clear()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);
        var beforeItemsCount = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        beforeItemsCount.Should().HaveCount(2);

        await tokenInput.ClearAsync().ConfigureAwait(false);

        var afterItemsCount = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        afterItemsCount.Should().BeEmpty();
    }

    [Test]
    public async Task RemoveToken_By_Index()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);

        await tokenInput.RemoveTokenAsync(0).ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Second");
    }

    [Test]
    public async Task RemoveToken_By_Text()
    {
        var tokenInput = await GetTokenInputAsync("filled").ConfigureAwait(false);

        await tokenInput.RemoveTokenAsync("First").ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Second");
    }

    [Test]
    public async Task Add_Unknown_Token()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        await tokenInput.FillAsync("Unknown").ConfigureAwait(false);
        await tokenInput.AddAsync().ConfigureAwait(false);

        var tokenItems = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
        var tokenNames = await tokenItems.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
        tokenNames.Should().BeEquivalentTo("Unknown");
    }

    [Test]
    public async Task Click()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await tokenInput.ClickAsync().ConfigureAwait(false);

        await tokenInput.TextareaLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var tokenInput = await GetTokenInputAsync("with-tooltip").ConfigureAwait(false);
        await tokenInput.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await tokenInput.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);
        await tokenInput.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await tokenInput.FocusAsync().ConfigureAwait(false);
        await tokenInput.TextareaLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await tokenInput.BlurAsync().ConfigureAwait(false);
        await tokenInput.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var tokenInput = await GetTokenInputAsync("with-tooltip").ConfigureAwait(false);
        await tokenInput.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await tokenInput.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("TokenInputId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    public async Task GetMenuItems()
    {
        var tokenInput = await GetTokenInputAsync("default").ConfigureAwait(false);

        var actual = await tokenInput.GetMenuItemsAsync().ConfigureAwait(false);
        var items = await actual.GetItemsAsync().ConfigureAwait(false);
        var itemValues = await items.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);

        itemValues.Should().BeEquivalentTo("First", "Second", "Third", "Fourth", "Fifth", "Sixth");
    }

    private async Task<TokenInput> GetTokenInputAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"tokeninput--{storyName}")).ConfigureAwait(false);
        return new TokenInput(Page.GetByTestId("TokenInputId"));
    }
}