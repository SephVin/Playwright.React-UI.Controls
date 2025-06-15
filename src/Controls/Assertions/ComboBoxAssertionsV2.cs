using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ComboBoxAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Combobox comboBox;

    public ComboBoxAssertionsV2(Combobox comboBox)
        : base(comboBox)
    {
        this.comboBox = comboBox;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await comboBox.NativeInputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await comboBox.NativeInputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        if (!await comboBox.IsDisabledAsync().ConfigureAwait(false))
        {
            await comboBox.FocusAsync().ConfigureAwait(false);
            await comboBox.NativeInputLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await comboBox.InputLikeTextLocator.Expect().ToHaveTextAsync(
                value,
                new LocatorAssertionsToHaveTextOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
    }

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
    {
        if (!await comboBox.IsDisabledAsync().ConfigureAwait(false))
        {
            await comboBox.FocusAsync().ConfigureAwait(false);
            await comboBox.NativeInputLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);
        }
        else
        {
            await comboBox.InputLikeTextLocator.Expect().Not.ToHaveTextAsync(
                value,
                new LocatorAssertionsToHaveTextOptions { Timeout = options?.Timeout }
            ).ConfigureAwait(false);
        }
    }

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
    {
        if (!await comboBox.IsDisabledAsync().ConfigureAwait(false))
        {
            await comboBox.FocusAsync().ConfigureAwait(false);
            await comboBox.NativeInputLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);
        }
        else
        {
            await comboBox.InputLikeTextLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);
        }
    }

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
    {
        if (!await comboBox.IsDisabledAsync().ConfigureAwait(false))
        {
            await comboBox.FocusAsync().ConfigureAwait(false);
            await comboBox.NativeInputLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);
        }
        else
        {
            await comboBox.InputLikeTextLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);
        }
    }

    public async Task ToContainItemsAsync(string[] expectedItemsText, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var menu = await comboBox.GetMenuItemsAsync().ConfigureAwait(false);
                var items = await menu.GetItemsAsync().ConfigureAwait(false);
                var itemsText = await items
                    .ToAsyncEnumerable()
                    .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
                    .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cts.Token)
                    .ConfigureAwait(false);

                if (expectedItemsText.All(itemsText.Contains))
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

        throw new TimeoutException(
            $"Не дождались наличия элементов [{string.Join(", ", expectedItemsText)}] в списке ComboBox за {timeoutInMilliseconds}ms.");
    }

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await comboBox.NativeInputLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await comboBox.NativeInputLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}