using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

/// <summary>
/// Button можно использовать как для @skbkontur/react-ui, так и для react
/// Но часть функциональности (проверка на Error / Warning) не будет работать с button из react
/// </summary>
public class Button : ControlBase, IFocusable
{
    public Button(ILocator rootLocator)
        : base(rootLocator)
    {
        // Or(rootLocator).Last сделан для кнопки из react (не react-ui)
        ButtonLocator = rootLocator.Locator("button").Or(rootLocator).Last;
    }

    public ILocator ButtonLocator { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await ButtonLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await ButtonLocator.InnerTextAsync(options).ConfigureAwait(false);

    public override async Task ClickAsync(LocatorClickOptions? options = default)
        => await ButtonLocator.ClickAsync(options).ConfigureAwait(false);

    public async Task FocusAsync()
    {
        await ButtonLocator.Expect().ToBeEnabledAsync().ConfigureAwait(false);
        await ButtonLocator.FocusAsync().ConfigureAwait(false);
    }

    public async Task BlurAsync(LocatorBlurOptions? options = default)
        => await ButtonLocator.BlurAsync(options).ConfigureAwait(false);

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => new ButtonAssertions(RootLocator.Expect(), ButtonLocator.Expect());

    public new ButtonAssertionsV2 ExpectV2() => new(this);
}