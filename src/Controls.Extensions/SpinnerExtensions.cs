using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class SpinnerExtensions
{
    public static async Task WaitToHaveTextAsync(
        this Spinner spinner,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await spinner.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);
}