using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LinkExtensions
{
    public static async Task WaitTextAsync(
        this Link link,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await link.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitTextContainsAsync(
        this Link link,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await link.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitEnabledAsync(
        this Link link,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await link.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Link link,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await link.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);
}