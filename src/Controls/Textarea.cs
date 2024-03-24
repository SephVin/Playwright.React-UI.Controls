using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Textarea : ControlBase
{
    public Textarea(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await Context.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await Context.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string value, LocatorFillOptions? options = default)
        => await Context.FillAsync(value, options).ConfigureAwait(false);

    public async Task ClearAsync(LocatorClearOptions? options = default)
        => await Context.ClearAsync(options).ConfigureAwait(false);

    public async Task FocusAsync(LocatorFocusOptions? options = default)
        => await Context.FocusAsync(options).ConfigureAwait(false);

    public async Task BlurAsync(LocatorPressOptions? options = default)
        => await Context.PressAsync("Tab", options).ConfigureAwait(false);
}