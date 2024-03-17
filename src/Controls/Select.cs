using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Select : ControlBase
{
    private readonly Portal portal;
    private readonly ILocator buttonOrLinkLocator;

    public Select(ILocator context)
        : base(context)
    {
        portal = new Portal(context.Locator("noscript"));
        buttonOrLinkLocator = context
            .Locator("[data-tid='Button__root']")
            .Or(context.Locator("[data-tid='Link__root']"));
    }

    public async Task<bool> IsDisabledAsync()
    {
        if (await IsLinkAsync().ConfigureAwait(false))
        {
            return await buttonOrLinkLocator.GetAttributeValueAsync("tabindex").ConfigureAwait(false) is "-1";
        }

        return await buttonOrLinkLocator.IsDisabledAsync().ConfigureAwait(false);
    }

    public async Task<string> GetSelectedValueAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectValueAsync(string text)
    {
        await ClickAsync().ConfigureAwait(false);
        var items = await GetItemsByTextAsync(text).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    public async Task SelectFirstValueBySearchAsync(string text)
    {
        await ClickAsync().ConfigureAwait(false);

        var searchInput = await GetSearchInputAsync().ConfigureAwait(false);
        await searchInput.FillAsync(text).ConfigureAwait(false);
        var items = await GetItemsByTextAsync(text).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
    }

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new SelectAssertions(
        Context.Expect(),
        buttonOrLinkLocator.Expect(),
        buttonOrLinkLocator);

    private async Task<ILocator> GetItemsByTextAsync(string text)
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='MenuItem__root']").GetByText(text);
    }

    private async Task<ILocator> GetSearchInputAsync()
    {
        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return container.Locator("[data-tid='Input__root']");
    }

    private async Task<bool> IsLinkAsync()
        => await buttonOrLinkLocator.GetAttributeAsync("href").ConfigureAwait(false) != null;
}