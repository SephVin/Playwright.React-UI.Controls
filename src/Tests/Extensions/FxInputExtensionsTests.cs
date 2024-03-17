using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class FxInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var visibleFxInput = new FxInput(Page.GetByTestId("FxInputId"));
        var notExistingInput = new FxInput(Page.GetByTestId("UnknownFxInputId"));
        await visibleFxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingInput.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--error")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--warning")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_FxInput_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await fxInput.AppendTextAsync("newValue").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_FxInput_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.AppendTextAsync("a").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("TODOa").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.FocusAndBlurAsync().ConfigureAwait(false);

        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitValueAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--disabled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.WaitDisabledAsync().ConfigureAwait(false);
    }
}