using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class PagingAssertionsTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var visiblePaging = new Paging(Page.GetByTestId("PagingId"));
        var notExistingPaging = new Paging(Page.GetByTestId("UnknownPagingId"));
        await visiblePaging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingPaging.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--disabled")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--disabled")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var visiblePaging = new Paging(Page.GetByTestId("PagingId"));
        var notExistingPaging = new Paging(Page.GetByTestId("UnknownPagingId"));
        await visiblePaging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingPaging.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var visiblePaging = new Paging(Page.GetByTestId("PagingId"));
        var notExistingPaging = new Paging(Page.GetByTestId("UnknownPagingId"));
        await visiblePaging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingPaging.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToHaveAttributeAsync("data-tid", "PagingId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().Not.ToHaveAttributeAsync("data-pagescount", "1").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.Expect().ToHaveCountAsync(8).ConfigureAwait(false);
    }
}