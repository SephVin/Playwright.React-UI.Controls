using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class SelectExtensionsTests : TestsBase
{
    private static IEnumerable<TestCaseData> SelectCases()
    {
        yield return new TestCaseData("button");
        yield return new TestCaseData("link");
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToBeVisible(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var select = await GetSelectAsync("hidden").ConfigureAwait(false);
        await select.WaitForAsync().ConfigureAwait(false);

        await select.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToBeEnabled(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToBeDisabled(string selectType)
    {
        var select = await GetSelectAsync($"disabled-{selectType}").ConfigureAwait(false);
        await select.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var select = await GetSelectAsync("error").ConfigureAwait(false);
        await select.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);
        await select.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var select = await GetSelectAsync("warning").ConfigureAwait(false);
        await select.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);
        await select.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToHaveAttribute_With_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitToHaveAttributeAsync("data-tid", "SelectId").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToHaveAttribute_Without_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToHaveValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitToHaveValueAsync("Two").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToHaveValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitToHaveValueAsync(new Regex("^Tw.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToHaveValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitNotToHaveValueAsync("Three").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToHaveValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitNotToHaveValueAsync(new Regex("^Thr.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToContainValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitToContainValueAsync("Tw").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToContainValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitToContainValueAsync(new Regex("^Tw.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToContainValue(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitNotToContainValueAsync("Twos").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitNotToContainValue_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);
        await select.WaitNotToContainValueAsync(new Regex("^Twos.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await select.ClickAsync().ConfigureAwait(false);
        await select.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Select> GetSelectAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"select--{storyName}")).ConfigureAwait(false);
        return new Select(Page.GetByTestId("SelectId"));
    }
}