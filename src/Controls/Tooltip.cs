using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Tooltip : ControlBase
{
    private readonly ILocator closeLocator;
    private readonly ILocator contentLocator;

    public Tooltip(ILocator rootLocator)
        : base(rootLocator)
    {
        contentLocator = rootLocator.Locator("[data-tid='Tooltip__content']");
        closeLocator = rootLocator.Locator("[data-tid='Tooltip__crossIcon']");
    }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await contentLocator.InnerTextAsync(options).ConfigureAwait(false);

    public ILocator GetContent() => contentLocator;

    public async Task CloseAsync(LocatorClickOptions? options = default)
    {
        await closeLocator.ClickAsync(options).ConfigureAwait(false);
        await WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden }).ConfigureAwait(false);
    }
}