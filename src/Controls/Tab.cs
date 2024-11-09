using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Tab : ControlBase
{
    public Tab(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) == "";

    public async Task<bool> IsActiveAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Active, options).ConfigureAwait(false) == "";

    public override ILocatorAssertions Expect() => new TabAssertions(RootLocator.Expect());
}