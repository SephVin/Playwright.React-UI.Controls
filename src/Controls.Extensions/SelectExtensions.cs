using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class SelectExtensions
{
    public static async Task WaitToBeEnabledAsync(this Select select)
        => await select.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(this Select select)
        => await select.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await select.ExpectV2().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await select.ExpectV2().NotToHaveValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToHaveValueAsync(
        this Select select,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await select.ExpectV2().ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveValueAsync(
        this Select select,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await select.ExpectV2().NotToHaveValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await select.ExpectV2().ToContainValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitNotToContainValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await select.ExpectV2().NotToContainValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToContainValueAsync(
        this Select select,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await select.ExpectV2().ToContainValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainValueAsync(
        this Select select,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await select.ExpectV2().NotToContainValueAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this Select select,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await select.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this Select select,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await select.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);
}