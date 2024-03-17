using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Link : ControlBase
{
    public Link(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("tabindex", options).ConfigureAwait(false) is "-1";

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task<string?> GetUrlAsync(LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeAsync("href", options).ConfigureAwait(false);
}