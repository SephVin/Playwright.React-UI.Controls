using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Select : ControlBase
{
    private readonly ILocator buttonLocator;
    private readonly ILocator linkLocator;
    private readonly Portal portal;

    public Select(ILocator context)
        : base(context)
    {
        portal = new Portal(context.Locator("noscript"));
        buttonLocator = context.Locator("[data-tid='Button__root']");
        linkLocator = context.Locator("[data-tid='Link__root']");
    }

    public async Task<bool> IsDisabledAsync()
    {
        await Context.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        if (await buttonLocator.IsVisibleAsync().ConfigureAwait(false))
        {
            return await buttonLocator.IsDisabledAsync().ConfigureAwait(false);
        }

        return await linkLocator.GetAttributeValueAsync("tabindex").ConfigureAwait(false) is "-1";
    }

    public async Task<string> GetValueAsync()
        => await Context.InnerTextAsync().ConfigureAwait(false);

    public async Task SelectValueAsync(string text)
    {
        await ClickAsync().ConfigureAwait(false);

        var items = await GetItemsAsync().ConfigureAwait(false);
        var value = await items.ToAsyncEnumerable()
            .FirstAwaitAsync(async x => (await x.InnerTextAsync().ConfigureAwait(false)).Equals(text))
            .ConfigureAwait(false);
        await value.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectFirstValueBySearchAsync(string text)
    {
        await ClickAsync().ConfigureAwait(false);

        var searchInput = await GetSearchInputAsync().ConfigureAwait(false);
        await searchInput.FillAsync(text).ConfigureAwait(false);
        var items = await GetItemsAsync().ConfigureAwait(false);
        var value = await items.ToAsyncEnumerable()
            .FirstAwaitAsync(async x => (await x.InnerTextAsync().ConfigureAwait(false)).Contains(text))
            .ConfigureAwait(false);
        await value.ClickAsync().ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new SelectAssertions(
        Context,
        Context.Expect(),
        buttonLocator,
        buttonLocator.Expect(),
        linkLocator,
        linkLocator.Expect());

    private async Task<IReadOnlyList<ILocator>> GetItemsAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);

        return await container.Locator("[data-tid='MenuItem__root']")
            .AllAsync()
            .ConfigureAwait(false);
    }

    private async Task<ILocator> GetSearchInputAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='Input__root']");
    }
}