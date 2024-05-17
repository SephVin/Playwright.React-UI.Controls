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
        await Context.WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Visible }
        ).ConfigureAwait(false);

        return await GetAttributeValueAsync("data-visual-state-error").ConfigureAwait(false) == "true";
    }

    public async Task<bool> HasWarningAsync()
    {
        await Context.WaitForAsync(
            new LocatorWaitForOptions { State = WaitForSelectorState.Visible }
        ).ConfigureAwait(false);

        return await GetAttributeValueAsync("data-visual-state-warning").ConfigureAwait(false) == "true";
    }

    public virtual async Task ClickAsync(LocatorClickOptions? options = default)
        => await Context.ClickAsync(options).ConfigureAwait(false);

    public async Task<string?> GetAttributeValueAsync(
        string attributeName,
        LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    public async Task HoverAsync(LocatorHoverOptions? options = default)
        => await Context.HoverAsync(options).ConfigureAwait(false);

    public async Task WaitErrorAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync("data-visual-state-error", "true", options)
            .ConfigureAwait(false);

    public async Task WaitErrorAbsenceAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync("data-visual-state-error", "false", options)
            .ConfigureAwait(false);

    public async Task WaitWarningAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync("data-visual-state-warning", "true", options)
            .ConfigureAwait(false);

    public async Task WaitWarningAbsenceAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync("data-visual-state-warning", "false", options)
            .ConfigureAwait(false);

    public virtual ILocatorAssertions Expect() => Context.Expect();
}