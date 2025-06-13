using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class CurrencyInputAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly CurrencyInput currencyInput;

    public CurrencyInputAssertionsV2(CurrencyInput currencyInput)
        : base(currencyInput)
    {
        this.currencyInput = currencyInput;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await currencyInput.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await currencyInput.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        await currencyInput.BlurAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);
    }

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        await currencyInput.BlurAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);
    }

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
    {
        await currencyInput.BlurAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);
    }

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
    {
        await currencyInput.BlurAsync().ConfigureAwait(false);
        await currencyInput.InputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await currencyInput.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await currencyInput.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}