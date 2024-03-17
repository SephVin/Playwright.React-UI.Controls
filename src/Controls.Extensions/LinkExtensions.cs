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
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.Expect().Not.ToHaveAttributeAsync("tabindex", "-1", options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Link link,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.Expect().ToHaveAttributeAsync("tabindex", "-1", options).ConfigureAwait(false);
}