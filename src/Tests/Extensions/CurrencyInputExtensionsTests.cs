using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class CurrencyInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var visibleCurrencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        var notExistingCurrencyInput = new CurrencyInput(Page.GetByTestId("UnknownCurrencyInputId"));
        await visibleCurrencyInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCurrencyInput.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--error")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--warning")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--filled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitValueAsync("9 999,23").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitValueAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--disabled")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));

        await currencyInput.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        await Page.GotoAsync(StorybookUrl.Get("currencyinput--default")).ConfigureAwait(false);
        var currencyInput = new CurrencyInput(Page.GetByTestId("CurrencyInputId"));
        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await currencyInput.FocusAndBlurAsync().ConfigureAwait(false);

        await currencyInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }
}