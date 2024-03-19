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

    public static async Task CheckAsync(
        this Checkbox checkbox,
        bool throwIfAlreadyChecked,
        LocatorCheckOptions? options = default)
    {
        if (await checkbox.IsCheckedAsync().ConfigureAwait(false) && throwIfAlreadyChecked)
        {
            throw new InvalidOperationException("Checkbox already checked");
        }

        await checkbox.CheckAsync(options).ConfigureAwait(false);
    }

    public static async Task UncheckAsync(
        this Checkbox checkbox,
        bool throwIfAlreadyUnchecked,
        LocatorUncheckOptions? options = default)
    {
        if (!await checkbox.IsCheckedAsync().ConfigureAwait(false) && throwIfAlreadyUnchecked)
        {
            throw new InvalidOperationException("Checkbox already unchecked");
        }

        await checkbox.UncheckAsync(options).ConfigureAwait(false);
    }
}