using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ButtonExtensions
{
    public static async Task WaitEnabledAsync(
        this Button button,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await button.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Button button,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await button.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitTextAsync(
        this Button button,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await button.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}