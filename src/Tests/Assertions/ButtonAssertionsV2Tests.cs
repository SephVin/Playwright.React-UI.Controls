using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ButtonAssertionsV2Tests : TestsBase
{
    private static IEnumerable<TestCaseData> ButtonCases()
    {
        yield return new TestCaseData("button");
        // ReSharper disable once StringLiteralTypo
        yield return new TestCaseData("htmlbutton");
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToBeVisible(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToBeHidden(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--hidden").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);

        await button.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToBeEnabled(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToBeDisabled(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--disabled").ConfigureAwait(false);
        await button.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var button = await GetButtonAsync("button--error").ConfigureAwait(false);
        await button.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var button = await GetButtonAsync("button--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var button = await GetButtonAsync("button--warning").ConfigureAwait(false);
        await button.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var button = await GetButtonAsync("button--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToHaveAttribute_With_Attribute_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveAttributeAsync("data-tid", "ButtonId").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToHaveAttribute_Without_Attribute_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToHaveAttribute_With_Attribute_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToHaveAttribute_Without_Attribute_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToHaveText(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToHaveText_With_Regex(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToHaveText(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToHaveText_With_Regex(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToContainText(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToContainText_With_Regex(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToContainText(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task NotToContainText_With_Regex(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task ToBeFocused_And_NotToBeFocused(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        await button.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await button.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await button.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Button> GetButtonAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        return new Button(Page.GetByTestId("ButtonId"));
    }
}