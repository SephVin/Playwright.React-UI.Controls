using System;
using System.Text.RegularExpressions;
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
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) != null;

    public async Task<bool> IsMenuOpenedAsync()
        => await portal.IsVisibleAsync().ConfigureAwait(false);

    public async Task SelectFirstByTextAsync(string text, LocatorClickOptions? options = default)
    {
        var item = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await item.First.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectFirstByTextAsync(Regex regex, LocatorClickOptions? options = default)
    {
        var item = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await item.First.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectByIndexAsync(int index, LocatorClickOptions? options = default)
    {
        var items = await GetMenuItemsLocatorAsync().ConfigureAwait(false);
        await items.Nth(index).ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectByDataTidAsync(string dataTid, LocatorClickOptions? options = default)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        var item = container.Locator($"[data-tid='{dataTid}']");

        if (await item.CountAsync().ConfigureAwait(false) > 1)
        {
            throw new Exception("DataTid должен быть уникальным");
        }

        await item.ClickAsync(options).ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
        await CaptionLocator.ClickAsync().ConfigureAwait(false);
    }

    public async Task<ControlList<MenuItem>> GetMenuItemsAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);

        return new ControlList<MenuItem>(
            container,
            locator => locator.Locator("[data-tid='MenuItem__root']"),
            locator => new MenuItem(locator)
        );
    }

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new KebabAssertions(RootLocator.Expect(), CaptionLocator.Expect());

    public new KebabAssertionsV2 ExpectV2() => new(this);

    private async Task<ILocator> GetMenuItemsLocatorAsync(string byText)
    {
        var items = await GetMenuItemsLocatorAsync().ConfigureAwait(false);
        return items.GetByText(byText);
    }

    private async Task<ILocator> GetMenuItemsLocatorAsync(Regex regex)
    {
        var items = await GetMenuItemsLocatorAsync().ConfigureAwait(false);
        return items.GetByText(regex);
    }

    private async Task<ILocator> GetMenuItemsLocatorAsync()
    {
        var portalContainer = await GetPortalContainerAsync().ConfigureAwait(false);
        return portalContainer.Locator("[data-tid='MenuItem__root']");
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