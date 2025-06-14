using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class Textarea : ControlBase, IFocusable
{
    public Textarea(ILocator rootLocator)
        : base(rootLocator)
    {
        TextareaLocator = rootLocator.Locator("textarea").First;
    }

    public ILocator TextareaLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await TextareaLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await TextareaLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
        => await TextareaLocator.FillAsync(value, options).ConfigureAwait(false);

    public async Task PressAsync(string value, LocatorPressOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await TextareaLocator.PressAsync(value, options).ConfigureAwait(false);
    }

    public async Task PressSequentiallyAsync(string value, LocatorPressSequentiallyOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await TextareaLocator.PressSequentiallyAsync(value, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorClearOptions? options = default)
        => await TextareaLocator.ClearAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await TextareaLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await TextareaLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await TextareaLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await TextareaLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect()
        => new TextareaAssertions(RootLocator.Expect(), TextareaLocator.Expect());

    public new TextareaAssertionsV2 ExpectV2() => new(this);
}