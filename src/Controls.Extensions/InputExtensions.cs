using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class InputExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Input input,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await input.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Input input,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await input.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Input input,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await input.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNoToHaveValueAsync(
        this Input input,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await input.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Input input,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await input.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNoToBeEmptyAsync(
        this Input input,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await input.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Input input,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await input.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Input input,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await input.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

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
}