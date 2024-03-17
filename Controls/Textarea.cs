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

    public async Task<string> GetValueAsync()
        => await Context.InputValueAsync().ConfigureAwait(false);

    public async Task FillAsync(string value)
        => await Context.FillAsync(value).ConfigureAwait(false);

    public async Task ClearAsync()
        => await Context.ClearAsync().ConfigureAwait(false);

    public async Task FocusAsync()
        => await Context.FocusAsync().ConfigureAwait(false);

    public async Task BlurAsync()
        => await Context.PressAsync("Tab").ConfigureAwait(false);
}