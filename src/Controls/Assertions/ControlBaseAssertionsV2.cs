using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ControlBaseAssertionsV2
{
    public ControlBaseAssertionsV2(ILocator rootLocator)
    {
        RootLocator = rootLocator;
    }

    protected ILocator RootLocator { get; }

    public async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await RootLocator.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
        => await RootLocator.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToHaveAttributeAsync(
        string name,
        string? value = null,
        LocatorAssertionsToHaveAttributeOptions? options = default)
    {
        if (value != null)
        {
            await RootLocator.Expect().ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);
        }
        else
        {
            var timeout = (int)(options?.Timeout ?? 15000f);
            using var cts = new CancellationTokenSource(timeout);
            var token = cts.Token;

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var hasAttribute = await RootLocator.EvaluateAsync<bool>(
                    $"el => el.hasAttribute('{name}')").ConfigureAwait(false);

                if (hasAttribute)
                {
                    return;
                }

                try
                {
                    await Task.Delay(100, cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            throw new TimeoutException($"Не дождались наличия атрибута {name} за {timeout}ms.");
        }
    }

    public async Task NotToHaveAttributeAsync(
        string name,
        string? value = null,
        LocatorAssertionsToHaveAttributeOptions? options = default)
    {
        if (value != null)
        {
            await RootLocator.Expect().Not.ToHaveAttributeAsync(name, value, options).ConfigureAwait(false);
        }
        else
        {
            var timeout = (int)(options?.Timeout ?? 15000f);
            using var cts = new CancellationTokenSource(timeout);
            var token = cts.Token;

            while (true)
            {
                token.ThrowIfCancellationRequested();

                var hasAttribute = await RootLocator.EvaluateAsync<bool>(
                    $"el => el.hasAttribute('{name}')").ConfigureAwait(false);

                if (!hasAttribute)
                {
                    return;
                }

                try
                {
                    await Task.Delay(100, cts.Token).ConfigureAwait(false);
                }
                catch (OperationCanceledException)
                {
                    break;
                }
            }

            throw new TimeoutException($"Не дождались отсутствия атрибута {name} за {timeout}ms.");
        }
    }

    public async Task ToHaveErrorAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await ToHaveAttributeAsync(DataVisualState.Error, options: options).ConfigureAwait(false);

    public async Task NotToHaveErrorAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await NotToHaveAttributeAsync(DataVisualState.Error, options: options).ConfigureAwait(false);

    public async Task ToHaveWarningAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await ToHaveAttributeAsync(DataVisualState.Warning, options: options).ConfigureAwait(false);

    public async Task NotToHaveWarningAsync(LocatorAssertionsToHaveAttributeOptions? options = default)
        => await NotToHaveAttributeAsync(DataVisualState.Warning, options: options).ConfigureAwait(false);
}