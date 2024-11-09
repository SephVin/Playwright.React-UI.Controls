using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

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
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.Expect().Not.ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeVisibleAsync(
        this ControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this ControlBase control,
        LocatorAssertionsToBeHiddenOptions? options = default)
        => await control.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);

    public static async Task ToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.Expect().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task NotToHaveAttributeAsync(
        this ControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.Expect().Not.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveErrorAsync")]
    public static async Task WaitErrorAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitToHaveErrorAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveErrorAsync")]
    public static async Task WaitErrorAbsenceAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitNotToHaveErrorAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveWarningAsync")]
    public static async Task WaitWarningAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitToHaveWarningAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveWarningAsync")]
    public static async Task WaitWarningAbsenceAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.WaitNotToHaveWarningAsync(options).ConfigureAwait(false);

    public static async Task WaitToHaveErrorAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Microsoft.Playwright.Assertions.Expect(control.RootLocator)
            .ToHaveAttributeAsync(DataVisualState.Error, "", options)
            .ConfigureAwait(false);

    public static async Task WaitNotToHaveErrorAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Microsoft.Playwright.Assertions.Expect(control.RootLocator).Not
            .ToHaveAttributeAsync(DataVisualState.Error, "", options)
            .ConfigureAwait(false);

    public static async Task WaitToHaveWarningAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Microsoft.Playwright.Assertions.Expect(control.RootLocator)
            .ToHaveAttributeAsync(DataVisualState.Warning, "", options)
            .ConfigureAwait(false);

    public static async Task WaitNotToHaveWarningAsync(
        this ControlBase control,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Microsoft.Playwright.Assertions.Expect(control.RootLocator).Not
            .ToHaveAttributeAsync(DataVisualState.Warning, "", options)
            .ConfigureAwait(false);
}