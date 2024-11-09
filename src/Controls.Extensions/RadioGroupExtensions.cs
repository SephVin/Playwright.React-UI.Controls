using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioGroupExtensions
{
    [Obsolete("Use WaitToBeCheckedByValueAsync")]
    public static async Task WaitCheckedByValueAsync(this RadioGroup radioGroup, string value)
        => await radioGroup.WaitToBeCheckedByValueAsync(value).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByValueAsync(this RadioGroup radioGroup, string value)
    {
        var radio = await radioGroup.GetByValueAsync(value).ConfigureAwait(false);
        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeCheckedByTextAsync")]
    public static async Task WaitCheckedByTextAsync(this RadioGroup radioGroup, string text)
        => await radioGroup.WaitToBeCheckedByTextAsync(text).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByTextAsync(
        this RadioGroup radioGroup,
        string text,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByTextAsync(text).ConfigureAwait(false);
        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeCheckedByIndexAsync")]
    public static async Task WaitCheckedByIndexAsync(this RadioGroup radioGroup, int index)
        => await radioGroup.WaitToBeCheckedByIndexAsync(index).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByIndexAsync(
        this RadioGroup radioGroup,
        int index,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByIndexAsync(index).ConfigureAwait(false);
        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeUncheckedByValueAsync")]
    public static async Task WaitUncheckedByValueAsync(this RadioGroup radioGroup, string value)
        => await radioGroup.WaitToBeUncheckedByValueAsync(value).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByValueAsync(
        this RadioGroup radioGroup,
        string value,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByValueAsync(value).ConfigureAwait(false);
        await radio.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeUncheckedByTextAsync")]
    public static async Task WaitUncheckedByTextAsync(this RadioGroup radioGroup, string text)
        => await radioGroup.WaitToBeUncheckedByTextAsync(text).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByTextAsync(
        this RadioGroup radioGroup,
        string text,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByTextAsync(text).ConfigureAwait(false);
        await radio.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("use WaitToBeUncheckedByIndexAsync")]
    public static async Task WaitUncheckedByIndexAsync(this RadioGroup radioGroup, int index)
        => await radioGroup.WaitToBeUncheckedByIndexAsync(index).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByIndexAsync(
        this RadioGroup radioGroup,
        int index,
        LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByIndexAsync(index).ConfigureAwait(false);
        await radio.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Obsolete("Use WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(this RadioGroup radioGroup)
        => await radioGroup.WaitToBeEnabledAsync().ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this RadioGroup radioGroup,
        LocatorAssertionsToBeEnabledOptions? options = default)
    {
        var radioList = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        foreach (var radio in radioList)
        {
            await radio.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);
        }
    }

    [Obsolete("Use WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(this RadioGroup radioGroup)
        => await radioGroup.WaitToBeDisabledAsync().ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
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