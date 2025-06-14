using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ControlListExtensions
{
    public static async Task WaitToBeVisibleAsync<T>(
        this ControlList<T> controlList,
        LocatorAssertionsToBeVisibleOptions? options = default) where T : ControlBase
        => await controlList.ExpectV2().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync<T>(
        this ControlList<T> controlList,
        LocatorAssertionsToBeHiddenOptions? options = default) where T : ControlBase
        => await controlList.ExpectV2().ToBeHiddenAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveCountAsync<T>(
        this ControlList<T> controlList,
        int count,
        LocatorAssertionsToHaveCountOptions? options = default) where T : ControlBase
        => await controlList.ExpectV2().ToHaveCountAsync(count, options).ConfigureAwait(false);

    public static async Task WaitToToBeEmptyAsync<T>(
        this ControlList<T> controlList,
        LocatorAssertionsToHaveCountOptions? options = default) where T : ControlBase
        => await controlList.ExpectV2().ToHaveCountAsync(0, options).ConfigureAwait(false);

    public static async Task ClickFirstItemAsync<T>(
        this ControlList<T> controlList,
        LocatorClickOptions? options = default) where T : ControlBase
        => await controlList.ClickItemAsync(0, options).ConfigureAwait(false);

    public static async Task ClickLastItemAsync<T>(
        this ControlList<T> controlList,
        LocatorClickOptions? options = default) where T : ControlBase
    {
        var itemsCount = await controlList.CountAsync().ConfigureAwait(false);
        await controlList.ClickItemAsync(itemsCount - 1, options).ConfigureAwait(false);
    }

    public static async Task<T> GetSingleItemAsync<T>(this ControlList<T> controlList) where T : ControlBase
    {
        await controlList.ExpectV2().ToHaveCountAsync(1).ConfigureAwait(false);
        return await controlList.GetFirstItemAsync().ConfigureAwait(false);
    }

    [Obsolete("Используй GetItemAsync из ControlList")]
    public static async Task<T> GetSingleItemAsync<T>(
        this ControlList<T> controlList,
        Func<T, Task<bool>> predicate,
        int timeoutInMilliseconds = 10000)
        where T : ControlBase
    {
        var list = await controlList.GetItemsAsync(predicate, timeoutInMilliseconds).ConfigureAwait(false);
        return list.Single();
    }

    public static async Task<IReadOnlyList<TResult>> SelectAsync<TSource, TResult>(
        this ControlList<TSource> controlList,
        Func<TSource, ValueTask<TResult>> selector) where TSource : ControlBase
    {
        var items = await controlList.GetItemsAsync().ConfigureAwait(false);
        return await items.ToAsyncEnumerable().SelectAwait(selector).ToListAsync().ConfigureAwait(false);
    }
}