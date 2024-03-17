using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Helpers;

namespace Playwright.ReactUI.Controls;

public class ControlBase
{
    private const string errorPropAttribute = DataPropNames.Error;
    private const string warningPropAttribute = DataPropNames.Warning;

    protected ControlBase(ILocator context)
    {
        Context = context;
    }

    protected ILocator Context { get; }

    public async Task<bool> IsVisibleAsync(LocatorIsVisibleOptions? options = default)
        => await Context.IsVisibleAsync(options).ConfigureAwait(false);

    public async Task<bool> HasErrorAsync(LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeAsync(errorPropAttribute, options).ConfigureAwait(false) == "true";

    public async Task<bool> HasWarningAsync(LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeAsync(warningPropAttribute, options).ConfigureAwait(false) == "true";

    public virtual async Task ClickAsync(LocatorClickOptions? options = default)
        => await Context.ClickAsync(options).ConfigureAwait(false);

    protected async Task<string?> GetAttributeValueAsync(
        string attributeName,
        LocatorGetAttributeOptions? options = default)
        => await Context.GetAttributeValueAsync(attributeName, options).ConfigureAwait(false);

    public async Task HoverAsync(LocatorHoverOptions? options = default)
        => await Context.HoverAsync(options).ConfigureAwait(false);

    public async Task WaitErrorAsync(
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync(errorPropAttribute, "true", options).ConfigureAwait(false);

    public async Task WaitErrorAbsenceAsync(
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().Not.ToHaveAttributeAsync(errorPropAttribute, "true", options).ConfigureAwait(false);

    public async Task WaitWarningAsync(
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().ToHaveAttributeAsync(warningPropAttribute, "true", options).ConfigureAwait(false);

    public async Task WaitWarningAbsenceAsync(
        LocatorAssertionsToHaveAttributeOptions? options = default)
        => await Context.Expect().Not.ToHaveAttributeAsync(warningPropAttribute, "true", options).ConfigureAwait(false);

    public virtual ILocatorAssertions Expect() => Context.Expect();
}