using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class HtmlButtonTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_HtmlButton_Is_Visible()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);

        var actual = await htmlButton.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_HtmlButton_Is_Not_Exists()
    {
        var visibleHtmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        var notExistingHtmlButton = new HtmlButton(Page.GetByTestId("HiddenHtmlButton"));
        await visibleHtmlButton.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingHtmlButton.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_HtmlButton_Is_Disabled()
    {
        var htmlButton = await GetHtmlButtonAsync("disabled").ConfigureAwait(false);

        var actual = await htmlButton.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_HtmlButton_Is_Enabled()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task Click()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await htmlButton.ClickAsync().ConfigureAwait(false);

        await toast.RootLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var htmlButton = await GetHtmlButtonAsync("with-tooltip").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await htmlButton.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var htmlButton = await GetHtmlButtonAsync("focus-and-blur").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await htmlButton.FocusAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await htmlButton.BlurAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var htmlButton = await GetHtmlButtonAsync("with-tooltip").ConfigureAwait(false);
        await htmlButton.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await htmlButton.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("HtmlButtonId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        var actual = await htmlButton.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<HtmlButton> GetHtmlButtonAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"htmlbutton--{storyName}")).ConfigureAwait(false);
        return new HtmlButton(Page.GetByTestId("HtmlButtonId"));
    }
}