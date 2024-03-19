using System;
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

    public virtual async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await buttonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsMenuOpenedAsync()
        => await Portal.IsExistsInDomAsync().ConfigureAwait(false);

    public virtual async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await buttonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectByTextAsync(
        string text,
        bool isMenuClosedAfterSelect = true,
        LocatorClickOptions? options = default)
    {
        var item = await GetItemLocatorAsync(text).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            await Portal.Expect().ToHaveCountAsync(0).ConfigureAwait(false);
        }
    }

    public async Task SelectByIndexAsync(
        Index index,
        bool isMenuClosedAfterSelect = true,
        LocatorClickOptions? options = default)
    {
        var items = await GetItemsLocatorAsync().ConfigureAwait(false);
        await items.Nth(index.Value).ClickAsync(options).ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            await Portal.Expect().ToHaveCountAsync(0).ConfigureAwait(false);
        }
    }

    public async Task WaitItemWithTextAsync(string text)
    {
        var item = await GetItemLocatorAsync(text).ConfigureAwait(false);
        await item.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    public virtual async Task OpenDropdownIfNeededAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await buttonLocator.ClickAsync().ConfigureAwait(false);
        }
    }

    public override ILocatorAssertions Expect() => buttonLocator.Expect();

    protected async Task<ILocator> GetItemsLocatorAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']");
    }

    protected async Task<ILocator> GetItemLocatorAsync(string text)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']").GetByText(text);
    }

    private async Task<ILocator> GetPortalContainerAsync()
    {
        await OpenDropdownIfNeededAsync().ConfigureAwait(false);
        return await Portal.GetContainerAsync().ConfigureAwait(false);
    }
}