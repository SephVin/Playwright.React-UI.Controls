using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Kebab : ControlBase
{
    private readonly ILocator captionLocator;
    private readonly Portal portal;

    public Kebab(ILocator context)
        : base(context)
    {
        captionLocator = context.Locator("[data-tid='Kebab__caption']");
        portal = new Portal(context.Locator("noscript"));
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await captionLocator.GetAttributeValueAsync("tabindex", options).ConfigureAwait(false) is "-1";

    public async Task<bool> IsMenuOpenedAsync()
        => await portal.IsExistsInDomAsync().ConfigureAwait(false);

    public async Task SelectByTextAsync(string text, LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(text).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectByIndexAsync(Index index, LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        await items[index].ClickAsync(options).ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await captionLocator.ClickAsync().ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new KebabAssertions(Context.Expect(), captionLocator.Expect());

    private async Task<IReadOnlyList<ILocator>> GetItemsAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return await container.Locator("[data-tid='MenuItem__root']").AllAsync().ConfigureAwait(false);
    }

    private async Task<ILocator> GetItemAsync(string text)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']").GetByText(text);
    }

    private async Task<ILocator> GetPortalContainerAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await ClickAsync().ConfigureAwait(false);
        }

        return await portal.GetContainerAsync().ConfigureAwait(false);
    }
}