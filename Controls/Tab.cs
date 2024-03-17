using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Tab : ControlBase
{
    public Tab(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("tabindex", options).ConfigureAwait(false) is "-1";

    public async Task<bool> IsActiveAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("data-active", options).ConfigureAwait(false) == "true";
}