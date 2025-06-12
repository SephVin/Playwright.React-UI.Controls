using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class Link : ControlBase, IFocusable
{
    public Link(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) == "";

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task<string?> GetUrlAsync(LocatorGetAttributeOptions? options = default)
        => await RootLocator.GetAttributeAsync("href", options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await RootLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Disabled, "").ConfigureAwait(false);
        await RootLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await RootLocator.BlurAsync().ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => new LinkAssertions(RootLocator.Expect());
}