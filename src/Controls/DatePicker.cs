using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class DatePicker : ControlBase
{
    private readonly ILocator inputLocator;
    private readonly ILocator nativeInputLocator;

    public DatePicker(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("[data-tid='InputLikeText__input']");
        nativeInputLocator = context.Locator("[data-tid='InputLikeText__nativeInput']");
    }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await nativeInputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInnerTextOptions? options = default)
        => await Context.InnerTextAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string date, LocatorPressOptions? options = default)
    {
        await ClearAsync().ConfigureAwait(false);

        // note: PressSequentiallyAsync is not working
        foreach (var @char in date)
        {
            await inputLocator.PressAsync(@char.ToString(), options).ConfigureAwait(false);
        }
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
        await Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await inputLocator.Locator("span[data-fragment]").First
            .ClickAsync(new LocatorClickOptions { Force = true })
            .ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new DatePickerAssertions(
        Context,
        Context.Expect(),
        inputLocator.Expect(),
        nativeInputLocator.Expect());
}