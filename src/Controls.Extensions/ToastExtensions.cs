using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ToastExtensions
{
    public static async Task WaitToHaveTextAsync(
        this Toast toast,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toast.ExpectV2().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Toast toast,
        Regex regex,
        LocatorAssertionsToHaveTextOptions? options = default
    ) => await toast.ExpectV2().ToHaveTextAsync(regex, options).ConfigureAwait(false);
}