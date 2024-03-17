using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class RadioExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var visibleRadio = new Radio(Page.GetByTestId("RadioId"));
        var notExistingRadio = new Radio(Page.GetByTestId("UnknownRadioId"));
        await visibleRadio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadio.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--error")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--warning")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--disabled")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--checked")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitUnchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.WaitValueAsync("1").ConfigureAwait(false);
    }
}