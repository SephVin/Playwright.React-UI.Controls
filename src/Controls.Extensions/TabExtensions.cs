using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TabExtensions
{
    public static async Task WaitEnabledAsync(
        this Tab tab,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await tab.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Tab tab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await tab.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitActiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().ToHaveAttributeAsync("data-active", "true", options).ConfigureAwait(false);

    public static async Task WaitInactiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().Not.ToHaveAttributeAsync("data-active", "true", options).ConfigureAwait(false);
}