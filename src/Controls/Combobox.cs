using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Combobox : ControlBase, IFocusable
{
    private readonly Portal portal;

    public Combobox(ILocator rootLocator)
        : base(rootLocator)
    {
        NativeInputLocator = rootLocator.Locator("input");
        InputLikeTextLocator = rootLocator.Locator("[data-tid='InputLikeText__input']");
        portal = new Portal(rootLocator.Locator("noscript"));
    }

    public ILocator NativeInputLocator { get; }
    public ILocator InputLikeTextLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await NativeInputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsFocusedAsync()
        => await NativeInputLocator.GetAttributeValueAsync("type").ConfigureAwait(false) != "hidden";

    public async Task<string> GetSelectedValueAsync()
    {
        if (await IsFocusedAsync().ConfigureAwait(false))
        {
            return await NativeInputLocator.InputValueAsync().ConfigureAwait(false);
        }

        return await RootLocator.InnerTextAsync().ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(string value)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(Regex value)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectAsync(string value)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectAsync(Regex value)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
    }

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await NativeInputLocator.FillAsync(value, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorClearOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await NativeInputLocator.ClearAsync(options).ConfigureAwait(false);
    }

    public async Task FocusAsync()
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);

        if (await IsFocusedAsync().ConfigureAwait(false))
        {
            await NativeInputLocator.FocusAsync().ConfigureAwait(false);
        }
        else
        {
            await RootLocator.Locator("[data-tid='InputLikeText__root']").FocusAsync().ConfigureAwait(false);
        }
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await NativeInputLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        // NOTE: rootLocator всегда в состоянии enabled, даже если ComboBox disabled
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public async Task<ControlList<MenuItem>> GetMenuItemsAsync()
    {
        await FocusAsync().ConfigureAwait(false);
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        await container.Locator("[data-tid='Spinner__root']")
            .WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden }).ConfigureAwait(false);

        return new ControlList<MenuItem>(
            container,
            locator =>
                locator.Locator("[data-tid='MenuItem__root']")
                    .Or(locator.Locator("[data-tid='ComboBoxMenu__item']"))
                    .Or(locator.Locator("[data-tid='MenuHeader__root']"))
                    .Or(locator.Locator("[data-tid='MenuFooter__root']")),
            locator => new MenuItem(locator)
        );
    }

    private async Task<ILocator> GetComboboxMenuItemsLocatorAsync(string byText)
    {
        var items = await GetComboboxMenuItemsLocatorAsync().ConfigureAwait(false);
        return items.GetByText(byText);
    }

    private async Task<ILocator> GetComboboxMenuItemsLocatorAsync(Regex byText)
    {
        var items = await GetComboboxMenuItemsLocatorAsync().ConfigureAwait(false);
        return items.GetByText(byText);
    }

    private async Task<ILocator> GetComboboxMenuItemsLocatorAsync()
    {
        var portalContainer = await portal.GetContainerAsync().ConfigureAwait(false);
        return portalContainer.Locator("[data-tid='ComboBoxMenu__item']");
    }

    public override ILocatorAssertions Expect()
        => new ComboboxAssertions(this, RootLocator.Expect(), NativeInputLocator.Expect(), InputLikeTextLocator.Expect());
}