using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class DropdownMenuExtensions
{
    public static async Task WaitToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdownMenu.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdownMenu.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await dropdownMenu.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this DropdownMenu dropdownMenu,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await dropdownMenu.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToBeFocusedAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdownMenu.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public static async Task WaitNotToBeFocusedAsync(
        this DropdownMenu dropdownMenu,
        LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdownMenu.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}