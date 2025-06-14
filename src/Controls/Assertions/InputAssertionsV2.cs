using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class InputAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Input input;

    public InputAssertionsV2(Input input)
        : base(input)
    {
        this.input = input;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await input.InputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await input.InputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await input.InputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await input.InputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await input.InputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await input.InputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await input.InputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await input.InputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}