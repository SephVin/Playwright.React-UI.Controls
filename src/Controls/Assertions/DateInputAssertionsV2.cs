using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class DateInputAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly DateInput dateInput;

    public DateInputAssertionsV2(DateInput dateInput)
        : base(dateInput)
    {
        this.dateInput = dateInput;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await dateInput.NativeInputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await dateInput.RootLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}