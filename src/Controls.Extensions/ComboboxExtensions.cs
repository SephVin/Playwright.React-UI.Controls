using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ComboboxExtensions
{
    public static async Task WaitEnabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await combobox.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this Combobox combobox,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await combobox.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitValueAsync(
        this Combobox combobox,
        string value,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await combobox.Expect().ToHaveTextAsync(value, options).ConfigureAwait(false);

    public static async Task WaitValueAbsenceAsync(
        this Combobox combobox,
        LocatorAssertionsToBeEmptyOptions? options = default)
        => await combobox.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);
}