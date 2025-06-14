using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class Select : ControlBase, IFocusable
{
    private readonly Portal portal;

    public Select(ILocator rootLocator)
        : base(rootLocator)
    {
        portal = new Portal(rootLocator.Locator("noscript"));
        ButtonOrLinkLocator = rootLocator
            .Locator("button")
            .Or(rootLocator.Locator("[data-tid='Link__root']"));
        SelectLabelLocator = RootLocator.Locator("[data-tid='Select__label']");
    }

    public ILocator ButtonOrLinkLocator { get; }
    public ILocator SelectLabelLocator { get; }

    public async Task<bool> IsDisabledAsync()
    {
        if (await IsLinkSelectAsync().ConfigureAwait(false))
        {
            return await ButtonOrLinkLocator
                .GetAttributeValueAsync(DataVisualState.Disabled).ConfigureAwait(false) != null;
        }

        return await ButtonOrLinkLocator.IsDisabledAsync().ConfigureAwait(false);
    }

    public async Task<bool> IsMenuOpenedAsync()
        => await portal.IsVisibleAsync().ConfigureAwait(false);

    public async Task<bool> IsLinkSelectAsync()
        => await ButtonOrLinkLocator.GetAttributeAsync("type").ConfigureAwait(false) != "button";

    public async Task<string> GetSelectedValueAsync(LocatorInnerTextOptions? options = default)
        => await ButtonOrLinkLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task FillSearchAsync(string text)
    {
        var searchInput = await GetSearchInputAsync().ConfigureAwait(false);
        await searchInput.FillAsync(text).ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(string text)
    {
        var items = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(Regex regex)
    {
        var items = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectAsync(string text)
    {
        var items = await GetMenuItemsLocatorAsync(text).ConfigureAwait(false);
        await items.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectAsync(Regex regex)
    {
        var items = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await items.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
    }

    public async Task FocusAsync()
    {
        await WaitToBeEnabledAsync().ConfigureAwait(false);
        await ButtonOrLinkLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await ButtonOrLinkLocator.BlurAsync().ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await WaitToBeEnabledAsync().ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
    {
        await ClickAsync().ConfigureAwait(false);
        return await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);
    }

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

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new SelectAssertions(
        RootLocator.Expect(),
        ButtonOrLinkLocator.Expect(),
        SelectLabelLocator.Expect(),
        ButtonOrLinkLocator);

    public new SelectAssertionsV2 ExpectV2() => new(this);

    private async Task<ILocator> GetMenuItemsLocatorAsync(string text)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']").GetByText(text);
    }

    private async Task<ILocator> GetMenuItemsLocatorAsync(Regex regex)
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']").GetByText(regex);
    }

    private async Task<ILocator> GetSearchInputAsync()
    {
        var container = await GetPortalContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='Input__root']");
    }

    private async Task<ILocator> GetPortalContainerAsync()
    {
        await OpenMenuIfNeededAsync().ConfigureAwait(false);
        return await portal.GetContainerAsync().ConfigureAwait(false);
    }

    private async Task OpenMenuIfNeededAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await ButtonOrLinkLocator.ClickAsync().ConfigureAwait(false);
        }
    }

    private async Task WaitToBeEnabledAsync()
    {
        if (await IsLinkSelectAsync().ConfigureAwait(false))
        {
            await ButtonOrLinkLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Disabled, "")
                .ConfigureAwait(false);
        }
        else
        {
            await ButtonOrLinkLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        }
    }
}