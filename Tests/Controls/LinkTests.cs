using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class LinkTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Link_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));
        await link.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await link.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Link_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var visibleLink = new Link(Page.GetByTestId("LinkId"));
        var notExistingLink = new Link(Page.GetByTestId("UnknownLinkId"));
        await visibleLink.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingLink.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Link_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--disabled")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        var actual = await link.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Link_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        var actual = await link.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Opens_Link()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.ClickAsync().ConfigureAwait(false);

        await Page.WaitForURLAsync("https://www.google.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task GetText_Return_Link_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        var actual = await link.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetUrl_Return_Link_Url()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        var actual = await link.GetUrlAsync().ConfigureAwait(false);

        actual.Should().Be("https://google.com/");
    }
}