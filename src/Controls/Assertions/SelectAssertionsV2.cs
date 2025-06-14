using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class SelectAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Select select;

    public SelectAssertionsV2(Select select)
        : base(select)
    {
        this.select = select;
    }

    public async Task ToBeEnabledAsync()
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().Not.ToHaveAttributeAsync(DataVisualState.Disabled, "")
                .ConfigureAwait(false);
        }
        else
        {
            await select.ButtonOrLinkLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        }
    }

    public async Task ToBeDisabledAsync()
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().ToHaveAttributeAsync(DataVisualState.Disabled, "")
                .ConfigureAwait(false);
        }
        else
        {
            await select.ButtonOrLinkLocator.Expect().ToBeDisabledAsync().ConfigureAwait(false);
        }
    }

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);
        }
    }

    public async Task ToHaveValueAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);
        }
    }

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().Not.ToHaveTextAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().Not.ToHaveTextAsync(value, options).ConfigureAwait(false);
        }
    }

    public async Task NotToHaveValueAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);
        }
    }

    public async Task ToContainValueAsync(string value, LocatorAssertionsToContainTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().ToContainTextAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().ToContainTextAsync(value, options).ConfigureAwait(false);
        }
    }

    public async Task ToContainValueAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);
        }
    }

    public async Task NotToContainValueAsync(string value, LocatorAssertionsToContainTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().Not.ToContainTextAsync(value).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().Not.ToContainTextAsync(value).ConfigureAwait(false);
        }
    }

    public async Task NotToContainValueAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
    {
        if (await select.IsLinkSelectAsync().ConfigureAwait(false))
        {
            await select.ButtonOrLinkLocator.Expect().Not.ToContainTextAsync(regex).ConfigureAwait(false);
        }
        else
        {
            await select.SelectLabelLocator.Expect().Not.ToContainTextAsync(regex).ConfigureAwait(false);
        }
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await select.ButtonOrLinkLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await select.ButtonOrLinkLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}