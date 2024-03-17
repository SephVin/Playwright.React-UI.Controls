using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DropdownExtensions
{
    public static async Task WaitEnabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await dropdown.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Dropdown dropdown,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await dropdown.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitTextAsync(
        this Dropdown dropdown,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}