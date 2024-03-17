using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Input : ControlBase
{
    private readonly ILocator inputLocator;

    public Input(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("input");
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await inputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await inputLocator.InputValueAsync(options).ConfigureAwait(false);

    public virtual async Task FillAsync(string value, LocatorFillOptions? options = default)
    {
        // note: for input with mask
        await ClearAsync().ConfigureAwait(false);
        await inputLocator.FillAsync(value, options).ConfigureAwait(false);
    }

    public virtual async Task PressAsync(string value, LocatorPressOptions? options = default)
        => await inputLocator.PressAsync(value, options).ConfigureAwait(false);

    public virtual async Task PressSequentiallyAsync(string value, LocatorPressSequentiallyOptions? options = default)
        => await inputLocator.PressSequentiallyAsync(value, options).ConfigureAwait(false);

    public virtual async Task ClearAsync(LocatorClearOptions? options = default)
        => await inputLocator.ClearAsync(options).ConfigureAwait(false);

    public async Task FocusAsync(LocatorFocusOptions? options = default)
        => await inputLocator.FocusAsync(options).ConfigureAwait(false);

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await inputLocator.BlurAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await inputLocator.ClickAsync(options).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => inputLocator.Expect();
}