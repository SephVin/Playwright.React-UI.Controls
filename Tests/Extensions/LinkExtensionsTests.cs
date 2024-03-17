using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class LinkExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var visibleLink = new Link(Page.GetByTestId("LinkId"));
        var notExistingLink = new Link(Page.GetByTestId("UnknownLinkId"));
        await visibleLink.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLink.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--disabled")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitText()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.WaitTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitTextContains()
    {
        await Page.GotoAsync(StorybookUrl.Get("link--default")).ConfigureAwait(false);
        var link = new Link(Page.GetByTestId("LinkId"));

        await link.WaitTextContainsAsync("DO").ConfigureAwait(false);
    }
}