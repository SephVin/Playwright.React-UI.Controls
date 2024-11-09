using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class Button : ControlBase, IFocusable
{
    public Button(ILocator rootLocator)
        : base(rootLocator)
    {
        ButtonLocator = rootLocator.Locator("button");
    }

    public ILocator ButtonLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await ButtonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await ButtonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await ButtonLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await ButtonLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await ButtonLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await ButtonLocator.BlurAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => new ButtonAssertions(RootLocator.Expect(), ButtonLocator.Expect());
}