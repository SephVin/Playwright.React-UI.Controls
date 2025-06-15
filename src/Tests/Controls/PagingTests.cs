using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class PagingTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Paging_Is_Visible()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitForAsync().ConfigureAwait(false);

        var actual = await paging.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Paging_Is_Not_Exists()
    {
        var visiblePaging = await GetPagingAsync("default").ConfigureAwait(false);
        var notExistingPaging = new Paging(Page.GetByTestId("HiddenPagingId"));
        await visiblePaging.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingPaging.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Button_Is_Disabled()
    {
        var paging = await GetPagingAsync("disabled").ConfigureAwait(false);

        var actual = await paging.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Paging_Is_Enabled()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);

        var actual = await paging.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetPagesCount()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);

        var actual = await paging.GetPagesCountAsync().ConfigureAwait(false);

        actual.Should().Be(8);
    }

    [Test]
    public async Task GoToPage()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);

        await paging.GoToPageAsync(8).ConfigureAwait(false);

        var lastPage = await paging.Pages.GetLastItemAsync().ConfigureAwait(false);
        var pageNumber = await lastPage.GetPageNumberAsync().ConfigureAwait(false);
        pageNumber.Should().Be(8);

        var isActivePage = await lastPage.IsActivePageAsync().ConfigureAwait(false);
        isActivePage.Should().BeTrue();
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
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        Assert.ThrowsAsync<TimeoutException>(() => paging.GoToPageAsync(777));
    }

    [Test]
    public async Task GoToPage_Throws_When_Already_In_Page()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToPageAsync(2));
    }

    [Test]
    public async Task GoToLastPage()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        var secondPageItem = await paging.Pages
            .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
            .ConfigureAwait(false);
        var secondPageNumber = await secondPageItem.GetPageNumberAsync().ConfigureAwait(false);
        secondPageNumber.Should().Be(2);

        await paging.GoToLastPageAsync().ConfigureAwait(false);

        var lastPageItem = await paging.Pages
            .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
            .ConfigureAwait(false);
        var lastPageNumber = await lastPageItem.GetPageNumberAsync().ConfigureAwait(false);
        lastPageNumber.Should().Be(8);

        (await secondPageItem.IsActivePageAsync().ConfigureAwait(false)).Should().BeFalse();
        (await lastPageItem.IsActivePageAsync().ConfigureAwait(false)).Should().BeTrue();
    }

    [Test]
    public async Task GoToLastPage_Throws_When_Already_In_Page()
    {
        var paging = await GetPagingAsync("on-last-page").ConfigureAwait(false);
        var pageItem = await paging.Pages
            .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
            .ConfigureAwait(false);
        var pageNumber = await pageItem.GetPageNumberAsync().ConfigureAwait(false);
        pageNumber.Should().Be(8);

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToLastPageAsync());
    }

    [Test]
    public async Task GetActivePageNumber()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);

        var actual = await paging.GetActivePageNumberAsync().ConfigureAwait(false);

        actual.Should().Be(2);
    }

    [Test]
    public async Task GoToNextPage()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);

        await paging.GoToNextPageAsync().ConfigureAwait(false);

        var pageItem = await paging.Pages
            .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
            .ConfigureAwait(false);
        var pageNumber = await pageItem.GetPageNumberAsync().ConfigureAwait(false);
        pageNumber.Should().Be(3);
    }

    [Test]
    public async Task GoToNextPage_Throws_When_Current_Is_Last()
    {
        var paging = await GetPagingAsync("on-last-page").ConfigureAwait(false);

        Assert.ThrowsAsync<InvalidOperationException>(() => paging.GoToNextPageAsync());
    }

    private async Task<Paging> GetPagingAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"paging--{storyName}")).ConfigureAwait(false);
        return new Paging(Page.GetByTestId("PagingId"));
    }
}