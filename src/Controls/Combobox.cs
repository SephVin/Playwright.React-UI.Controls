using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

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

        return await InputLikeTextLocator.InnerTextAsync().ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(string value, LocatorClickOptions? options = default)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync(options).ConfigureAwait(false);
    }

    /// <summary>
    ///     Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    ///     В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(Regex value, LocatorClickOptions? options = default)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectAsync(string value, LocatorClickOptions? options = default)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.Expect()
            .ToHaveCountAsync(1, new LocatorAssertionsToHaveCountOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await items.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectAsync(Regex value, LocatorClickOptions? options = default)
    {
        var items = await GetComboboxMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.Expect()
            .ToHaveCountAsync(1, new LocatorAssertionsToHaveCountOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await items.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
    {
        await FocusAsync(new LocatorFocusOptions { Timeout = options?.Timeout }).ConfigureAwait(false);
        await NativeInputLocator.FillAsync(value, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorClearOptions? options = default)
    {
        await FocusAsync(new LocatorFocusOptions { Timeout = options?.Timeout }).ConfigureAwait(false);
        await NativeInputLocator.ClearAsync(options).ConfigureAwait(false);
    }

    public async Task FocusAsync(LocatorFocusOptions? options = default)
    {
        await NativeInputLocator.Expect()
            .ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await RootLocator
            .Locator("input[type='text']")
            .Or(RootLocator.Locator("[data-tid='InputLikeText__root']"))
            .FocusAsync(options)
            .ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await NativeInputLocator.PressAsync(
            "Tab",
            new LocatorPressOptions { Timeout = options?.Timeout }
        ).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        // NOTE: rootLocator всегда в состоянии enabled, даже если ComboBox disabled
        await ExpectV2()
            .ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    /// <summary>
    ///     Возвращает список меню по data-tid из react-ui:
    ///         - MenuItem__root
    ///         - MenuMessage__root
    ///         - ComboBoxMenu__item
    ///         - ComboBoxMenu__notFound
    ///         - MenuHeader__root
    ///         - MenuFooter__root
    /// </summary>
    public async Task<ControlList<MenuItem>> GetMenuItemsAsync()
    {
        await FocusAsync().ConfigureAwait(false);
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        await container.Locator("[data-tid='Spinner__root']")
            .WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        return new ControlList<MenuItem>(
            container,
            locator =>
                locator.Locator("[data-tid='MenuItem__root']")
                    .Or(locator.Locator("[data-tid='MenuMessage__root']"))
                    .Or(locator.Locator("[data-tid='ComboBoxMenu__item']"))
                    .Or(locator.Locator("[data-tid='ComboBoxMenu__notFound']"))
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

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect()
        => new ComboboxAssertions(
            this,
            RootLocator.Expect(),
            NativeInputLocator.Expect(),
            InputLikeTextLocator.Expect());

    public new ComboBoxAssertionsV2 ExpectV2() => new(this);
}