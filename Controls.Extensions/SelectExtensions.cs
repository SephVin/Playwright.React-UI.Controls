using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class SelectExtensions
{
    public static async Task WaitValueAsync(
        this Select select,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await select.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);
}