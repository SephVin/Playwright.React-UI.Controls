using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Autocomplete : Input
{
    private readonly Portal portal;

    public Autocomplete(ILocator rootLocator)
        : base(rootLocator)
    {
        portal = new Portal(rootLocator.Locator("noscript"));
    }

    public async Task SelectSuggestionAsync(Index index, LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions.Nth(index.Value).ClickAsync(options).ConfigureAwait(false);
    }

    private async Task<ILocator> GetSuggestionsAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']");
    }
}