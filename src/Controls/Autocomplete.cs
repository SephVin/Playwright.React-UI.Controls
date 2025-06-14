using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class Autocomplete : ControlBase
{
    private readonly Portal portal;

    public Autocomplete(ILocator rootLocator)
        : base(rootLocator)
    {
        portal = new Portal(rootLocator.Locator("noscript"));
        InputLocator = rootLocator.Locator("input");
    }

    public ILocator InputLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await InputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await InputLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await ClearAsync().ConfigureAwait(false);
        await InputLocator.FillAsync(value, options).ConfigureAwait(false);
    }

    public async Task PressAsync(string value, LocatorPressOptions? options = default)
        => await InputLocator.PressAsync(value, options).ConfigureAwait(false);

    public async Task PressSequentiallyAsync(string value, LocatorPressSequentiallyOptions? options = default)
        => await InputLocator.PressSequentiallyAsync(value, options).ConfigureAwait(false);

    public async Task ClearAsync(LocatorClearOptions? options = default)
        => await InputLocator.ClearAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await InputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await InputLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await InputLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await InputLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public async Task SelectFirstSuggestionAsync(LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions.First.ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectSuggestionAsync(int index, LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions.Nth(index).ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectSuggestionAsync(string text, LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions.GetByText(text).ClickAsync(options).ConfigureAwait(false);
    }

    public async Task SelectSuggestionAsync(Regex regex, LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions.GetByText(regex).ClickAsync(options).ConfigureAwait(false);
    }

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new InputAssertions(RootLocator.Expect(), InputLocator.Expect());

    public new AutocompleteAssertionsV2 ExpectV2() => new(this);

    private async Task<ILocator> GetSuggestionsAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']");
    }
}