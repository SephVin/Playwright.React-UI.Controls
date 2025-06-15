using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Assertions;

public class PagingAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Paging paging;

    public PagingAssertionsV2(Paging paging)
        : base(paging)
    {
        this.paging = paging;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await paging.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await paging.ExpectV2().ToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToHavePagesCountAsync(int count, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var pageItem = await paging.Pages.GetLastItemAsync().ConfigureAwait(false);
                var pageNumber = await pageItem.GetNumberAsync().ConfigureAwait(false);

                if (pageNumber == count)
                {
                    return;
                }

                await Task.Delay(100, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        throw new TimeoutException($"Не дождались определенного количества страница за {timeoutInMilliseconds}ms.");
    }

    public async Task ToHaveActivePageAsync(int activePageNumber, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var pageItem = await paging.Pages
                    .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
                    .ConfigureAwait(false);

                var pageNumber = await pageItem.GetNumberAsync().ConfigureAwait(false);

                if (pageNumber == activePageNumber)
                {
                    return;
                }

                await Task.Delay(100, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        throw new TimeoutException(
            $"Не дождались активной страницы под номером {activePageNumber} за {timeoutInMilliseconds}ms.");
    }
}