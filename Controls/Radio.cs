using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Radio : ControlBase
{
    private readonly ILocator inputLocator;

    public Radio(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("input");
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await Context.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<bool> IsCheckedAsync(LocatorIsCheckedOptions? options = default)
        => await Context.IsCheckedAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task<string?> GetValueAsync(LocatorGetAttributeOptions? options = default)
        => await inputLocator.GetAttributeAsync("value", options).ConfigureAwait(false);

    public async Task CheckAsync()
        => await Context.CheckAsync().ConfigureAwait(false);
}