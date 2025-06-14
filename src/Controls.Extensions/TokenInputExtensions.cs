using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TokenInputExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await tokenInput.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await tokenInput.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeEmptyAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToHaveCountOptions? options = default
    ) => await tokenInput.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitNoToBeEmptyAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToHaveCountOptions? options = default
    ) => await tokenInput.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await tokenInput.ExpectV2().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this TokenInput tokenInput,
        LocatorAssertionsToBeFocusedOptions? options = default
    ) => await tokenInput.ExpectV2().NotToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitToContainTokensAsync(
        this TokenInput tokenInput,
        string[] tokenNames,
        int timeoutInMilliseconds = 10000
    ) => await tokenInput.ExpectV2().ToContainTokensAsync(tokenNames, timeoutInMilliseconds).ConfigureAwait(false);

    public static async Task FillAndSelectFirstAsync(this TokenInput tokenInput, string value)
    {
        await tokenInput.FillAsync(value).ConfigureAwait(false);
        await tokenInput.SelectFirstAsync(value).ConfigureAwait(false);
    }

    public static async Task FillAndSelectAsync(this TokenInput tokenInput, string value)
    {
        await tokenInput.FillAsync(value).ConfigureAwait(false);
        await tokenInput.SelectAsync(value).ConfigureAwait(false);
    }
}