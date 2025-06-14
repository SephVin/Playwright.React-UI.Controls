using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class PortalAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Portal portal;

    public PortalAssertionsV2(Portal portal)
        : base(portal)
    {
        this.portal = portal;
    }

    public async Task ToBeVisibleAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.RootLocator.Expect().ToHaveCountAsync(1, options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await portal.RootLocator.Expect().ToHaveCountAsync(0, options).ConfigureAwait(false);
}