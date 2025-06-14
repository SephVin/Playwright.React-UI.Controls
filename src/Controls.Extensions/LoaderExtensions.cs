using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LoaderExtensions
{
    public static async Task WaitToHaveTextAsync(
        this Loader loader,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await loader.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);
}