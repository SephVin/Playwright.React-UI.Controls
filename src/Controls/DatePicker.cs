using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class DatePicker : ControlBase, IFocusable
{
    public DatePicker(ILocator rootLocator)
        : base(rootLocator)
    {
        NativeInputLocator = rootLocator.Locator("input");
        DatePickerInputLocator = rootLocator.Locator("[data-tid='DatePicker__input']");
    }

    public ILocator NativeInputLocator { get; }
    public ILocator DatePickerInputLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await NativeInputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetValueAsync(LocatorInputValueOptions? options = default)
        => await NativeInputLocator.InputValueAsync(options).ConfigureAwait(false);

    public async Task FillAsync(string date, LocatorPressSequentiallyOptions? options = default)
    {
        await ClearAsync().ConfigureAwait(false);
        await NativeInputLocator.PressSequentiallyAsync(date, options).ConfigureAwait(false);
    }

    public async Task ClearAsync(LocatorPressOptions? options = default)
    {
        await FocusAsync().ConfigureAwait(false);
        await NativeInputLocator.PressAsync("Control+A", options).ConfigureAwait(false);
        await NativeInputLocator.PressAsync("Meta+A", options).ConfigureAwait(false);
        await NativeInputLocator.PressAsync("Backspace", options).ConfigureAwait(false);
    }

    public async Task FocusAsync()
    {
        await NativeInputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await DatePickerInputLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync()
        => await DatePickerInputLocator.BlurAsync().ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
    {
        await NativeInputLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await RootLocator.Locator("span[data-fragment]").First.ClickAsync(
            options ?? new LocatorClickOptions
            {
                Force = true
            }
        ).ConfigureAwait(false);
    }

    public override ILocatorAssertions Expect() => new DatePickerAssertions(
        RootLocator.Expect(),
        NativeInputLocator.Expect(),
        DatePickerInputLocator.Expect());
}