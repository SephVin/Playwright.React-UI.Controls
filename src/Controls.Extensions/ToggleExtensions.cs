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

    public static async Task CheckAsync(
        this Toggle toggle,
        bool throwIfAlreadyChecked,
        LocatorCheckOptions? options = default)
    {
        if (await toggle.IsCheckedAsync().ConfigureAwait(false) && throwIfAlreadyChecked)
        {
            throw new InvalidOperationException("Toggle already checked");
        }

        await toggle.CheckAsync(options).ConfigureAwait(false);
    }

    public static async Task UncheckAsync(
        this Toggle toggle,
        bool throwIfAlreadyUnchecked,
        LocatorUncheckOptions? options = default)
    {
        if (!await toggle.IsCheckedAsync().ConfigureAwait(false) && throwIfAlreadyUnchecked)
        {
            throw new InvalidOperationException("Toggle already unchecked");
        }

        await toggle.UncheckAsync(options).ConfigureAwait(false);
    }
}