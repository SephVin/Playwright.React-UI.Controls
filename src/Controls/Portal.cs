using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

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
        var containerId = await GetAttributeValueAsync("data-render-container-id").ConfigureAwait(false);

        if (containerId == null)
        {
            throw new Exception("Can't get portal container id");
        }

        return containerId;
    }
}