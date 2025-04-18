using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Paging : ControlBase
{
    private readonly Label nextPage;

    public Paging(ILocator context)
        : base(context)
    {
        Pages = new ControlList<Label>(
            context,
            locator => locator.Locator("[data-tid='Paging__pageLink']"),
            x => new Label(x));
        nextPage = new Label(context.Locator("[data-tid='Paging__forwardLink']"));
    }

    public ControlList<Label> Pages { get; }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("tabindex", options).ConfigureAwait(false) is "-1";

    public async Task<int> GetPagesCountAsync(LocatorGetAttributeOptions? options = default)
    {
        var attributeValue = await GetAttributeValueAsync("data-pagescount", options).ConfigureAwait(false);

        if (int.TryParse(attributeValue, out var pagesCount))
        {
            return pagesCount;
        }

        throw new InvalidOperationException(
            "Can't get pages count. Maybe 'data-pagescount' attribute is not set or it's equal to Infinity");
    }

    public async Task GoToPageAsync(int pageNumber, LocatorClickOptions? options = default)
    {
        await CheckPageConstraintAsync(pageNumber).ConfigureAwait(false);

        try
        {
            var page = await Pages
                .GetItemAsync(async x => (await x.GetTextAsync().ConfigureAwait(false)).Equals(pageNumber.ToString()))
                .ConfigureAwait(false);
            await page.ClickAsync(options).ConfigureAwait(false);
        }
        catch (InvalidOperationException)
        {
            throw new InvalidOperationException($"Page with number {pageNumber} is not visible or exist");
        }
    }

    public async Task GoToLastPageAsync(LocatorClickOptions? options = default)
    {
        var pagesCount = await GetPagesCountAsync().ConfigureAwait(false);
        await CheckPageConstraintAsync(pagesCount).ConfigureAwait(false);
        var page = await Pages.GetItemAsync(await Pages.CountAsync().ConfigureAwait(false) - 1).ConfigureAwait(false);
        await page.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<int> GetActivePageNumberAsync(LocatorGetAttributeOptions? options = default)
    {
        var attributeValue = await GetAttributeValueAsync("data-active", options).ConfigureAwait(false);

        if (int.TryParse(attributeValue, out var activePageNumber))
        {
            return activePageNumber;
        }

        throw new InvalidOperationException(
            "Can't get Active page number. Maybe 'data-active' attribute is not set");
    }

    public async Task GoToNextPageAsync(LocatorClickOptions? options = default)
    {
        var activePage = await GetActivePageNumberAsync().ConfigureAwait(false);
        var pagesCount = await GetPagesCountAsync().ConfigureAwait(false);

        if (activePage < pagesCount)
        {
            await nextPage.ClickAsync(options).ConfigureAwait(false);
        }
        else
        {
            throw new InvalidOperationException("Can't go to next page. Current page is the last");
        }
    }

    public override ILocatorAssertions Expect() => new PagingAssertions(RootLocator.Expect(), Pages.Expect());

    private async Task CheckPageConstraintAsync(int pageNumber)
    {
        if (await GetActivePageNumberAsync().ConfigureAwait(false) == pageNumber)
        {
            throw new InvalidOperationException("Can't go to active page");
        }
    }
}