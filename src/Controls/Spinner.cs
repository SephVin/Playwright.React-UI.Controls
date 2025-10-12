using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;

namespace Playwright.ReactUI.Controls;

public class Spinner : ControlBase
{
    public Spinner(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task WaitLoadingAsync(LocatorWaitForOptions? options = default)
        => await RootLocator.WaitForAsync(options).ConfigureAwait(false);

    public async Task WaitLoadedAsync(LocatorWaitForOptions? options = default)
        => await RootLocator
            .WaitForAsync(
                new LocatorWaitForOptions
                {
                    State = WaitForSelectorState.Hidden,
                    Timeout = options?.Timeout
                }
            ).ConfigureAwait(false);

    public new SpinnerAssertionsV2 ExpectV2() => new(this);
}