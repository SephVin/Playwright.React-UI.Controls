using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class RadioGroupAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var radioGroup = await GetRadioGroupAsync("hidden").ConfigureAwait(false);
        await radioGroup.WaitForAsync().ConfigureAwait(false);

        await radioGroup.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled_When_RadioGroup_Is_Enabled()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled_When_Not_All_Radio_Are_Enabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled-item").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var radioGroup = await GetRadioGroupAsync("error").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var radioGroup = await GetRadioGroupAsync("warning").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeCheckedByValue()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeCheckedByValueAsync("2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeCheckedByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeCheckedByIndexAsync(1).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeCheckedByText()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeCheckedByTextAsync("TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUncheckedByValue()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeUncheckedByValueAsync("1").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUncheckedByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeUncheckedByIndexAsync(0).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUncheckedByText()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToBeUncheckedByTextAsync("TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToHaveAttributeAsync("data-tid", "RadioGroupId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    private async Task<RadioGroup> GetRadioGroupAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radiogroup--{storyName}")).ConfigureAwait(false);
        return new RadioGroup(Page.GetByTestId("RadioGroupId"));
    }
}