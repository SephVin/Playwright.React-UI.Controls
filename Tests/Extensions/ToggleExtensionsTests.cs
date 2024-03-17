using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ToggleExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var visibleCheckbox = new Toggle(Page.GetByTestId("ToggleId"));
        var notExistingCheckbox = new Toggle(Page.GetByTestId("UnknownToggleId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCheckbox.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--error")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--warning")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitUnchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--disabled")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_When_Checkbox_State_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.CheckAsync().ConfigureAwait(false);

        await toggle.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_When_Checkbox_State_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.UncheckAsync().ConfigureAwait(false);

        await toggle.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Throw_On_Check_When_Checkbox_State_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        Assert.ThrowsAsync<Exception>(() => toggle.CheckAsync());
    }

    [Test]
    public async Task Throw_On_Uncheck_When_Checkbox_State_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        Assert.ThrowsAsync<Exception>(() => toggle.UncheckAsync());
    }
}