using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class KebabExtensions
{
    public static async Task WaitEnabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await kebab.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Kebab kebab,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await kebab.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);
}