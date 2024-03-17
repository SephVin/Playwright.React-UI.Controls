using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioExtensions
{
    public static async Task WaitEnabledAsync(
        this Radio radio,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await radio.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Radio radio,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await radio.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitTextAsync(
        this Radio radio,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitCheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitUncheckedAsync(
        this Radio radio,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);
}