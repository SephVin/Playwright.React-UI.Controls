using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Autocomplete : Input
{
    private readonly Portal portal;

    public Autocomplete(ILocator context)
        : base(context)
    {
        portal = new Portal(context.Locator("noscript"));
    }

    public async Task SelectSuggestionAsync(Index index, LocatorClickOptions? options = default)
    {
        var suggestions = await GetSuggestionsAsync().ConfigureAwait(false);
        await suggestions[index].ClickAsync(options).ConfigureAwait(false);
    }

    private async Task<IReadOnlyList<ILocator>> GetSuggestionsAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return await container.Locator("[data-tid='MenuItem__root']").AllAsync().ConfigureAwait(false);
    }
}