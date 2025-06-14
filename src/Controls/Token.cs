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

    public async Task<string> GetTextAsync()
        => await RootLocator.InnerTextAsync().ConfigureAwait(false);

    public async Task RemoveAsync()
        => await RemoveIconLocator.ClickAsync().ConfigureAwait(false);

    public new TokenAssertionsV2 ExpectV2() => new(this);
}