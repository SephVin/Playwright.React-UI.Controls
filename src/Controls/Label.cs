using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Label : ControlBase
{
    public Label(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);
}