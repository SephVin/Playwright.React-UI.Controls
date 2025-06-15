using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Assertions;

public class KebabAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Kebab kebab;

    public KebabAssertionsV2(Kebab kebab)
        : base(kebab)
    {
        this.kebab = kebab;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await kebab.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await kebab.ExpectV2().ToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToContainItemsAsync(string[] expectedItemsText, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var menu = await kebab.GetMenuItemsAsync().ConfigureAwait(false);
                var items = await menu.GetItemsAsync().ConfigureAwait(false);
                var itemsText = await items
                    .ToAsyncEnumerable()
                    .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
                    .ToHashSetAsync(cts.Token)
                    .ConfigureAwait(false);

                if (expectedItemsText.All(x => itemsText.Contains(x)))
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

        throw new TimeoutException($"Не дождались наличия элементов в списке Kebab за {timeoutInMilliseconds}ms.");
    }
}