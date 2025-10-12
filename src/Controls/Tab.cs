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

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await HasAttributeAsync(
            DataVisualState.Disabled,
            new LocatorGetAttributeOptions { Timeout = options?.Timeout }
        ).ConfigureAwait(false);

    public async Task<bool> IsActiveAsync(LocatorGetAttributeOptions? options = default)
        => await HasAttributeAsync(DataVisualState.Active, options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task FocusAsync(LocatorFocusOptions? options = default)
    {
        await ExpectV2()
            .ToBeEnabledAsync(new LocatorAssertionsToHaveAttributeOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await RootLocator.FocusAsync(options).ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await RootLocator.BlurAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsyncAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new TabAssertions(RootLocator.Expect());

    public new TabAssertionsV2 ExpectV2() => new(this);
}