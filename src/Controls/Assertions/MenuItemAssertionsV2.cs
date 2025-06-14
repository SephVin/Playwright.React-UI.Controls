using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class MenuItemAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly MenuItem menuItem;

    public MenuItemAssertionsV2(MenuItem menuItem)
        : base(menuItem)
    {
        this.menuItem = menuItem;
    }

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await menuItem.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await menuItem.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await menuItem.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await menuItem.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await menuItem.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await menuItem.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await menuItem.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await menuItem.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);
}