using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;

namespace Playwright.ReactUI.Controls;

public class MenuItem : ControlBase
{
    public MenuItem(ILocator rootLocator)
        : base(rootLocator)
    {
        ContentLocator = rootLocator.Locator("[data-tid='MenuItem__content']");
        Comment = new Label(rootLocator.Locator("[data-tid='MenuItem__comment']"));
    }

    public ILocator ContentLocator { get; }
    public Label Comment { get; }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public new MenuItemAssertionsV2 ExpectV2() => new(this);
}