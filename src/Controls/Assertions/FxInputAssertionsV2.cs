using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class FxInputAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly FxInput fxInput;

    public FxInputAssertionsV2(FxInput fxInput)
        : base(fxInput)
    {
        this.fxInput = fxInput;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await fxInput.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await fxInput.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await fxInput.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await fxInput.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await fxInput.InputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await fxInput.InputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await fxInput.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task ToBeAutoAsync(LocatorAssertionsToBeHiddenOptions? options = default)
    {
        await fxInput.WaitForAsync().ConfigureAwait(false);
        await fxInput.AutoButtonLocator.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);
    }

    public async Task NotToBeAutoAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await fxInput.AutoButtonLocator.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);
}