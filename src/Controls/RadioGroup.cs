using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class RadioGroup : ControlBase
{
    private readonly ControlList<Radio> list;

    public RadioGroup(ILocator rootLocator)
        : base(rootLocator)
    {
        list = new ControlList<Radio>(
            rootLocator,
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
    }

    public async Task<IReadOnlyList<Radio>> GetItemsAsync()
        => await list.GetItemsAsync().ConfigureAwait(false);

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) != null;

    public async Task CheckByValueAsync(string value)
    {
        var radio = await GetByValueAsync(value).ConfigureAwait(false);
        await radio.CheckAsync().ConfigureAwait(false);
    }

    public async Task CheckByIndexAsync(int index)
    {
        var radio = await GetByIndexAsync(index).ConfigureAwait(false);
        await radio.CheckAsync().ConfigureAwait(false);
    }

    public async Task CheckByTextAsync(string text)
    {
        var radio = await GetByTextAsync(text).ConfigureAwait(false);
        await radio.CheckAsync().ConfigureAwait(false);
    }

    public async Task<Radio> GetCheckedRadioAsync()
        => await list.GetFirstItemAsync(async x => await x.IsCheckedAsync().ConfigureAwait(false))
            .ConfigureAwait(false);

    public async Task<Radio> GetByValueAsync(string value)
        => await list.GetFirstItemAsync(
            async x => (await x.GetValueAsync().ConfigureAwait(false)).Equals(
                value,
                StringComparison.OrdinalIgnoreCase)
        ).ConfigureAwait(false);

    public async Task<Radio> GetByIndexAsync(int index)
        => await list.GetItemAsync(index).ConfigureAwait(false);

    public async Task<Radio> GetByTextAsync(string text)
        => await list.GetFirstItemAsync(
            async x => (await x.GetTextAsync().ConfigureAwait(false)).Equals(
                text,
                StringComparison.OrdinalIgnoreCase)
        ).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public new RadioGroupAssertionsV2 ExpectV2() => new(this);
}