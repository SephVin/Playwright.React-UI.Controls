﻿using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class ControlBase
{
    protected ControlBase(ILocator rootLocator)
    {
        Context = rootLocator;
        RootLocator = rootLocator;
        Page = rootLocator.Page;
    }

    [Obsolete("Use RootLocator")]
    protected ILocator Context { get; }

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
        LocatorGetAttributeOptions? options = default)
        => await RootLocator.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    public async Task WaitErrorAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await RootLocator.Expect().ToHaveAttributeAsync(DataVisualState.Error, "", options)
            .ConfigureAwait(false);

    public async Task WaitErrorAbsenceAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await RootLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Error, "", options)
            .ConfigureAwait(false);

    public async Task WaitWarningAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await RootLocator.Expect().ToHaveAttributeAsync(DataVisualState.Warning, "", options)
            .ConfigureAwait(false);

    public async Task WaitWarningAbsenceAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await RootLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Warning, "", options)
            .ConfigureAwait(false);

    public virtual ILocatorAssertions Expect() => RootLocator.Expect();
}