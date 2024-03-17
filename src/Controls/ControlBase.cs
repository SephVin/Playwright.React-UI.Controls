using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class ControlBase
{
    protected ControlBase(ILocator context)
    {
        Context = context;
    }

    protected ILocator Context { get; }

    public virtual async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await Context.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task<bool> HasErrorAsync()
    {
        await Context.Expect().ToBeVisibleAsync().ConfigureAwait(false);
        return await Context.Locator("_react=[error]").First.IsVisibleAsync().ConfigureAwait(false);
    }

    public async Task<bool> HasWarningAsync()
    {
        await Context.Expect().ToBeVisibleAsync().ConfigureAwait(false);
        return await Context.Locator("_react=[warning]").First.IsVisibleAsync().ConfigureAwait(false);
    }

    public virtual async Task ClickAsync(LocatorClickOptions? options = default)
        => await Context.ClickAsync(options).ConfigureAwait(false);

    public async Task<string?> GetAttributeValueAsync(
        string attributeName,
        LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    public async Task HoverAsync(LocatorHoverOptions? options = default)
        => await Context.HoverAsync(options).ConfigureAwait(false);

    public async Task WaitErrorAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await Context.Locator("_react=[error]").First.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task WaitErrorAbsenceAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await Context.Locator("_react=[error]").First.Expect().Not.ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task WaitWarningAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await Context.Locator("_react=[warning]").First.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task WaitWarningAbsenceAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await Context.Locator("_react=[warning]").First.Expect().Not.ToBeVisibleAsync(options).ConfigureAwait(false);

    public virtual ILocatorAssertions Expect() => Context.Expect();
}