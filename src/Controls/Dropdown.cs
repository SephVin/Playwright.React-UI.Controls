using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Dropdown : ControlBase, IFocusable
{
    private readonly Portal portal;

    public Dropdown(ILocator rootLocator)
        : base(rootLocator)
    {
        ButtonLocator = rootLocator.Locator("button");
        portal = new Portal(rootLocator.Locator("noscript"));
    }

    public ILocator ButtonLocator { get; }

    public virtual async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await ButtonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsMenuOpenedAsync()
    {
        await WaitForAsync().ConfigureAwait(false);
        return await portal.IsVisibleAsync().ConfigureAwait(false);
    }

    public virtual async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await ButtonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectFirstByTextAsync(string text)
    {
        var item = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await item.First.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectByIndexAsync(Index index)
    {
        var items = await GetMenuItemsLocatorAsync(null).ConfigureAwait(false);
        await items.Nth(index.Value).ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectByDataTidAsync(string dataTid)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        var item = container.Locator($"[data-tid='{dataTid}]");

        if (await item.CountAsync().ConfigureAwait(false) > 1)
        {
            throw new Exception("DataTid должен быть уникальным");
        }

        await item.ClickAsync().ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await ButtonLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await ButtonLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await ButtonLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await ButtonLocator.BlurAsync().ConfigureAwait(false);

    public async Task<ControlList<MenuItem>> GetMenuItemsAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        await container.Locator("[data-tid='Spinner__root']")
            .WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden }).ConfigureAwait(false);

        return new ControlList<MenuItem>(
            container,
            locator =>
                locator.Locator("[data-tid='MenuItem__root']")
                    .Or(locator.Locator("[data-tid='MenuHeader__root']"))
                    .Or(locator.Locator("[data-tid='MenuFooter__root']")),
            locator => new MenuItem(locator)
        );
    }

    public async Task WaitItemWithTextAsync(string text)
    {
        var item = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await item.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new DropdownAssertions(RootLocator.Expect(), ButtonLocator.Expect());

    private async Task<ILocator> GetMenuItemsLocatorAsync(string? byText)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        var items = container.Locator("[data-tid='MenuItem__root']");

        return byText == null
            ? items
            : items.GetByText(byText);
    }

    private async Task<ILocator> GetPortalContainerAsync()
    {
        await OpenDropdownIfNeededAsync().ConfigureAwait(false);
        return await portal.GetContainerAsync().ConfigureAwait(false);
    }

    private async Task OpenDropdownIfNeededAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await ButtonLocator.ClickAsync().ConfigureAwait(false);
        }
    }
}