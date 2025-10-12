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

    /// <summary>
    ///     Поведение метода идентично вызову Locator.All()
    ///
    ///     getItems не ждет появления элементов, соответствующих локатору, а сразу возвращает всё, что есть на странице в данный момент.
    ///     Когда список элементов меняется динамически, использование getItems приведёт к непредсказуемым и нестабильным результатам.
    ///     Когда список элементов стабилен, но загружается динамически, необходимо дождаться полной загрузки списка перед вызовом getItems
    /// </summary>
    public async Task<IReadOnlyList<TItem>> GetItemsAsync()
    {
        var itemLocators = await GetItemLocatorsAsync().ConfigureAwait(false);
        return itemLocators.Select(x => itemFactory(x)).ToList();
    }

    /// <summary>
    ///     Поведение метода идентично вызову Locator.Nth(0)
    /// </summary>
    public TItem GetFirstItem() => GetItem(0);

    /// <summary>
    ///     Поведение метода идентично вызову Locator.Nth(-1)
    /// </summary>
    public async Task<TItem> GetLastItemAsync()
    {
        var itemsCount = await CountAsync().ConfigureAwait(false);
        return GetItem(itemsCount - 1);
    }

    /// <summary>
    ///     Поведение метода идентично вызову Locator.Nth(index)
    /// </summary>
    public TItem GetItem(int index) => itemFactory(ItemsLocator.Nth(index));

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
        var item = GetItem(index);
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