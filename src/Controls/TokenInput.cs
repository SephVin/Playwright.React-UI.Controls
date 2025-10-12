using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class TokenInput : ControlBase, IFocusable
{
    private readonly Portal portal;

    public TokenInput(ILocator rootLocator)
        : base(rootLocator)
    {
        portal = new Portal(rootLocator.Locator("noscript"));
        TextareaLocator = rootLocator.Locator("textarea");
        Tokens = new ControlList<Token>(
            rootLocator,
            locator => locator.Locator("[data-tid='Token__root']"),
            locator => new Token(locator)
        );
    }

    public ILocator TextareaLocator { get; }
    public ControlList<Token> Tokens { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await TextareaLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
        => await TextareaLocator.FillAsync(value, options).ConfigureAwait(false);

    public async Task ClearAsync(LocatorClickOptions? options = default)
    {
        var tokens = await Tokens.GetItemsAsync().ConfigureAwait(false);

        for (var i = tokens.Count - 1; i >= 0; i--)
        {
            await tokens[i].RemoveAsync(options).ConfigureAwait(false);
        }
    }

    public async Task RemoveTokenAsync(string text, LocatorClickOptions? options = default)
    {
        var token = await Tokens.GetFirstItemAsync(
            async token =>
            {
                var tokenText = await token.GetTextAsync().ConfigureAwait(false);
                return tokenText.Equals(text, StringComparison.OrdinalIgnoreCase);
            }).ConfigureAwait(false);

        await token.RemoveAsync(options).ConfigureAwait(false);
    }

    public async Task RemoveTokenAsync(int index, LocatorClickOptions? options = default)
    {
        var token = Tokens.GetItem(index);
        await token.RemoveAsync(options).ConfigureAwait(false);
    }

    /// <summary>
    /// Символ, который разделяет введенный текст на токены. По умолчанию - запятая
    /// </summary>
    public async Task AddAsync(char delimiter = ',')
        => await TextareaLocator.PressAsync(delimiter.ToString()).ConfigureAwait(false);

    /// <summary>
    /// Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    /// В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(string value, LocatorClickOptions? options = default)
    {
        var items = await GetMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync(options).ConfigureAwait(false);
    }

    /// <summary>
    /// Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    /// В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(Regex regex, LocatorClickOptions? options = default)
    {
        var items = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await items.First.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectAsync(string value, LocatorClickOptions? options = default)
    {
        var items = await GetMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.Expect()
            .ToHaveCountAsync(1, new LocatorAssertionsToHaveCountOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await items.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectAsync(Regex regex, LocatorClickOptions? options = default)
    {
        var items = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await items.Expect()
            .ToHaveCountAsync(1, new LocatorAssertionsToHaveCountOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
    }

    public async Task FocusAsync(LocatorFocusOptions? options = default)
    {
        await ExpectV2()
            .ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await TextareaLocator.ClickAsync(new LocatorClickOptions { Timeout = options?.Timeout }).ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await TextareaLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await TextareaLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    /// <summary>
    /// Возвращает список меню по data-tid из react-ui:
    ///     - ComboBoxMenu__item
    ///     - MenuHeader__root
    ///     - MenuFooter__root
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
                    .Or(locator.Locator("[data-tid='ComboBoxMenu__item']"))
                    .Or(locator.Locator("[data-tid='MenuHeader__root']"))
                    .Or(locator.Locator("[data-tid='MenuFooter__root']")),
            locator => new MenuItem(locator)
        );
    }

    public new TokenInputAssertionsV2 ExpectV2() => new(this);

    private async Task<ILocator> GetMenuItemsLocatorAsync(string byText)
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        var items = container.Locator("[data-tid='ComboBoxMenu__item']");

        return items.GetByText(byText);
    }

    private async Task<ILocator> GetMenuItemsLocatorAsync(Regex byRegex)
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        var items = container.Locator("[data-tid='ComboBoxMenu__item']");

        return items.GetByText(byRegex);
    }
}