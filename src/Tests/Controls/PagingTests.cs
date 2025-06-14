using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class PagingTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Paging_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));
        await paging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await paging.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Paging_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var visiblePaging = new Paging(Page.GetByTestId("PagingId"));
        var notExistingPaging = new Paging(Page.GetByTestId("UnknownPagingId"));
        await visiblePaging.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingPaging.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Button_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--disabled")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        var actual = await paging.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Paging_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        var actual = await paging.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetPagesCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        var actual = await paging.GetPagesCountAsync().ConfigureAwait(false);

        actual.Should().Be(8);
    }

    [Test]
    public async Task GetPagesCount_Throws_When_Attribute_Is_Not_Set()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--data-pages-count-is-not-set")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GetPagesCountAsync());
    }

    [Test]
    public async Task GoToPage()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.GoToPageAsync(8).ConfigureAwait(false);

        var activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("8");
    }

    [Test]
    public async Task GoToPage_Throws_When_Page_Is_Not_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        Assert.ThrowsAsync<TimeoutException>(() => paging.GoToPageAsync(6));
    }

    [Test]
    public async Task GoToPage_Throws_When_PageNumber_Is_Greater_Than_PagesCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        Assert.ThrowsAsync<TimeoutException>(() => paging.GoToPageAsync(777));
    }

    [Test]
    public async Task GoToPage_Throws_When_Already_In_Page()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));
        var activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("2");

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToPageAsync(2));
    }

    [Test]
    public async Task GoToLastPage()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));
        var activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("2");

        await paging.GoToLastPageAsync().ConfigureAwait(false);

        activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("8");
    }

    [Test]
    public async Task GoToLastPage_Throws_When_Already_In_Page()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--on-last-page")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));
        var activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("8");

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToLastPageAsync());
    }

    [Test]
    public async Task GetActivePageNumber()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        var actual = await paging.GetActivePageNumberAsync().ConfigureAwait(false);

        actual.Should().Be(2);
    }

    [Test]
    public async Task GetActivePageNumber_Throws_When_Attribute_Is_Not_Set()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--data-active-is-not-set")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GetActivePageNumberAsync());
    }

    [Test]
    public async Task GoToNextPage()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--default")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        await paging.GoToNextPageAsync().ConfigureAwait(false);

        var activePage = await paging.GetAttributeValueAsync("data-active").ConfigureAwait(false);
        activePage.Should().Be("3");
    }

    [Test]
    public async Task GoToNextPage_Throws_When_Current_Is_Last()
    {
        await Page.GotoAsync(StorybookUrl.Get("paging--on-last-page")).ConfigureAwait(false);
        var paging = new Paging(Page.GetByTestId("PagingId"));

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToNextPageAsync());
    }
}