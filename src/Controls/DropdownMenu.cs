using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class DropdownMenu : ControlBase
{
    private readonly Portal portal;

    public DropdownMenu(ILocator rootLocator)
        : base(rootLocator)
    {
        portal = new Portal(rootLocator.Locator("noscript"));
        CaptionLocator = RootLocator.Locator("[data-tid='PopupMenu__caption']");
    }

    public ILocator CaptionLocator { get; }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await CaptionLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task<bool> IsMenuOpenedAsync()
    {
        await WaitForAsync().ConfigureAwait(false);
        return await portal.IsVisibleAsync().ConfigureAwait(false);
    }

    public async Task SelectFirstByTextAsync(string text, bool isMenuClosedAfterSelect = true)
    {
        var item = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await SelectFirstAsync(item, isMenuClosedAfterSelect).ConfigureAwait(false);
    }

    public async Task SelectFirstByTextAsync(Regex regex, bool isMenuClosedAfterSelect = true)
    {
        var item = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await SelectFirstAsync(item, isMenuClosedAfterSelect).ConfigureAwait(false);
    }

    public async Task SelectByDataTidAsync(string dataTid, bool isMenuClosedAfterSelect = true)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        var item = container.Locator($"[data-tid='{dataTid}']");

        if (await item.CountAsync().ConfigureAwait(false) > 1)
        {
            throw new Exception("DataTid должен быть уникальным");
        }

        await item.ClickAsync().ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            // NOTE: ожидание закрытия меню, чтобы не было гонок, в случае, когда меню закрывается долго
            await portal.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
        }
    }

    public async Task SelectByIndexAsync(int index, bool isMenuClosedAfterSelect = true)
    {
        var items = await GetMenuItemsLocatorAsync().ConfigureAwait(false);
        await items.Nth(index).ClickAsync().ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            // NOTE: ожидание закрытия меню, чтобы не было гонок, в случае, когда меню закрывается долго
            await portal.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
        }
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await CaptionLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    /// <summary>
    ///     Возвращает список меню по data-tid из react-ui:
    ///         - MenuItem__root
    ///         - MenuHeader__root
    ///         - MenuFooter__root
    /// </summary>
    public async Task<ControlList<MenuItem>> GetMenuItemsAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        await container.Locator("[data-tid='Spinner__root']")
            .WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        return new ControlList<MenuItem>(
            container,
            locator =>
                locator.Locator("[data-tid='MenuItem__root']")
                    .Or(locator.Locator("[data-tid='MenuHeader__root']"))
                    .Or(locator.Locator("[data-tid='MenuFooter__root']")),
            locator => new MenuItem(locator)
        );
    }

    public async Task<MenuItem> GetMenuItemAsync(string text)
    {
        var items = await GetMenuItemsAsync().ConfigureAwait(false);

        return await items.GetFirstItemAsync(
            async item =>
            {
                var itemText = await item.GetTextAsync().ConfigureAwait(false);
                return itemText.Equals(text, StringComparison.OrdinalIgnoreCase);
            }
        ).ConfigureAwait(false);
    }

    public async Task<MenuItem> GetMenuItemAsync(int index)
    {
        var items = await GetMenuItemsAsync().ConfigureAwait(false);
        return items.GetItem(index);
    }

    [Obsolete("Используй ToContainItems из DropdownAssertionsV2. Или WaitToContainItems из Control.Extensions")]
    public async Task WaitItemWithTextAsync(string text)
    {
        var item = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await item.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect()
        => new DropdownMenuAssertions(RootLocator.Expect(), CaptionLocator.Expect());

    public new DropdownMenuAssertionsV2 ExpectV2() => new(this);

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
            await CaptionLocator.ClickAsync().ConfigureAwait(false);
        }

        return await portal.GetContainerAsync().ConfigureAwait(false);
    }

    private async Task SelectFirstAsync(ILocator item, bool isMenuClosedAfterSelect = true)
    {
        await item.First.ClickAsync().ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            // NOTE: ожидание закрытия меню, чтобы не было гонок, в случае, когда меню закрывается долго
            await portal.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
        }
    }
}