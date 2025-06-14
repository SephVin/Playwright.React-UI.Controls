using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class Tab : ControlBase, IFocusable
{
    public Tab(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsDisabledAsync()
        => await HasAttributeAsync(DataVisualState.Disabled).ConfigureAwait(false);

    public async Task<bool> IsActiveAsync()
        => await HasAttributeAsync(DataVisualState.Active).ConfigureAwait(false);

    public async Task<string> GetTextAsync()
        => await RootLocator.InnerTextAsync().ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await RootLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await RootLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await RootLocator.BlurAsync().ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsyncAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new TabAssertions(RootLocator.Expect());

    public new TabAssertionsV2 ExpectV2() => new(this);
}