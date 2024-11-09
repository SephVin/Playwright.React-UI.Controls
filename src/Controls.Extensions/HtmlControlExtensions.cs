using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class HtmlControlExtensions
{
    public static async Task WaitToBeVisibleAsync(
        this HtmlControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeHiddenAsync(
        this HtmlControlBase control,
        LocatorAssertionsToBeHiddenOptions? options = default)
        => await control.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);

    public static async Task ToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.Expect().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);

    public static async Task NotToHaveAttributeAsync(
        this HtmlControlBase control,
        string name,
        string value,
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await control.Expect().Not.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);
}