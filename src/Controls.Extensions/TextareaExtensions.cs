using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TextareaExtensions
{
    public static async Task WaitEnabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await textarea.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Textarea textarea,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await textarea.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this Textarea textarea,
        string value,
        LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);
}