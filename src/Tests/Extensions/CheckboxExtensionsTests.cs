using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class CheckboxExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var checkbox = await GetCheckboxAsync("hidden").ConfigureAwait(false);
        await checkbox.WaitForAsync().ConfigureAwait(false);

        await checkbox.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var checkbox = await GetCheckboxAsync("disabled").ConfigureAwait(false);
        await checkbox.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var checkbox = await GetCheckboxAsync("error").ConfigureAwait(false);
        await checkbox.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var checkbox = await GetCheckboxAsync("warning").ConfigureAwait(false);
        await checkbox.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeChecked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);
        await checkbox.WaitToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeUnchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToHaveAttributeAsync("data-tid", "CheckboxId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var checkbox = await GetCheckboxAsync("with-value").ConfigureAwait(false);
        await checkbox.WaitToHaveValueAsync("CheckboxValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("with-value").ConfigureAwait(false);
        await checkbox.WaitToHaveValueAsync(new Regex("^Checkbox.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveValueAsync("CheckboxValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.WaitNotToHaveValueAsync(new Regex("^Checkbox1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        await checkbox.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await checkbox.InputLocator.FocusAsync().ConfigureAwait(false);
        await checkbox.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Checkbox> GetCheckboxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"checkbox--{storyName}")).ConfigureAwait(false);
        return new Checkbox(Page.GetByTestId("CheckboxId"));
    }
}