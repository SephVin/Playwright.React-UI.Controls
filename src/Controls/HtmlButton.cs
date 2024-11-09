using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class HtmlButton : HtmlControlBase, IFocusable
{
    public HtmlButton(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await RootLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await RootLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await RootLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await RootLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await RootLocator.BlurAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => RootLocator.Expect();
}