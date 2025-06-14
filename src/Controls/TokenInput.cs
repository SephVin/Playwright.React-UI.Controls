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

    public async Task<bool> IsDisabledAsync()
        => await TextareaLocator.IsDisabledAsync().ConfigureAwait(false);

    public async Task FillAsync(string value)
        => await TextareaLocator.FillAsync(value).ConfigureAwait(false);

    public async Task ClearAsync()
    {
        var tokens = await Tokens.GetItemsAsync().ConfigureAwait(false);

        for (var i = tokens.Count - 1; i >= 0; i--)
        {
            await tokens[i].RemoveAsync().ConfigureAwait(false);
        }
    }

    public async Task RemoveTokenAsync(string text)
    {
        var token = await Tokens.GetFirstItemAsync(
            async token => (await token.GetTextAsync().ConfigureAwait(false)).Equals(
                text,
                StringComparison.OrdinalIgnoreCase)
        ).ConfigureAwait(false);

        await token.RemoveAsync().ConfigureAwait(false);
    }

    public async Task RemoveTokenAsync(int index)
    {
        var token = await Tokens.GetItemAsync(index).ConfigureAwait(false);
        await token.RemoveAsync().ConfigureAwait(false);
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
    public async Task SelectFirstAsync(string value)
    {
        var items = await GetMenuItemsLocatorAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    /// <summary>
    /// Используй этот метод, когда в меню существует несколько элементов с одинаковым названием
    /// В остальных случаях лучше использовать `SelectAsync`
    /// </summary>
    public async Task SelectFirstAsync(Regex regex)
    {
        var items = await GetMenuItemsLocatorAsync(regex).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectAsync(string value)
    {
        var items = await GetMenuItemsLocatorAsync(value).ConfigureAwait(false);
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
        await TextareaLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await TextareaLocator.ClickAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await TextareaLocator.BlurAsync().ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await TextareaLocator.ClickAsync().ConfigureAwait(false);

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