using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Portal : ControlBase
{
    public Portal(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsExistsInDomAsync()
        => await Context.CountAsync().ConfigureAwait(false) == 1;

    public async Task<ILocator> GetContainerAsync()
    {
        await Expect().ToHaveCountAsync(1).ConfigureAwait(false);
        var containerId = await GetContainerIdAsync().ConfigureAwait(false);
        return Context.Page.Locator($"[data-rendered-container-id='{containerId}']");
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