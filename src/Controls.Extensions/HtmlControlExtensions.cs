using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class HtmlControlExtensions
{
    public static async Task WaitToBeVisibleAsync(
        this HtmlControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default
    ) => await control.ExpectV2().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this HtmlControlBase control,
        LocatorAssertionsToBeHiddenOptions? options = default
    ) => await control.ExpectV2().ToBeHiddenAsync(options).ConfigureAwait(false);

    [Obsolete("Use WaitToHaveAttributeAsync")]
    public static async Task ToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.WaitToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    [Obsolete("Use WaitNotToHaveAttributeAsync")]
    public static async Task NotToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.WaitNotToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.ExpectV2().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.ExpectV2().ToHaveAttributeAsync(name, options: options).ConfigureAwait(false);

    public static async Task WaitNotToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.ExpectV2().NotToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await control.ExpectV2().NotToHaveAttributeAsync(name, options: options).ConfigureAwait(false);
}