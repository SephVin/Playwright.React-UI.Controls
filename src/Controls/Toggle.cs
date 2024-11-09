using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Toggle : ControlBase, IFocusable
{
    public Toggle(ILocator rootLocator)
        : base(rootLocator)
    {
        InputLocator = rootLocator.Locator("input");
    }

    public ILocator InputLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await InputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsCheckedAsync(LocatorIsCheckedOptions? options = default)
        => await InputLocator.IsCheckedAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task CheckAsync(LocatorCheckOptions? options = default)
        => await RootLocator.CheckAsync(options).ConfigureAwait(false);

    public async Task UncheckAsync(LocatorUncheckOptions? options = default)
        => await RootLocator.UncheckAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await InputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await InputLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await InputLocator.BlurAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => new ToggleAssertions(RootLocator.Expect(), InputLocator.Expect());
}