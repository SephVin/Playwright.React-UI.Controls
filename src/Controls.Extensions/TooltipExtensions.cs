using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TooltipExtensions
{
    public static async Task WaitOpenedWithTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await tooltip.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}