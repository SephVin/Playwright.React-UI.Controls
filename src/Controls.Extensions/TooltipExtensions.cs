using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TooltipExtensions
{
    public static async Task WaitToHaveTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tooltip.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tooltip.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Tooltip tooltip,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tooltip.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Tooltip tooltip,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await tooltip.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tooltip.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tooltip.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Tooltip tooltip,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tooltip.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Tooltip tooltip,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await tooltip.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);

    [Obsolete("Используй WaitToHaveTextAsync")]
    public static async Task WaitOpenedWithTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await tooltip.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}