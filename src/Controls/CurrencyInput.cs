using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class CurrencyInput : Input
{
    public CurrencyInput(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public override async Task PressAsync(string value, LocatorPressOptions? options = default)
    {
        await ClearAsync().ConfigureAwait(false);
        await base.PressAsync(value, options).ConfigureAwait(false);
    }

    public override async Task PressSequentiallyAsync(string value, LocatorPressSequentiallyOptions? options = default)
    {
        await ClearAsync().ConfigureAwait(false);
        await base.PressSequentiallyAsync(value, options).ConfigureAwait(false);
    }

    public override async Task ClearAsync(LocatorClearOptions? options = default)
    {
        // note: not working without focus
        await FocusAsync().ConfigureAwait(false);
        await base.ClearAsync(options).ConfigureAwait(false);
    }

    public override async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);
}