using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls;

public class Token : ControlBase
{
    public Token(ILocator rootLocator)
        : base(rootLocator)
    {
        RemoveIconLocator = rootLocator.Locator("[data-tid='Token__removeIcon']");
    }

    public ILocator RemoveIconLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync(DataVisualState.Disabled, options).ConfigureAwait(false) != null;

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task RemoveAsync(LocatorClickOptions? options = default)
        => await RemoveIconLocator.ClickAsync(options).ConfigureAwait(false);

    public new TokenAssertionsV2 ExpectV2() => new(this);
}