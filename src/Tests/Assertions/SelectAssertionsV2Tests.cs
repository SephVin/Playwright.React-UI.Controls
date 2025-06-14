using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class SelectAssertionsV2Tests : TestsBase
{
    private static IEnumerable<TestCaseData> SelectCases()
    {
        yield return new TestCaseData("button");
        yield return new TestCaseData("link");
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToBeVisible(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var select = await GetSelectAsync("hidden").ConfigureAwait(false);
        await select.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToBeEnabled(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToBeDisabled(string selectType)
    {
        var select = await GetSelectAsync($"disabled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var select = await GetSelectAsync("error").ConfigureAwait(false);
        await select.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var select = await GetSelectAsync("warning").ConfigureAwait(false);
        await select.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToHaveAttribute_With_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToHaveAttributeAsync("data-tid", "SelectId").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToHaveAttribute_Without_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToHaveAttribute_With_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToHaveAttribute_Without_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToHaveValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToHaveValueAsync("Two").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToHaveValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToHaveValueAsync(new Regex("^Tw.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToHaveValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveValueAsync("Three").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToHaveValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToHaveValueAsync(new Regex("^Thr.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToContainValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToContainValueAsync("Tw").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToContainValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().ToContainValueAsync(new Regex("^Tw.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToContainValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToContainValueAsync("Twos").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task NotToContainValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.ExpectV2().NotToContainValueAsync(new Regex("^Twos.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task ToBeFocused_And_NotToBeFocused(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await select.ClickAsync().ConfigureAwait(false);
        await select.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Select> GetSelectAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"select--{storyName}")).ConfigureAwait(false);
        return new Select(Page.GetByTestId("SelectId"));
    }
}