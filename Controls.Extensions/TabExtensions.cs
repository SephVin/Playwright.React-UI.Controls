using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TabExtensions
{
    public static async Task WaitEnabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().Not.ToHaveAttributeAsync("tabindex", "-1", options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Tab tab,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().ToHaveAttributeAsync("tabindex", "-1", options).ConfigureAwait(false);

    public static async Task WaitActiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().ToHaveAttributeAsync("data-active", "true", options).ConfigureAwait(false);

    public static async Task WaitInactiveAsync(this Tab tab, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await tab.Expect().Not.ToHaveAttributeAsync("data-active", "true", options).ConfigureAwait(false);
}