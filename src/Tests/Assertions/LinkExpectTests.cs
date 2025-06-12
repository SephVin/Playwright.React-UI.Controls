using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class LinkExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var visibleLink = new Link(Page.GetByTestId("LinkId"));
        var notExistingLink = new Link(Page.GetByTestId("UnknownLinkId"));
        await visibleLink.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLink.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--disabled")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--disabled")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var visibleLink = new Link(Page.GetByTestId("LinkId"));
        var notExistingLink = new Link(Page.GetByTestId("UnknownLinkId"));
        await visibleLink.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLink.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var visibleLink = new Link(Page.GetByTestId("LinkId"));
        var notExistingLink = new Link(Page.GetByTestId("UnknownLinkId"));
        await visibleLink.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLink.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToHaveAttributeAsync("href", "https://google.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().Not.ToHaveAttributeAsync("href", "https://google-2.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}