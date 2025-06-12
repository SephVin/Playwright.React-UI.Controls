using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class TabAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Tab tab;

    public TabAssertionsV2(Tab tab)
        : base(tab.RootLocator)
    {
        this.tab = tab;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Disabled, "", options)
            .ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default) =>
        await tab.RootLocator.Expect().ToHaveAttributeAsync(DataVisualState.Disabled, "", options)
            .ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default) =>
        await tab.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default) =>
        await tab.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default) =>
        await tab.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default) =>
        await tab.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToBeActiveAsync(LocatorAssertionsToHaveAttributeOptions? options = default) =>
        await tab.RootLocator.Expect().ToHaveAttributeAsync(DataVisualState.Active, "", options).ConfigureAwait(false);

    public async Task ToBeInactiveAsync(LocatorAssertionsToHaveAttributeOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Active, "", options)
            .ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default) =>
        await tab.RootLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default) =>
        await tab.RootLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}