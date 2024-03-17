using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class PortalExtensions
{
    public static async Task WaitPresenceAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.Expect().ToHaveCountAsync(1, options).ConfigureAwait(false);

    public static async Task WaitAbsenceAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.Expect().ToHaveCountAsync(0, options).ConfigureAwait(false);
}