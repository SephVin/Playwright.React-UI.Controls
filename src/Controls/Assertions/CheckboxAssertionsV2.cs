using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class CheckboxAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Checkbox checkbox;

    public CheckboxAssertionsV2(Checkbox checkbox)
        : base(checkbox)
    {
        this.checkbox = checkbox;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await checkbox.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await checkbox.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeCheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.InputLocator.Expect().ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToBeUncheckedAsync(LocatorAssertionsToBeCheckedOptions? options = default)
        => await checkbox.InputLocator.Expect().Not.ToBeCheckedAsync(options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.RootLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await checkbox.RootLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.RootLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.RootLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.RootLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await checkbox.RootLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(Regex regex, LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.InputLocator.Expect().ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(Regex regex, LocatorAssertionsToHaveValueOptions? options = default)
        => await checkbox.InputLocator.Expect().Not.ToHaveValueAsync(regex, options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await checkbox.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await checkbox.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}