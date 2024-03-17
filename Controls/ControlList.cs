using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class ControlList<TItem> : ControlBase where TItem : ControlBase
{
    private readonly Func<ILocator, TItem> itemFactory;
    private readonly ILocator items;

    public ControlList(ILocator context, string itemSelector, Func<ILocator, TItem> itemFactory)
        : base(context)
    {
        this.itemFactory = itemFactory;
        items = context.Locator(itemSelector);
    }

    public async Task<IReadOnlyList<TItem>> GetItemsAsync()
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemLocators.Select(x => itemFactory(x)).ToList();
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

    public async Task ClickItemAsync(Index index, LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(index).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task ClickItemAsync(
        Func<TItem, ValueTask<bool>> predicate,
        LocatorClickOptions? options = default)
    {
        var list = await GetItemsAsync().ConfigureAwait(false);
        var item = await list.ToAsyncEnumerable().SingleAwaitAsync(predicate).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<int> CountAsync()
        => await items.CountAsync().ConfigureAwait(false);

    public async Task WaitCountAsync(int count, LocatorAssertionsToHaveCountOptions? options = default)
        => await items.Expect().ToHaveCountAsync(count, options).ConfigureAwait(false);

    public async Task WaitPresenceAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await items.First.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task WaitAbsenceAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await items.Expect().ToHaveCountAsync(0, options).ConfigureAwait(false);

    private async Task<IReadOnlyList<ILocator>> GetItemLocatorsAsync()
    {
        await Context.Expect().ToBeVisibleAsync().ConfigureAwait(false);
        return await items.AllAsync().ConfigureAwait(false);
    }
}