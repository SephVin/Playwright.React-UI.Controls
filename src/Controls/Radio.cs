using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Radio : ControlBase, IFocusable
{
    public Radio(ILocator rootLocator)
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

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await InputLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task CheckAsync(LocatorCheckOptions? options = default)
        => await RootLocator.CheckAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await InputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await InputLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await InputLocator.BlurAsync().ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => new RadioAssertions(RootLocator.Expect(), InputLocator.Expect());
}