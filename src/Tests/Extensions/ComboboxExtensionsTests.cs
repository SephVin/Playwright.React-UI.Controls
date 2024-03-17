using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ComboboxExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var visibleCombobox = new Combobox(Page.GetByTestId("ComboboxId"));
        var notExistingCombobox = new Combobox(Page.GetByTestId("UnknownComboboxId"));
        await visibleCombobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCombobox.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--error")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--warning")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--disabled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--filled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.WaitValueAbsenceAsync().ConfigureAwait(false);
    }
}