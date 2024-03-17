using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Dropdown : ControlBase
{
    private readonly ILocator buttonLocator;

    public Dropdown(ILocator context)
        : base(context)
    {
        buttonLocator = context.Locator("button");
        Portal = new Portal(context.Locator("noscript"));
    }

    protected Portal Portal { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await buttonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsMenuOpenedAsync()
        => await Portal.IsExistsInDomAsync().ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await buttonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectByTextAsync(string text, LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        var item = await items.ToAsyncEnumerable()
            .SingleAwaitAsync(async x => await x.InnerTextAsync().ConfigureAwait(false) == text)
            .ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectByIndexAsync(Index index, LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        await items[index].ClickAsync(options).ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => buttonLocator.Expect();

    private async Task<IReadOnlyList<ILocator>> GetItemsAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await buttonLocator.ClickAsync().ConfigureAwait(false);
        }

        var container = await Portal.GetContainerAsync().ConfigureAwait(false);

        return await container.Locator("[data-tid='MenuItem__root']").AllAsync().ConfigureAwait(false);
    }
}