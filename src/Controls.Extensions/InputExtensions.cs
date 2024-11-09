using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class InputExtensions
{
    [Obsolete("WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this Input input,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await input.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this Input input,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await input.WaitToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEnabledAsync(
        this Input input,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await input.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Input input,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await input.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveValueAsync")]
    public static async Task WaitValueAsync(
        this Input input,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await input.WaitToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Input input,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await input.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeEmptyAsync")]
    public static async Task WaitValueAbsenceAsync(
        this Input input,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await input.WaitToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Input input,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await input.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task AppendTextAsync(
        this Input input,
        string value,
        LocatorPressSequentiallyOptions? options = default)
    {
        await input.FocusAsync().ConfigureAwait(false);
        await input.PressAsync("End").ConfigureAwait(false);
        await input.PressSequentiallyAsync(value, options).ConfigureAwait(false);
    }

    public static async Task FocusAndBlurAsync(this Input input)
    {
        await input.FocusAsync().ConfigureAwait(false);
        await input.BlurAsync().ConfigureAwait(false);
    }

    public static async Task WaitToBeFocusedAsync(
        this Input input,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await input.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Input input,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await input.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}