using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class PortalExtensions
{
    [Obsolete("Use WaitToBeVisibleAsync")]
    public static async Task WaitPresenceAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.WaitToBeVisibleAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeHiddenAsync")]
    public static async Task WaitAbsenceAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.WaitToBeHiddenAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeVisibleAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.Expect().ToHaveCountAsync(1, options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this Portal portal,
        LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.Expect().ToHaveCountAsync(0, options).ConfigureAwait(false);
}