using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TooltipExtensions
{
    public static async Task WaitPresenceWithTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await tooltip.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task OpenSingleLinkAsync(this Tooltip tooltip, LocatorClickOptions? options = default)
    {
        var link = tooltip.GetLinks();
        await link.WaitCountAsync(1).ConfigureAwait(false);
        await link.ClickItemAsync(0, options).ConfigureAwait(false);
    }

    public static async Task OpenLinkByTextAsync(
        this Tooltip tooltip,
        string text,
        LocatorClickOptions? options = default)
    {
        await tooltip.GetLinks().ClickItemAsync(
            async x => (await x.GetTextAsync().ConfigureAwait(false)).Equals(text),
            options
        ).ConfigureAwait(false);
    }
}