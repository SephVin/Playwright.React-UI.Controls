using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class PagingExtensions
{
    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Paging paging,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await paging.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Paging paging,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await paging.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Paging paging,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await paging.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Paging paging,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await paging.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitPageActiveAsync(
        this Paging paging,
        int pageNumber,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await paging.Expect()
            .ToHaveAttributeAsync("data-active", pageNumber.ToString(), options)
            .ConfigureAwait(false);

    public static async Task WaitPagesCountAsync(
        this Paging paging,
        int count,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await paging.Expect()
            .ToHaveAttributeAsync("data-pagescount", count.ToString(), options)
            .ConfigureAwait(false);
}