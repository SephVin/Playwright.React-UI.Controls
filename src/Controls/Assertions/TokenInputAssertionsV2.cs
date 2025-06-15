using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class TokenInputAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly TokenInput tokenInput;

    public TokenInputAssertionsV2(TokenInput tokenInput)
        : base(tokenInput)
    {
        this.tokenInput = tokenInput;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await tokenInput.TextareaLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await tokenInput.TextareaLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await tokenInput.Tokens.ExpectV2().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await tokenInput.Tokens.ExpectV2().NotToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await tokenInput.TextareaLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await tokenInput.TextareaLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task ToContainTokensAsync(string[] tokenNames, int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var items = await tokenInput.Tokens.GetItemsAsync().ConfigureAwait(false);
                var itemsText = await items
                    .ToAsyncEnumerable()
                    .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
                    .ToHashSetAsync(StringComparer.OrdinalIgnoreCase, cts.Token)
                    .ConfigureAwait(false);

                if (tokenNames.All(itemsText.Contains))
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
            $"Не дождались наличия элементов [{string.Join(", ", tokenNames)}] в списке TokenInput за {timeoutInMilliseconds}ms.");
    }
}