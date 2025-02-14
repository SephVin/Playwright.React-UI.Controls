﻿using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class HtmlControlBase
{
    protected HtmlControlBase(ILocator rootLocator)
    {
        RootLocator = rootLocator;
        Page = rootLocator.Page;
    }

    public IPage Page { get; }
    public ILocator RootLocator { get; }

    public virtual async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await RootLocator.IsVisibleAsync(options).ConfigureAwait(false);

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
        LocatorGetAttributeOptions? options = default)
        => await RootLocator.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    public virtual ILocatorAssertions Expect() => RootLocator.Expect();
}