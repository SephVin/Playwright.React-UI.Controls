using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class DateInput : ControlBase, IFocusable
{
    public DateInput(ILocator rootLocator)
        : base(rootLocator)
    {
        NativeInputLocator = rootLocator.Locator("input");
    }

    public ILocator NativeInputLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await NativeInputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await NativeInputLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string date, LocatorPressSequentiallyOptions? options = default)
    {
        await ClearAsync(new LocatorPressOptions { Timeout = options?.Timeout }).ConfigureAwait(false);
        await NativeInputLocator.PressSequentiallyAsync(date, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorPressOptions? options = default)
    {
        await FocusAsync(new LocatorFocusOptions { Timeout = options?.Timeout }).ConfigureAwait(false);
        await RootLocator.PressAsync("Control+A", options).ConfigureAwait(false);
        await RootLocator.PressAsync("Meta+A", options).ConfigureAwait(false);
        await RootLocator.PressAsync("Backspace", options).ConfigureAwait(false);
    }

    public async Task FocusAsync(LocatorFocusOptions? options = default)
    {
        await NativeInputLocator.Expect()
            .ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        await RootLocator.FocusAsync(options).ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await RootLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        // NOTE: rootLocator всегда в состоянии enabled, даже если DateInput disabled
        await ExpectV2()
            .ToBeEnabledAsync(new LocatorAssertionsToBeEnabledOptions { Timeout = options?.Timeout })
            .ConfigureAwait(false);
        // NOTE: обычный клик по RootLocator может кликать в середину DateInput, в результате курсор оказывается во второй ячейке
        await RootLocator.Locator("span[data-fragment]")
            .First
            .ClickAsync(
                options ?? new LocatorClickOptions
                {
                    Force = true
                }
            ).ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new DateInputAssertions(
        RootLocator.Expect(),
        NativeInputLocator.Expect()
    );

    public new DateInputAssertionsV2 ExpectV2() => new(this);
}