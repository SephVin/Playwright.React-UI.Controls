using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class ButtonTests : TestsBase
{
    private static IEnumerable<TestCaseData> ButtonCases()
    {
        yield return new TestCaseData("button");
        // ReSharper disable once StringLiteralTypo
        yield return new TestCaseData("htmlbutton");
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task IsVisible_Return_True_When_Button_Is_Visible(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);

        var actual = await button.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task IsVisible_Return_False_When_Button_Is_Not_Exists(string buttonType)
    {
        var visibleButton = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        var notExistingButton = new Button(Page.GetByTestId("HiddenButton"));
        await visibleButton.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingButton.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task IsDisabled_Return_True_When_Button_Is_Disabled(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--disabled").ConfigureAwait(false);

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Button_Is_Loading()
    {
        var button = await GetButtonAsync("button--loading").ConfigureAwait(false);

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task IsDisabled_Return_False_When_Button_Is_Enabled(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Button_With_Error()
    {
        var button = await GetButtonAsync("button--error").ConfigureAwait(false);

        var actual = await button.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Button_Without_Error()
    {
        var button = await GetButtonAsync("button--default").ConfigureAwait(false);

        var actual = await button.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Button_With_Warning()
    {
        var button = await GetButtonAsync("button--warning").ConfigureAwait(false);

        var actual = await button.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Button_Without_Warning()
    {
        var button = await GetButtonAsync("button--default").ConfigureAwait(false);

        var actual = await button.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task GetText(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task Click(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await button.ClickAsync().ConfigureAwait(false);

        await toast.RootLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task Hover(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--with-tooltip").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText ссылка");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await button.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task Focus_And_Blur(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--focus-and-blur").ConfigureAwait(false);
        await button.WaitForAsync().ConfigureAwait(false);
        var labelLocator = Page.GetByTestId("LabelId");
        await labelLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await button.FocusAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await button.BlurAsync().ConfigureAwait(false);
        await labelLocator.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task GetTooltip(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--with-tooltip").ConfigureAwait(false);
        await button.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await button.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText ссылка").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task HasAttribute_Return_True_When_Attribute_Exist(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("ButtonId");
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    [TestCaseSource(nameof(ButtonCases))]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist(string buttonType)
    {
        var button = await GetButtonAsync($"{buttonType}--default").ConfigureAwait(false);

        var actual = await button.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Button> GetButtonAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        return new Button(Page.GetByTestId("ButtonId"));
    }
}