using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Tab : ControlBase
{
    public Tab(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("data-visual-state-disabled", options).ConfigureAwait(false) is "true";

    public async Task<bool> IsActiveAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("data-visual-state-active", options).ConfigureAwait(false) is "true";

    public override ILocatorAssertions Expect() => new TabAssertions(Context.Expect());
}