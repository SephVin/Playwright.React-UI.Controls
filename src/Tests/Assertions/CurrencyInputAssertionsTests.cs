using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class CurrencyInputAssertionsTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var visibleCurrencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("UnknownCurrencyInputId"));
        await visibleCurrencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCurrencyInput.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--disabled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--disabled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--disabled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.ClickAsync().ConfigureAwait(false);

        await currencyInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var visibleCurrencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("UnknownCurrencyInputId"));
        await visibleCurrencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCurrencyInput.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var visibleCurrencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("UnknownCurrencyInputId"));
        await visibleCurrencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCurrencyInput.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToHaveAttributeAsync("data-tid", "CurrencyInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToHaveAttributeAsync("data-tid", "CurrencyInputId2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().ToHaveValueAsync("9 999,23").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.Expect().Not.ToHaveValueAsync("TODO1").ConfigureAwait(false);
    }
}