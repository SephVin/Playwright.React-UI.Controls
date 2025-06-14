using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LabelExtensions
{
    public static async Task WaitToHaveTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await label.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await label.ExpectV2().NotToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Label label,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await label.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Label label,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await label.ExpectV2().NotToHaveTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await label.ExpectV2().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await label.ExpectV2().NotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Label label,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await label.ExpectV2().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Label label,
        Regex regex,
        LocatorAssertionsToContainTextOptions? options = default
    ) => await label.ExpectV2().NotToContainTextAsync(regex, options).ConfigureAwait(false);
}