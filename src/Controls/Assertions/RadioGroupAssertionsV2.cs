using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls.Assertions;

public class RadioGroupAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly RadioGroup radioGroup;

    public RadioGroupAssertionsV2(RadioGroup radioGroup)
        : base(radioGroup)
    {
        this.radioGroup = radioGroup;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await radioGroup.ExpectV2().NotToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await radioGroup.ExpectV2().ToHaveAttributeAsync(DataVisualState.Disabled, options: options)
            .ConfigureAwait(false);

    public async Task ToBeCheckedByValueAsync(string value, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByValueAsync(value).ConfigureAwait(false);
        await radio.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeCheckedByIndexAsync(int index, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByIndexAsync(index).ConfigureAwait(false);
        await radio.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeCheckedByTextAsync(string text, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByTextAsync(text).ConfigureAwait(false);
        await radio.ExpectV2().ToBeCheckedAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeUncheckedByValueAsync(string value, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByValueAsync(value).ConfigureAwait(false);
        await radio.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeUncheckedByIndexAsync(int index, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByIndexAsync(index).ConfigureAwait(false);
        await radio.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);
    }

    public async Task ToBeUncheckedByTextAsync(string text, LocatorAssertionsToBeCheckedOptions? options = default)
    {
        var radio = await radioGroup.GetByTextAsync(text).ConfigureAwait(false);
        await radio.ExpectV2().ToBeUncheckedAsync(options).ConfigureAwait(false);
    }
}