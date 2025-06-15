using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class PagingExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Paging paging,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await paging.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Paging paging,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await paging.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitActivePageAsync(
        this Paging paging,
        int pageNumber,
        int timeoutInMilliseconds = 10000
    ) => await paging.ExpectV2().ToHaveActivePageAsync(pageNumber, timeoutInMilliseconds).ConfigureAwait(false);

    public static async Task WaitPagesCountAsync(
        this Paging paging,
        int count,
        int timeoutInMilliseconds = 10000
    ) => await paging.ExpectV2().ToHavePagesCountAsync(count, timeoutInMilliseconds).ConfigureAwait(false);
}