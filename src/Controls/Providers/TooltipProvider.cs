using System;
using System.Threading.Tasks;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Providers;

public static class TooltipProvider
{
    public static async Task<Tooltip> GetTooltipAsync(TooltipType type, ControlBase control)
    {
        Portal portal;

        switch (type)
        {
            case TooltipType.Validation:
                await control.RootLocator.PressAsync("Tab").ConfigureAwait(false);

                if (control is IFocusable focusableControl)
                {
                    await focusableControl.FocusAsync().ConfigureAwait(false);
                }
                else
                {
                    await control.RootLocator.FocusAsync().ConfigureAwait(false);
                }

                var locator = control.RootLocator.Locator("../../noscript");

                if (await locator.CountAsync().ConfigureAwait(false) > 1)
                {
                    locator = control.RootLocator.Locator("../following-sibling::noscript[1]");
                }

                portal = new Portal(locator);
                break;

            case TooltipType.Information:
                portal = new Portal(control.RootLocator.Locator("../noscript"));
                break;

            default:
                throw new ArgumentException($"Unknown tooltip type: {type}");
        }

        var container = await portal.GetContainerAsync().ConfigureAwait(false);

        return new Tooltip(container.Locator("[data-tid='PopupContent']"));
    }

    public static async Task<Tooltip> GetTooltipAsync(TooltipType type, HtmlControlBase control)
    {
        Portal portal;

        switch (type)
        {
            case TooltipType.Validation:
                await control.RootLocator.PressAsync("Tab").ConfigureAwait(false);

                if (control is IFocusable focusableControl)
                {
                    await focusableControl.FocusAsync().ConfigureAwait(false);
                }
                else
                {
                    await control.RootLocator.FocusAsync().ConfigureAwait(false);
                }

                var locator = control.RootLocator.Locator("../../noscript");

                if (await locator.CountAsync().ConfigureAwait(false) > 1)
                {
                    locator = control.RootLocator.Locator("../following-sibling::noscript[1]");
                }

                portal = new Portal(locator);
                break;

            case TooltipType.Information:
                portal = new Portal(control.RootLocator.Locator("../noscript"));
                break;

            default:
                throw new ArgumentException($"Unknown tooltip type: {type}");
        }

        var container = await portal.GetContainerAsync().ConfigureAwait(false);
        return new Tooltip(container.Locator("[data-tid='PopupContent']"));
    }
}