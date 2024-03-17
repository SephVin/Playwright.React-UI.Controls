using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ControlListExtensions
{
    public static async Task WaitPresenceAsync<T>(
        this ControlList<T> controlList,
        LocatorAssertionsToBeVisibleOptions? options = default) where T : ControlBase
        => await controlList.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitAbsenceAsync<T>(
        this ControlList<T> controlList,
        LocatorAssertionsToBeVisibleOptions? options = default) where T : ControlBase
        => await controlList.Expect().Not.ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitCountAsync<T>(
        this ControlList<T> controlList,
        int count,
        LocatorAssertionsToHaveCountOptions? options = default) where T : ControlBase
        => await controlList.Expect().ToHaveCountAsync(count, options).ConfigureAwait(false);

    public static async Task ClickFirstItemAsync<T>(
        this ControlList<T> controlList,
        LocatorClickOptions? options = default) where T : ControlBase
        => await controlList.ClickItemAsync(0, options).ConfigureAwait(false);

    public static async Task ClickLastItemAsync<T>(
        this ControlList<T> controlList,
        LocatorClickOptions? options = default) where T : ControlBase
        => await controlList.ClickItemAsync(^1, options).ConfigureAwait(false);

    public static async Task<T> GetFirstItemAsync<T>(this ControlList<T> controlList) where T : ControlBase
        => await controlList.GetItemAsync(0).ConfigureAwait(false);

    public static async Task<T> GetLastItemAsync<T>(this ControlList<T> controlList) where T : ControlBase
        => await controlList.GetItemAsync(^1).ConfigureAwait(false);

    public static async Task<T> GetSingleItemAsync<T>(this ControlList<T> controlList) where T : ControlBase
    {
        await controlList.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        return await controlList.GetFirstItemAsync().ConfigureAwait(false);
    }

    public static async Task<T> GetSingleItemAsync<T>(
        this ControlList<T> controlList,
        Func<T, ValueTask<bool>> predicate)
        where T : ControlBase
    {
        var list = await controlList.GetItemsAsync().ConfigureAwait(false);
        return await list.ToAsyncEnumerable().SingleAwaitAsync(predicate).ConfigureAwait(false);
    }

    public static async Task<IReadOnlyList<TResult>> SelectAsync<TSource, TResult>(
        this ControlList<TSource> controlList,
        Func<TSource, ValueTask<TResult>> selector) where TSource : ControlBase
    {
        var items = await controlList.GetItemsAsync().ConfigureAwait(false);
        return await items.ToAsyncEnumerable().SelectAwait(selector).ToListAsync().ConfigureAwait(false);
    }
}