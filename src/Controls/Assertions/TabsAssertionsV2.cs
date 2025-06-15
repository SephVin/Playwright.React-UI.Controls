using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Playwright.ReactUI.Controls.Assertions;

public class TabsAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Tabs tabs;

    public TabsAssertionsV2(Tabs tabs)
        : base(tabs)
    {
        this.tabs = tabs;
    }

    public async Task ToHaveActiveTabAsync(string tabName)
    {
        var tab = await tabs.GetByNameAsync(tabName).ConfigureAwait(false);
        await tab.ExpectV2().ToBeActiveAsync().ConfigureAwait(false);
    }

    public async Task NotToHaveActiveTabAsync(string tabName)
    {
        var tab = await tabs.GetByNameAsync(tabName).ConfigureAwait(false);
        await tab.ExpectV2().ToBeInactiveAsync().ConfigureAwait(false);
    }

    public async Task ToContainTabsAsync(string[] tabNames, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var tokens = await tabs.List.GetItemsAsync().ConfigureAwait(false);
                var texts = await tokens
                    .ToAsyncEnumerable()
                    .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
                    .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cts.Token)
                    .ConfigureAwait(false);

                if (tabNames.All(texts.Contains))
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
            $"Не дождались наличия следующих табов: [{string.Join(", ", tabNames)}] за {timeoutInMilliseconds}ms.");
    }
}