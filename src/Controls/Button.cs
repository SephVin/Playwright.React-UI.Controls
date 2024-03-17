using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Button : ControlBase
{
    private readonly ILocator buttonLocator;

    public Button(ILocator context)
        : base(context)
    {
        buttonLocator = context.Locator("button");
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await buttonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await buttonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await buttonLocator.ClickAsync(options).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => buttonLocator.Expect();
}