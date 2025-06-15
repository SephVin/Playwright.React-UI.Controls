using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class ControlList<TItem> : ControlBase where TItem : ControlBase
{
    private readonly Func<ILocator, TItem> itemFactory;

    public ControlList(
        ILocator rootLocator,
        Func<ILocator, ILocator> itemSelector,
        Func<ILocator, TItem> itemFactory
    )
        : base(rootLocator)
    {
        ItemsLocator = itemSelector(rootLocator);
        this.itemFactory = itemFactory;
    }

    public ILocator ItemsLocator { get; }

    public override async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await ItemsLocator.First.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task<IReadOnlyList<TItem>> GetItemsAsync()
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemLocators.Select(x => itemFactory(x)).ToList();
    }

    public async Task<TItem> GetFirstItemAsync()
        => await GetItemAsync(0).ConfigureAwait(false);

    public async Task<TItem> GetLastItemAsync()
    {
        var itemsCount = await CountAsync().ConfigureAwait(false);
        return await GetItemAsync(itemsCount - 1).ConfigureAwait(false);
    }

    public async Task<TItem> GetItemAsync(int index)
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemFactory(itemLocators[index]);
    }

    public async Task<TItem> GetFirstItemAsync(
        Func<TItem, Task<bool>> predicate,
        int timeoutInMilliseconds = 10000)
    {
        var list = await GetItemsAsync(predicate, timeoutInMilliseconds).ConfigureAwait(false);
        return list.First();
    }

    public async Task<IList<TItem>> GetItemsAsync(
        Func<TItem, Task<bool>> predicate,
        int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            var list = await GetItemsAsync().ConfigureAwait(false);

            var predicateResults = await Task.WhenAll(
                list.Select(
                    async item => new
                    {
                        Item = item,
                        Result = await predicate(item).ConfigureAwait(false)
                    })
            ).ConfigureAwait(false);

            var items = predicateResults
                .Where(x => x.Result)
                .Select(x => x.Item)
                .ToList();

            if (items.Count > 0)
            {
                return items;
            }

            try
            {
                await Task.Delay(100, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        throw new TimeoutException($"Элементы списка не найдены по предикату за {timeoutInMilliseconds}ms.");
    }

    public async Task<int> CountAsync()
    {
        await RootLocator.WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Attached }
        ).ConfigureAwait(false);

        return await ItemsLocator.CountAsync().ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public async Task<TItem> GetItemAsync(Func<TItem, Task<bool>> predicate, int timeoutInMilliseconds = 10000)
    {
        var list = await GetItemsAsync(predicate, timeoutInMilliseconds).ConfigureAwait(false);
        return list.Single();
    }

    [Obsolete(
        "В будущих версиях метод будет перемещен в Controls.Extensions. " +
        "Если вы его используете, то убедитесь, что Controls.Extensions у вас добавлен")]
    public async Task ClickItemAsync(int index, LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(index).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    [Obsolete(
        "В будущих версиях метод будет перемещен в Controls.Extensions. " +
        "Если вы его используете, то убедитесь, что Controls.Extensions у вас добавлен")]
    public async Task ClickItemAsync(
        Func<TItem, Task<bool>> predicate,
        LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(predicate).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<ILocator>> GetItemLocatorsAsync()
    {
        await WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Attached }
        ).ConfigureAwait(false);

        return await ItemsLocator.AllAsync().ConfigureAwait(false);
    }

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new ControlListAssertions(
        RootLocator.Expect(),
        ItemsLocator.Expect(),
        ItemsLocator.First.Expect());

    public new ControlListAssertionsV2<TItem> ExpectV2() => new(this);
}