using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class CheckboxAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var checkbox = await GetCheckboxAsync("hidden").ConfigureAwait(false);
        await checkbox.WaitForAsync().ConfigureAwait(false);

        await checkbox.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var checkbox = await GetCheckboxAsync("disabled").ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var checkbox = await GetCheckboxAsync("error").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var checkbox = await GetCheckboxAsync("warning").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        var checkbox = await GetCheckboxAsync("checked").ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeUnchecked()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeUncheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveAttributeAsync("data-tid", "CheckboxId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToContainTextAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var checkbox = await GetCheckboxAsync("with-value").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveValueAsync("CheckboxValue").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("with-value").ConfigureAwait(false);
        await checkbox.ExpectV2().ToHaveValueAsync(new Regex("^Checkbox.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveValueAsync("CheckboxValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_With_Regex()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);
        await checkbox.ExpectV2().NotToHaveValueAsync(new Regex("^Checkbox1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var checkbox = await GetCheckboxAsync("default").ConfigureAwait(false);

        await checkbox.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await checkbox.InputLocator.FocusAsync().ConfigureAwait(false);
        await checkbox.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Checkbox> GetCheckboxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"checkbox--{storyName}")).ConfigureAwait(false);
        return new Checkbox(Page.GetByTestId("CheckboxId"));
    }
}