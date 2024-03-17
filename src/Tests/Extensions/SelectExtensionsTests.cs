using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class SelectExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence_For_SelectButton()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitPresence_For_SelectLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence_For_SelectButton()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingSelect.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence_For_SelectLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingSelect.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--error")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--warning")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue_For_SelectButton_When_Value_Is_Selected()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--filled-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitValueAsync("Two").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue_For_SelectLink_When_Value_Is_Selected()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--filled-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitValueAsync("Two").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue_For_SelectButton_When_Value_Is_Not_Selected()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        // ReSharper disable StringLiteralTypo
        await select.WaitValueAsync("Ничего не выбрано").ConfigureAwait(false);
        // ReSharper restore StringLiteralTypo
    }

    [Test]
    public async Task WaitValue_For_SelectLink_When_Value_Is_Not_Selected()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        // ReSharper disable StringLiteralTypo
        await select.WaitValueAsync("Ничего не выбрано").ConfigureAwait(false);
        // ReSharper restore StringLiteralTypo
    }

    [Test]
    public async Task WaitEnabled_For_SelectButton()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled_For_SelectLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled_For_SelectButton()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--disabled-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled_For_SelectLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--disabled-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.WaitDisabledAsync().ConfigureAwait(false);
    }
}