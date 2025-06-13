using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ComboboxExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await combobox.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await combobox.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await combobox.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default
    ) => await combobox.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await combobox.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeEmptyAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default
    ) => await combobox.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeContainItemsAsync(
        this Combobox combobox,
        string[] expectedItemsText,
        int timeoutInMilliseconds = 10000
    ) => await combobox.ExpectV2().ToContainItemsAsync(expectedItemsText, timeoutInMilliseconds).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Combobox combobox,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await combobox.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Combobox combobox,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await combobox.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task FillAndSelectAsync(this Combobox combobox, string value)
    {
        await combobox.FillAsync(value).ConfigureAwait(false);
        await combobox.SelectAsync(value).ConfigureAwait(false);
    }

    public static async Task FillAndSelectFirstAsync(this Combobox combobox, string value)
    {
        await combobox.FillAsync(value).ConfigureAwait(false);
        await combobox.SelectFirstAsync(value).ConfigureAwait(false);
    }
}