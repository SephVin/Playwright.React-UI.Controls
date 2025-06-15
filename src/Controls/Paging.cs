using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Paging : ControlBase
{
    private readonly Label nextPage;

    public Paging(ILocator context)
        : base(context)
    {
        Pages = new ControlList<Page>(
            context,
            locator => locator.Locator("[data-tid='Paging__pageLinkWrapper']"),
            x => new Page(x));
        nextPage = new Label(context.Locator("[data-tid='Paging__forwardLink']"));
    }

    public ControlList<Page> Pages { get; }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) != null;

    public async Task<int> GetPagesCountAsync()
    {
        var lastPage = await Pages.GetLastItemAsync().ConfigureAwait(false);

        try
        {
            return await lastPage.GetNumberAsync().ConfigureAwait(false);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Не удалось получить количество страниц");
        }
    }

    public async Task GoToPageAsync(int pageNumber, LocatorClickOptions? options = default)
    {
        await CheckPageConstraintAsync(pageNumber).ConfigureAwait(false);

        try
        {
            var page = await Pages
                .GetItemAsync(
                    async x => (await x.GetTextAsync().ConfigureAwait(false)).Equals(pageNumber.ToString()),
                    (int)(options?.Timeout ?? 10000f))
                .ConfigureAwait(false);
            await page.ClickAsync(options).ConfigureAwait(false);
        }
        catch (TimeoutException)
        {
            throw new TimeoutException($"Страницы с номером {pageNumber} не существует");
        }
    }

    public async Task GoToLastPageAsync(LocatorClickOptions? options = default)
    {
        var lastPage = await Pages.GetLastItemAsync().ConfigureAwait(false);

        try
        {
            var lastPageNumber = await lastPage.GetNumberAsync().ConfigureAwait(false);
            await CheckPageConstraintAsync(lastPageNumber).ConfigureAwait(false);
            await lastPage.ClickAsync(options).ConfigureAwait(false);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException("Не удалось получить номер последней страницы");
        }
    }

    public async Task<int> GetActivePageNumberAsync()
    {
        var pageItem = await Pages
            .GetItemAsync(async x => await x.HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false))
            .ConfigureAwait(false);

        return await pageItem.GetNumberAsync().ConfigureAwait(false);
    }

    public async Task GoToNextPageAsync(LocatorClickOptions? options = default)
    {
        if (await nextPage.IsDisabledAsync().ConfigureAwait(false))
        {
            throw new InvalidOperationException("Нельзя перейти на следующую страницу. Текущая страница последняя");
        }

        await nextPage.ClickAsync(options).ConfigureAwait(false);
    }

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new PagingAssertions(this, RootLocator.Expect(), Pages.Expect());

    public new PagingAssertionsV2 ExpectV2() => new(this);

    private async Task CheckPageConstraintAsync(int pageNumber)
    {
        if (await GetActivePageNumberAsync().ConfigureAwait(false) == pageNumber)
        {
            throw new InvalidOperationException("Нельзя перейти на страницу, на которой уже находишься");
        }
    }
}

public class Page : Label
{
    internal Page(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsActiveAsync()
        => await GetAttributeValueAsync(DataVisualState.Active).ConfigureAwait(false) != null;

    public async Task<int> GetNumberAsync()
    {
        var pageNumber = await RootLocator.Locator("[data-tid='Paging__pageLink']").InnerTextAsync()
            .ConfigureAwait(false);

        if (int.TryParse(pageNumber, out var activePageNumber))
        {
            return activePageNumber;
        }

        throw new InvalidOperationException("Не удалось получить номер текущей страницы");
    }
}