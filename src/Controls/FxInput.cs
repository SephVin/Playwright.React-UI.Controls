using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class FxInput : Input
{
    public FxInput(ILocator rootLocator)
        : base(rootLocator)
    {
        ButtonLocator = rootLocator.Locator("button");
    }

    public ILocator ButtonLocator { get; }

    public async Task<bool> IsAutoAsync(LocatorIsVisibleOptions? options = default)
        => !await ButtonLocator.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task SetAutoAsync(LocatorClickOptions? options = default)
        => await ButtonLocator.ClickAsync(options).ConfigureAwait(false);
}