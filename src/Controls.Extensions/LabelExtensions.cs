using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LabelExtensions
{
    [Obsolete("Use WaitToHaveTextAsync")]
    public static async Task WaitTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await label.WaitToHaveTextAsync(text, options).ConfigureAwait(false);

    [Obsolete("Use WaitToContainTextAsync")]
    public static async Task WaitTextContainsAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.WaitToContainTextAsync(text, options).ConfigureAwait(false);

    [Obsolete("Use WaitNotToContainTextAsync")]
    public static async Task WaitTextNotContainsAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.WaitNotToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToHaveTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await label.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToHaveTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToHaveTextOptions? options = default)
        => await label.Expect().Not.ToHaveTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitToContainTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.Expect().ToContainTextAsync(text, options).ConfigureAwait(false);

    public static async Task WaitNotToContainTextAsync(
        this Label label,
        string text,
        LocatorAssertionsToContainTextOptions? options = default)
        => await label.Expect().Not.ToContainTextAsync(text, options).ConfigureAwait(false);
}