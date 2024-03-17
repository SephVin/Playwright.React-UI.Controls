using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class CheckboxExtensions
{
    public static async Task WaitCheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitUncheckedAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public static async Task WaitEnabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await checkbox.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Checkbox checkbox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await checkbox.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task CheckAsync(this Checkbox checkbox)
    {
        if (await checkbox.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new InvalidOperationException("Checkbox already checked");
        }

        await checkbox.ClickAsync().ConfigureAwait(false);
    }

    public static async Task UncheckAsync(this Checkbox checkbox)
    {
        if (!await checkbox.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new InvalidOperationException("Checkbox already unchecked");
        }

        await checkbox.ClickAsync().ConfigureAwait(false);
    }
}