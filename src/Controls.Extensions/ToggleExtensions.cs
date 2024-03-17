using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ToggleExtensions
{
    public static async Task WaitCheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitUncheckedAsync(
        this Toggle toggle,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await toggle.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitEnabledAsync(
        this Toggle toggle,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await toggle.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task CheckAsync(this Toggle toggle)
    {
        if (await toggle.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new Exception("Toggle already checked");
        }

        await toggle.ClickAsync().ConfigureAwait(false);
    }

    public static async Task UncheckAsync(this Toggle toggle)
    {
        if (!await toggle.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new Exception("Toggle already unchecked");
        }

        await toggle.ClickAsync().ConfigureAwait(false);
    }
}