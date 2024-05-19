using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class RadioGroupExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--disabled")).ConfigureAwait(false);
        var visibleRadioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("UnknownRadioGroupId"));
        await visibleRadioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadioGroup.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError_When_All_Items_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--error")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence_When_Not_All_Items_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--error-item")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning_When_All_Items_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--warning")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence_When_Not_All_Items_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--warning-item")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitCheckedByValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--checked")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitCheckedByValueAsync("2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitCheckedByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--checked")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitCheckedByTextAsync("TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitCheckedByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--checked")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitCheckedByIndexAsync(1).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--disabled")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.WaitDisabledAsync().ConfigureAwait(false);
    }
}