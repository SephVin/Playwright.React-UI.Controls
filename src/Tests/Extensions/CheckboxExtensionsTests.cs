using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class CheckboxExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var visibleCheckbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("UnknownCheckboxId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCheckbox.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--error")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--warning")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitUnchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--disabled")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_When_Checkbox_State_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.CheckAsync(throwIfAlreadyChecked: true).ConfigureAwait(false);

        await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_When_Checkbox_State_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.UncheckAsync(throwIfAlreadyUnchecked: true).ConfigureAwait(false);

        await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Throws_When_Checkbox_State_Is_Checked_And_Flag_Is_True()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        Assert.ThrowsAsync<InvalidOperationException>(() => checkbox.CheckAsync(throwIfAlreadyChecked: true));
    }

    [Test]
    public async Task Check_Not_Throws_When_Checkbox_State_Is_Checked_And_Flag_Is_False()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        Assert.DoesNotThrowAsync(() => checkbox.CheckAsync(throwIfAlreadyChecked: false));
    }

    [Test]
    public async Task Uncheck_Throws_When_Checkbox_State_Is_Unchecked_And_Flag_Is_True()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        Assert.ThrowsAsync<InvalidOperationException>(() => checkbox.UncheckAsync(throwIfAlreadyUnchecked: true));
    }

    [Test]
    public async Task Uncheck_Not_Throws_When_Checkbox_State_Is_Unchecked_And_Flag_Is_False()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        Assert.DoesNotThrowAsync(() => checkbox.UncheckAsync(throwIfAlreadyUnchecked: false));
    }
}