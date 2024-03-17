using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class SelectExtensions
{
    public static async Task WaitEnabledAsync(this Select select)
        => await select.Expect().ToBeEnabledAsync().ConfigureAwait(false);

    public static async Task WaitDisabledAsync(this Select select)
        => await select.Expect().ToBeDisabledAsync().ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await select.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);
}