using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class FxInput : Input
{
    private readonly ILocator buttonLocator;

    public FxInput(ILocator context)
        : base(context)
    {
        buttonLocator = context.Locator("button");
    }

    public async Task<bool> IsAutoAsync(LocatorIsVisibleOptions? options = default)
        => !await buttonLocator.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task SetAutoAsync(LocatorClickOptions? options = default)
        => await buttonLocator.ClickAsync(options).ConfigureAwait(false);
}