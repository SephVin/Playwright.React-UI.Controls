using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ControlExtensions
{
    [Obsolete("Use WaitToBeVisibleAsync")]
    public static async Task WaitPresenceAsync(
        this ControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.WaitToBeVisibleAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToBeHiddenAsync")]
    public static async Task WaitAbsenceAsync(
        this ControlBase control,
        LocatorAssertionsToBeHiddenOptions? options = default)
        => await control.ExpectV2().ToBeHiddenAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeVisibleAsync(
        this ControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.ExpectV2().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this ControlBase control,
        LocatorAssertionsToBeHiddenOptions? options = default)
        => await control.ExpectV2().ToBeHiddenAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveAttributeAsync")]
    public static async Task ToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveAttributeAsync")]
    public static async Task NotToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitNotToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitToHaveAttributeAsync(
        this ControlBase control,
        string name,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().ToHaveAttributeAsync(name, options: options).ConfigureAwait(false);

    public static async Task WaitNotToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().NotToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveAttributeAsync(
        this ControlBase control,
        string name,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().NotToHaveAttributeAsync(name, options: options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveErrorAsync")]
    public static async Task WaitErrorAsync(this ControlBase control)
        => await control.WaitToHaveErrorAsync().ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveErrorAsync")]
    public static async Task WaitErrorAbsenceAsync(this ControlBase control)
        => await control.WaitNotToHaveErrorAsync().ConfigureAwait(false);

    [Obsolete("Use WaitToHaveWarningAsync")]
    public static async Task WaitWarningAsync(this ControlBase control)
        => await control.WaitToHaveWarningAsync().ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveWarningAsync")]
    public static async Task WaitWarningAbsenceAsync(
        this ControlBase control)
        => await control.WaitNotToHaveWarningAsync().ConfigureAwait(false);

    public static async Task WaitToHaveErrorAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().ToHaveErrorAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToHaveErrorAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().NotToHaveErrorAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveWarningAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().ToHaveWarningAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToHaveWarningAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.ExpectV2().NotToHaveWarningAsync(options).ConfigureAwait(false);
}