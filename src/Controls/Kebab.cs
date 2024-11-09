using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Kebab : ControlBase
{
    private readonly Portal portal;

    public Kebab(ILocator rootLocator)
        : base(rootLocator)
    {
        CaptionLocator = rootLocator.Locator("[data-tid='Kebab__caption']");
        portal = new Portal(rootLocator.Locator("noscript"));
    }

    public ILocator CaptionLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await RootLocator.GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) == string.Empty;

    public async Task<bool> IsMenuOpenedAsync()
        => await portal.IsVisibleAsync().ConfigureAwait(false);

    public async Task SelectByTextAsync(string text, LocatorClickOptions? options = default)
    {
        var item = await GetItemAsync(text).ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectByIndexAsync(Index index, LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        await items.Nth(index.Value).ClickAsync(options).ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await CaptionLocator.ClickAsync().ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new KebabAssertions(RootLocator.Expect(), CaptionLocator.Expect());

    private async Task<ILocator> GetItemsAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']");
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