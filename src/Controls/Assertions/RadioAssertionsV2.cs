using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class RadioAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Radio radio;

    public RadioAssertionsV2(Radio radio)
        : base(radio)
    {
        this.radio = radio;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await radio.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await radio.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.InputLocator.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeUncheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await radio.InputLocator.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await radio.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await radio.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await radio.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await radio.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await radio.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex regex, LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.InputLocator.Expect().ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(Regex regex, LocatorAssertionsToHaveValueOptions? options = default)
        => await radio.InputLocator.Expect().Not.ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await radio.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await radio.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}