using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioGroupExtensions
{
    public static async Task WaitCheckedByValueAsync(
        this RadioGroup radioGroup,
        string value,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var index = await radioGroup.GetRadioIndexByValueAsync(value).ConfigureAwait(false);
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        await radioList[index].WaitCheckedAsync(options).ConfigureAwait(false);
    }

    public static async Task WaitCheckedByTextAsync(
        this RadioGroup radioGroup,
        string text,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var index = await radioGroup.GetRadioIndexByTextAsync(text).ConfigureAwait(false);
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        await radioList[index].WaitCheckedAsync(options).ConfigureAwait(false);
    }

    public static async Task WaitCheckedByIndexAsync(
        this RadioGroup radioGroup,
        int index,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);
        await radioList[index].WaitCheckedAsync(options).ConfigureAwait(false);
    }

    public static async Task WaitEnabledAsync(
        this RadioGroup radioGroup,
        LocatorAssertionsToBeEnabledOptions? options = default)
    {
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        foreach (var radio in radioList)
        {
            await radio.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);
        }
    }

    public static async Task WaitDisabledAsync(
        this RadioGroup radioGroup,
        LocatorAssertionsToBeDisabledOptions? options = default)
    {
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        foreach (var radio in radioList)
        {
            await radio.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);
        }
    }
}