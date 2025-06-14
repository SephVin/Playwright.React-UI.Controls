using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class RadioGroupExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this RadioGroup radioGroup,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this RadioGroup radioGroup,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByValueAsync(
        this RadioGroup radioGroup,
        string value,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeCheckedByValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByTextAsync(
        this RadioGroup radioGroup,
        string text,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeCheckedByTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeCheckedByIndexAsync(
        this RadioGroup radioGroup,
        int index,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeCheckedByIndexAsync(index, options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByValueAsync(
        this RadioGroup radioGroup,
        string value,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeUncheckedByValueAsync(value, options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByTextAsync(
        this RadioGroup radioGroup,
        string text,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeUncheckedByTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeUncheckedByIndexAsync(
        this RadioGroup radioGroup,
        int index,
        LocatorAssertionsToBeCheckedOptions? options = default
    ) => await radioGroup.ExpectV2().ToBeUncheckedByIndexAsync(index, options).ConfigureAwait(false);
}