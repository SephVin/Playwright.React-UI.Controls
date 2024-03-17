using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class RadioGroup : ControlBase
{
    private readonly ControlList<Radio> list;

    public RadioGroup(ILocator context)
        : base(context)
    {
        list = new ControlList<Radio>(context, "[data-tid='Radio__root']", x => new Radio(x));
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
    {
        var radioList = await list.GetItemsAsync().ConfigureAwait(false);
        var isDisabled = true;

        foreach (var radio in radioList)
        {
            if (await radio.IsDisabledAsync(options).ConfigureAwait(false) == false)
            {
                isDisabled = false;
                break;
            }
        }

        return isDisabled;
    }

    public async Task<IReadOnlyList<Radio>> GetItemsAsync()
        => await list.GetItemsAsync().ConfigureAwait(false);

    public async Task CheckByValueAsync(string value, LocatorClickOptions? options = default)
    {
        var index = await GetRadioIndexByValueAsync(value).ConfigureAwait(false);
        await list.ClickItemAsync(index, options).ConfigureAwait(false);
    }

    public async Task CheckByIndexAsync(int index, LocatorClickOptions? options = default)
        => await list.ClickItemAsync(index, options).ConfigureAwait(false);

    public async Task CheckByTextAsync(string text, LocatorClickOptions? options = default)
    {
        var index = await GetRadioIndexByTextAsync(text).ConfigureAwait(false);
        await list.ClickItemAsync(index, options).ConfigureAwait(false);
    }

    public async Task<Radio> GetCheckedRadioAsync()
    {
        var radioList = await list.GetItemsAsync().ConfigureAwait(false);
        var checkedList = await radioList.ToAsyncEnumerable()
            .SelectAwait(async x => await x.IsCheckedAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);
        var index = checkedList.FindIndex(x => x);

        return radioList[index];
    }

    public async Task<int> GetRadioIndexByTextAsync(string text)
    {
        var radioList = await list.GetItemsAsync().ConfigureAwait(false);
        var radioText = await radioList.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        return radioText.FindIndex(x => x.Contains(text));
    }

    public async Task<int> GetRadioIndexByValueAsync(string value)
    {
        var values = await GetValuesAsync().ConfigureAwait(false);
        return values.FindIndex(x => x.Equals(value, StringComparison.OrdinalIgnoreCase));
    }

    private async Task<List<string>> GetValuesAsync()
    {
        var radioList = await list.GetItemsAsync().ConfigureAwait(false);
        var values = await radioList.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetValueAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        return values;
    }
}