using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Combobox : ControlBase
{
    private readonly ILocator inputLocator;
    private readonly Portal portal;

    public Combobox(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("input");
        portal = new Portal(context.Locator("noscript"));
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await inputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetSelectedValueAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectFirstAsync(string value, LocatorFillOptions? options = default)
    {
        await FillAsync(value, options).ConfigureAwait(false);
        var items = await GetItemsByValueAsync(value).ConfigureAwait(false);
        await items.First.ClickAsync().ConfigureAwait(false);
        await BlurAsync().ConfigureAwait(false);
    }

    public async Task SelectSingleAsync(string value, LocatorFillOptions? options = default)
    {
        await FillAsync(value, options).ConfigureAwait(false);
        var items = await GetItemsByValueAsync(value).ConfigureAwait(false);
        await items.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        await items.ClickAsync().ConfigureAwait(false);
        await BlurAsync().ConfigureAwait(false);
    }

    public async Task FillAsync(string text, LocatorFillOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await inputLocator.FillAsync(text, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorClearOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await inputLocator.ClearAsync(options).ConfigureAwait(false);
    }

    public async Task FocusAsync(LocatorClickOptions? options = default)
        => await ClickAsync(options).ConfigureAwait(false);

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await inputLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await base.ClickAsync(options).ConfigureAwait(false);
    }

    private async Task<ILocator> GetItemsByValueAsync(string value)
    {
        var portalContainer = await portal.GetContainerAsync().ConfigureAwait(false);
        return portalContainer.Locator("[data-tid='ComboBoxMenu__item']").GetByText(value);
    }

    public override ILocatorAssertions Expect() => new ComboboxAssertions(Context.Expect(), inputLocator.Expect());
}