using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Checkbox : ControlBase
{
    public Checkbox(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await Context.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsCheckedAsync(LocatorIsCheckedOptions? options = default)
        => await Context.IsCheckedAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task CheckAsync(LocatorCheckOptions? options = default)
        => await Context.CheckAsync(options).ConfigureAwait(false);

    public async Task UncheckAsync(LocatorUncheckOptions? options = default)
        => await Context.UncheckAsync(options).ConfigureAwait(false);
}