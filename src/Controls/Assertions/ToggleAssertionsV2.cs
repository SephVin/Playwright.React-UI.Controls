using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ToggleAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Toggle toggle;

    public ToggleAssertionsV2(Toggle toggle)
        : base(toggle)
    {
        this.toggle = toggle;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await toggle.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await toggle.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.InputLocator.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeUncheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await toggle.InputLocator.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await toggle.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await toggle.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await toggle.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await toggle.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}