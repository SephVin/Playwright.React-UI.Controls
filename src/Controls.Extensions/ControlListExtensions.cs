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
    {
        var item = await controlList.GetFirstAsync().ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public static async Task ClickLastItemAsync<T>(
        this ControlList<T> controlList,
        LocatorClickOptions? options = default) where T : ControlBase
    {
        var item = await controlList.GetLastAsync().ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public static async Task<T> GetFirstAsync<T>(this ControlList<T> controlList) where T : ControlBase
        => await controlList.GetItemAsync(0).ConfigureAwait(false);

    public static async Task<T> GetLastAsync<T>(this ControlList<T> controlList) where T : ControlBase
        => await controlList.GetItemAsync(^1).ConfigureAwait(false);

    public static async Task<T> GetSingleAsync<T>(this ControlList<T> controlList) where T : ControlBase
    {
        await controlList.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        return await controlList.GetFirstAsync().ConfigureAwait(false);
    }

    public static async Task<IReadOnlyList<TResult>> SelectAsync<TSource, TResult>(
        this ControlList<TSource> controlList,
        Func<TSource, ValueTask<TResult>> selector) where TSource : ControlBase
    {
        var items = await controlList.GetItemsAsync().ConfigureAwait(false);
        return await items.ToAsyncEnumerable().SelectAwait(selector).ToListAsync().ConfigureAwait(false);
    }
}