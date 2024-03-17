using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class DateInput : ControlBase
{
    private readonly ILocator inputLocator;

    public DateInput(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("input");
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await inputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await inputLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string date, LocatorPressSequentiallyOptions? options = default)
    {
        await ClearAsync().ConfigureAwait(false);
        await inputLocator.PressSequentiallyAsync(date, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorPressOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await inputLocator.PressAsync("Control+A", options).ConfigureAwait(false);
        await inputLocator.PressAsync("Backspace", options).ConfigureAwait(false);
    }

    public async Task FocusAsync()
        => await ClickAsync().ConfigureAwait(false);

    public async Task BlurAsync(LocatorPressOptions? options = default)
        => await inputLocator.PressAsync("Tab", options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await inputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await Context.Locator("span[data-fragment]").First.ClickAsync(
            options ?? new LocatorClickOptions
            {
                Force = true
            }
        ).ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new DateInputAssertions(Context.Expect(), inputLocator.Expect());
}