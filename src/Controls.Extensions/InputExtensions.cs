using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class InputExtensions
{
    public static async Task WaitEnabledAsync(
        this Input input,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await input.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Input input,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await input.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this Input input,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await input.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitValueAbsenceAsync(
        this Input input,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await input.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    // note: for input with mask
    public static async Task ClearAndFillAsync(
        this Input input,
        string value,
        LocatorFillOptions? options = default)
    {
        await input.ClearAsync().ConfigureAwait(false);
        await input.FillAsync(value, options).ConfigureAwait(false);
    }

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