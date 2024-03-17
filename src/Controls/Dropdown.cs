﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Dropdown : ControlBase
{
    private readonly ILocator buttonLocator;

    public Dropdown(ILocator context)
        : base(context)
    {
        buttonLocator = context.Locator("button");
        Portal = new Portal(context.Locator("noscript"));
    }

    protected Portal Portal { get; }

    public virtual async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await buttonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsMenuOpenedAsync()
        => await Portal.IsExistsInDomAsync().ConfigureAwait(false);

    public virtual async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await buttonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public async Task SelectByTextAsync(
        string text,
        bool isMenuClosedAfterSelect = true,
        LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        var item = await items.ToAsyncEnumerable()
            .SingleAwaitAsync(async x => (await x.InnerTextAsync().ConfigureAwait(false)).Contains(text))
            .ConfigureAwait(false);
        await item.ClickAsync(options).ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            await Portal.Expect().ToHaveCountAsync(0).ConfigureAwait(false);
        }
    }

    public async Task SelectByIndexAsync(
        Index index,
        bool isMenuClosedAfterSelect = true,
        LocatorClickOptions? options = default)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        await items[index].ClickAsync(options).ConfigureAwait(false);

        if (isMenuClosedAfterSelect)
        {
            await Portal.Expect().ToHaveCountAsync(0).ConfigureAwait(false);
        }
    }

    public async Task WaitItemWithTextAsync(string text)
    {
        var items = await GetItemsAsync().ConfigureAwait(false);
        var item = await items.ToAsyncEnumerable()
            .SingleAwaitAsync(async x => (await x.InnerTextAsync().ConfigureAwait(false)).Equals(text))
            .ConfigureAwait(false);
        await item.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    public virtual async Task OpenDropdownIfNeededAsync()
    {
        if (!await IsMenuOpenedAsync().ConfigureAwait(false))
        {
            await buttonLocator.ClickAsync().ConfigureAwait(false);
        }
    }

    public override ILocatorAssertions Expect() => buttonLocator.Expect();

    protected async Task<IReadOnlyList<ILocator>> GetItemsAsync()
    {
        await OpenDropdownIfNeededAsync().ConfigureAwait(false);
        var container = await Portal.GetContainerAsync().ConfigureAwait(false);

        return await container.Locator("[data-tid='MenuItem__root']").AllAsync().ConfigureAwait(false);
    }
}