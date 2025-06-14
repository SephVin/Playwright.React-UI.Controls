using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class RadioGroupExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var radioGroup = await GetRadioGroupAsync("hidden").ConfigureAwait(false);
        await radioGroup.WaitForAsync().ConfigureAwait(false);

        await radioGroup.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled_When_RadioGroup_Is_Enabled()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled_When_Not_All_Radio_Are_Enabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled-item").ConfigureAwait(false);
        await radioGroup.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled").ConfigureAwait(false);
        await radioGroup.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var radioGroup = await GetRadioGroupAsync("error").ConfigureAwait(false);
        await radioGroup.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var radioGroup = await GetRadioGroupAsync("warning").ConfigureAwait(false);
        await radioGroup.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeCheckedByValue()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.WaitToBeCheckedByValueAsync("2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeCheckedByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.WaitToBeCheckedByIndexAsync(1).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeCheckedByText()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.WaitToBeCheckedByTextAsync("TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUncheckedByValue()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToBeUncheckedByValueAsync("1").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUncheckedByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToBeUncheckedByIndexAsync(0).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUncheckedByText()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToBeUncheckedByTextAsync("TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToHaveAttributeAsync("data-tid", "RadioGroupId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    private async Task<RadioGroup> GetRadioGroupAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radiogroup--{storyName}")).ConfigureAwait(false);
        return new RadioGroup(Page.GetByTestId("RadioGroupId"));
    }
}