using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Portal : ControlBase
{
    public Portal(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task<bool> IsVisibleAsync()
        => await RootLocator.CountAsync().ConfigureAwait(false) == 1;

    public async Task<ILocator> GetContainerAsync()
    {
        var containerId = await GetContainerIdAsync().ConfigureAwait(false);
        return Page.Locator($"[data-rendered-container-id='{containerId}']");
    }

    private async Task<string> GetContainerIdAsync()
    {
        await RootLocator.Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        var containerId = await GetAttributeValueAsync("data-render-container-id").ConfigureAwait(false);

        if (containerId == null)
        {
            throw new Exception("Can't get portal container id");
        }

        return containerId;
    }

    public new PortalAssertionsV2 ExpectV2() => new(this);
}