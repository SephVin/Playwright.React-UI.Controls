using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class AutocompleteAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Autocomplete autocomplete;

    public AutocompleteAssertionsV2(Autocomplete autocomplete)
        : base(autocomplete)
    {
        this.autocomplete = autocomplete;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await autocomplete.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await autocomplete.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await autocomplete.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await autocomplete.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await autocomplete.InputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await autocomplete.InputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await autocomplete.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}