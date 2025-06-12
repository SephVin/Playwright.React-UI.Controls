using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class ControlBase
{
    protected ControlBase(ILocator rootLocator)
    {
        RootLocator = rootLocator;
        Page = rootLocator.Page;
    }

    public ILocator RootLocator { get; }
    public IPage Page { get; }

    public virtual async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await RootLocator.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task<bool> HasErrorAsync()
    {
        await WaitForAsync().ConfigureAwait(false);
        return await HasAttributeAsync(DataVisualState.Error).ConfigureAwait(false);
    }

    public async Task<bool> HasWarningAsync()
    {
        await WaitForAsync().ConfigureAwait(false);
        return await HasAttributeAsync(DataVisualState.Warning).ConfigureAwait(false);
    }

    public virtual async Task ClickAsync(LocatorClickOptions? options = default)
        => await RootLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task HoverAsync(LocatorHoverOptions? options = default)
        => await RootLocator.HoverAsync(options).ConfigureAwait(false);

    public async Task ScrollIntoViewIfNeededAsync(LocatorScrollIntoViewIfNeededOptions? options = default)
        => await RootLocator.ScrollIntoViewIfNeededAsync(options).ConfigureAwait(false);

    public async Task WaitForAsync(LocatorWaitForOptions? options = default)
        => await RootLocator.WaitForAsync(options).ConfigureAwait(false);

    public async Task<bool> HasAttributeAsync(string name)
    {
        await WaitForAsync().ConfigureAwait(false);
        return await GetAttributeValueAsync(name).ConfigureAwait(false) != null;
    }

    public async Task<string?> GetAttributeValueAsync(
        string attributeName,
        LocatorGetAttributeOptions? options = default
    ) => await RootLocator.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public virtual ILocatorAssertions Expect() => RootLocator.Expect();

    /*
     * Новая версия ассертов над контролами
     */
    public ControlBaseAssertionsV2 ExpectV2() => new(this);
}