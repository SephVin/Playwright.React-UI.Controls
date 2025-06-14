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

    public async Task<string> GetTextAsync()
        => await RootLocator.InnerTextAsync().ConfigureAwait(false);

    public async Task WaitLoadingAsync()
        => await RootLocator.WaitForAsync().ConfigureAwait(false);

    public async Task WaitLoadedAsync()
        => await RootLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

    public new SpinnerAssertionsV2 ExpectV2() => new(this);
}