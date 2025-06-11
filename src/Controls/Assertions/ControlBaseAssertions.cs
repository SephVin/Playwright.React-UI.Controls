using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ControlBaseAssertions
{
    public ControlBaseAssertions(ILocator rootLocator)
    {
        RootLocator = rootLocator;
    }

    protected ILocator RootLocator { get; }

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await RootLocator.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
        => await RootLocator.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        string? value = null,
        LocatorAssertionsToHaveAttributeOptions? options = default)
    {
        if (value != null)
        {
            await RootLocator.Expect().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);
        }
        else
        {
            await RootLocator.Expect().ToHaveAttributeAsync(name, string.Empty, options).ConfigureAwait(false);
        }
    }

    public async Task NotToHaveAttributeAsync(
        string name,
        string? value = null,
        LocatorAssertionsToHaveAttributeOptions? options = default)
    {
        if (value != null)
        {
            await RootLocator.Expect().Not.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);
        }
        else
        {
            await RootLocator.Expect().Not.ToHaveAttributeAsync(name, string.Empty, options).ConfigureAwait(false);
        }
    }

    public async Task ToHaveErrorAsync()
        => await ToHaveAttributeAsync(DataVisualState.Error).ConfigureAwait(false);

    public async Task NotToHaveErrorAsync()
        => await NotToHaveAttributeAsync(DataVisualState.Error).ConfigureAwait(false);

    public async Task ToHaveWarningAsync()
        => await ToHaveAttributeAsync(DataVisualState.Warning).ConfigureAwait(false);

    public async Task NotToHaveWarningAsync()
        => await NotToHaveAttributeAsync(DataVisualState.Warning).ConfigureAwait(false);
}