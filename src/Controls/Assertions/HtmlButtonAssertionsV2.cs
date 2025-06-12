using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class HtmlButtonAssertionsV2 : HtmlControlBaseAssertionsV2
{
    private readonly HtmlButton button;

    public HtmlButtonAssertionsV2(HtmlButton button)
        : base(button)
    {
        this.button = button;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await button.RootLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await button.RootLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await button.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await button.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await button.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await button.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await button.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await button.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await button.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await button.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.RootLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await button.RootLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}