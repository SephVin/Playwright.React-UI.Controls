using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LabelExtensions
{
    public static async Task WaitTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await label.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitTextContainsAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitTextNotContainsAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);
}