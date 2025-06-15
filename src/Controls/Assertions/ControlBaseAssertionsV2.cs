using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ControlBaseAssertionsV2
{
    private readonly ControlBase control;

    public ControlBaseAssertionsV2(ControlBase control)
    {
        this.control = control;
        RootLocator = control.RootLocator;
    }

    protected ILocator RootLocator { get; }

    public virtual async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await RootLocator.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public virtual async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
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
            await WaitForAttributeAsync(
                name,
                expected: true,
                timeout: (int)(options?.Timeout ?? 15000f)
            ).ConfigureAwait(false);
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
            await WaitForAttributeAsync(
                name,
                expected: false,
                timeout: (int)(options?.Timeout ?? 10000f)
            ).ConfigureAwait(false);
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

    private async Task WaitForAttributeAsync(string name, bool expected, int timeout)
    {
        using var cts = new CancellationTokenSource(timeout);
        var token = cts.Token;

        while (true)
        {
            var hasAttribute = await control.HasAttributeAsync(name).ConfigureAwait(false);

            if (hasAttribute == expected)
            {
                return;
            }

            try
            {
                await Task.Delay(100, token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        var expectation = expected
            ? "наличия"
            : "отсутствия";

        throw new TimeoutException($"Не дождались {expectation} атрибута {name} за {timeout}ms.");
    }
}