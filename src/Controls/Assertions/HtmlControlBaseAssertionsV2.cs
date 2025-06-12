using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class HtmlControlBaseAssertionsV2
{
    private readonly HtmlControlBase control;

    public HtmlControlBaseAssertionsV2(HtmlControlBase control)
    {
        this.control = control;
        RootLocator = control.RootLocator;
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
                timeout: (int)(options?.Timeout ?? 15000f)
            ).ConfigureAwait(false);
        }
    }

    private async Task WaitForAttributeAsync(string name, bool expected, int timeout)
    {
        using var cts = new CancellationTokenSource(timeout);
        var token = cts.Token;

        while (true)
        {
            token.ThrowIfCancellationRequested();

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