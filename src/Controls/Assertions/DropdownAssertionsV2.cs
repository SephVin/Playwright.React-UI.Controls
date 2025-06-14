using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class DropdownAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Dropdown dropdown;

    public DropdownAssertionsV2(Dropdown dropdown)
        : base(dropdown)
    {
        this.dropdown = dropdown;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().Not.ToHaveTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(string text, LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);

    public async Task ToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task NotToContainTextAsync(Regex regex, LocatorAssertionsToContainTextOptions? options = default)
        => await dropdown.ButtonLocator.Expect().Not.ToContainTextAsync(regex, options).ConfigureAwait(false);

    public async Task ToContainItemsAsync(string[] expectedItemsText, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var menu = await dropdown.GetMenuItemsAsync().ConfigureAwait(false);
                var items = await menu.GetItemsAsync().ConfigureAwait(false);
                var itemsText = await items
                    .ToAsyncEnumerable()
                    .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
                    .ToHashSetAsync(cts.Token)
                    .ConfigureAwait(false);

                if (expectedItemsText.All(x => itemsText.Contains(x)))
                {
                    return;
                }

                await Task.Delay(100, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        throw new TimeoutException($"Не дождались наличия элементов в списке ComboBox за {timeoutInMilliseconds}ms.");
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdown.ButtonLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await dropdown.ButtonLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}