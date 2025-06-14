using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class LinkAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Link link;

    public LinkAssertionsV2(Link link)
        : base(link)
    {
        this.link = link;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.ExpectV2().ToHaveAttributeAsync(DataVisualState.Disabled, options: options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await link.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await link.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await link.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await link.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await link.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await link.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await link.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await link.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToHaveHrefAsync(string href, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.RootLocator.Expect().ToHaveAttributeAsync("href", href, options).ConfigureAwait(false);

    public async Task NotToHaveHrefAsync(string href, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.RootLocator.Expect().Not.ToHaveAttributeAsync("href", href, options).ConfigureAwait(false);

    public async Task ToHaveHrefAsync(Regex regex, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.RootLocator.Expect().ToHaveAttributeAsync("href", regex, options).ConfigureAwait(false);

    public async Task NotToHaveHrefAsync(Regex regex, LocatorAssertionsToHaveAttributeOptions? options = default)
        => await link.RootLocator.Expect().Not.ToHaveAttributeAsync("href", regex, options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await link.RootLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await link.RootLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}