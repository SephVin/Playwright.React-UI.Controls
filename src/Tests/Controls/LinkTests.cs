using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class LinkTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Link_Is_Visible()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);

        var actual = await link.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Link_Is_Not_Exists()
    {
        var visibleLink = await GetLinkAsync("default").ConfigureAwait(false);
        var notExistingLink = new Link(Page.GetByTestId("HiddenLink"));
        await visibleLink.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingLink.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Link_Is_Disabled()
    {
        var link = await GetLinkAsync("disabled").ConfigureAwait(false);

        var actual = await link.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Link_Is_Enabled()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetUrl()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.GetUrlAsync().ConfigureAwait(false);

        actual.Should().Be("https://google.com/");
    }

    [Test]
    public async Task Click_Opens_Link()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        await link.ClickAsync().ConfigureAwait(false);

        await Page.WaitForURLAsync("https://www.google.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var link = await GetLinkAsync("with-tooltip").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await link.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await link.FocusAsync().ConfigureAwait(false);
        await link.RootLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await link.BlurAsync().ConfigureAwait(false);
        await link.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var link = await GetLinkAsync("with-tooltip").ConfigureAwait(false);
        await link.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await link.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("LinkId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        var actual = await link.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Link> GetLinkAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"link--{storyName}")).ConfigureAwait(false);
        return new Link(Page.GetByTestId("LinkId"));
    }
}