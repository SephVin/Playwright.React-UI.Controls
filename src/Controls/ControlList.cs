using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class ControlList<TItem> : ControlBase where TItem : ControlBase
{
    private readonly Func<ILocator, TItem> itemFactory;
    private readonly ILocator itemsLocator;

    [Obsolete("Используй конструктор ControlList(ILocator rootLocator, Func<ILocator, ILocator> itemSelector, Func<ILocator, TItem> itemFactory)")]
    public ControlList(ILocator rootLocator, string itemSelector, Func<ILocator, TItem> itemFactory)
        : base(rootLocator)
    {
        this.itemFactory = itemFactory;
        itemsLocator = rootLocator.Locator(itemSelector);
    }

    public ControlList(ILocator rootLocator, Func<ILocator, ILocator> itemSelector, Func<ILocator, TItem> itemFactory)
        : base(rootLocator)
    {
        itemsLocator = itemSelector(rootLocator);
        this.itemFactory = itemFactory;
    }

    public override async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await itemsLocator.First.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task<IReadOnlyList<TItem>> GetItemsAsync()
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemLocators.Select(x => itemFactory(x)).ToList();
    }

    public async Task<IReadOnlyList<TItem>> GetItemsAsync(Func<TItem, ValueTask<bool>> predicate)
    {
        var list = await GetItemsAsync().ConfigureAwait(false);
        return await list.ToAsyncEnumerable().WhereAwait(predicate).ToArrayAsync().ConfigureAwait(false);
    }

    public async Task<TItem> GetItemAsync(Index index)
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemFactory(itemLocators[index]);
    }

    public async Task<TItem> GetItemAsync(Func<TItem, ValueTask<bool>> predicate)
    {
        var list = await GetItemsAsync().ConfigureAwait(false);
        return await list.ToAsyncEnumerable().SingleAwaitAsync(predicate).ConfigureAwait(false);
    }

    public async Task<TItem> GetFirstItemAsync(Func<TItem, ValueTask<bool>> predicate)
    {
        var list = await GetItemsAsync().ConfigureAwait(false);
        return await list.ToAsyncEnumerable().FirstAwaitAsync(predicate).ConfigureAwait(false);
    }

    public async Task ClickItemAsync(Index index, LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(index).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task ClickItemAsync(
        Func<TItem, ValueTask<bool>> predicate,
        LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(predicate).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<int> CountAsync()
    {
        await RootLocator.WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Attached }
        ).ConfigureAwait(false);

        return await itemsLocator.CountAsync().ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<ILocator>> GetItemLocatorsAsync()
    {
        await WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Attached }
        ).ConfigureAwait(false);

        return await itemsLocator.AllAsync().ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new ControlListAssertions(
        RootLocator.Expect(),
        itemsLocator.Expect(),
        itemsLocator.First.Expect());
}