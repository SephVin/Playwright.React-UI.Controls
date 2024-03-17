using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class PagingExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var visiblePaging = new Paging(Page.GetByTestId("PagingId"));
        var notExistingPaging = new Paging(Page.GetByTestId("UnknownPagingId"));
        await visiblePaging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingPaging.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--disabled")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitPageActive()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.WaitPageActiveAsync(2).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitPagesCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.WaitPagesCountAsync(8).ConfigureAwait(false);
    }
}