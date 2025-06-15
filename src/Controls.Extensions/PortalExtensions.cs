using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class PortalExtensions
{
    public static async Task WaitToBeVisibleAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.ExpectV2().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.ExpectV2().ToBeHiddenAsync(options).ConfigureAwait(false);
}