using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TokenExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Token token,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await token.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Token token,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await token.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Token token,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await token.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Token token,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await token.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Token token,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await token.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Token token,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await token.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Token token,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await token.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Token token,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await token.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Token token,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await token.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Token token,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await token.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);
}