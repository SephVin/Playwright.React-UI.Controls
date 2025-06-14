using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class RadioGroupTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_RadioGroup_Is_Visible()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        await radioGroup.WaitForAsync().ConfigureAwait(false);

        var actual = await radioGroup.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_RadioGroup_Is_Not_Exists()
    {
        var visibleRadioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("HiddenRadioGroup"));
        await visibleRadioGroup.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingRadioGroup.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_RadioGroup_Is_Disabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled").ConfigureAwait(false);

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_RadioGroup_Is_Enabled()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Not_All_Radio_Are_Disabled()
    {
        var radioGroup = await GetRadioGroupAsync("disabled-item").ConfigureAwait(false);

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_RadioGroup_With_Error()
    {
        var radioGroup = await GetRadioGroupAsync("error").ConfigureAwait(false);

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Not_All_Radio_Has_Error()
    {
        var radioGroup = await GetRadioGroupAsync("error-item").ConfigureAwait(false);

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_False_When_RadioGroup_Without_Error()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_RadioGroup_With_Warning()
    {
        var radioGroup = await GetRadioGroupAsync("warning").ConfigureAwait(false);

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Not_All_Radio_Has_Warning()
    {
        var radioGroup = await GetRadioGroupAsync("warning-item").ConfigureAwait(false);

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_False_When_RadioGroup_Without_Warning()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetItems()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        items.Should().HaveCount(2);
    }

    [Test]
    public async Task CheckByValue()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);
        await items[1].InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);

        await radioGroup.CheckByValueAsync("2").ConfigureAwait(false);

        await Page.GetByTestId("Radio__root").Nth(1).Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task CheckByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);
        await items[1].InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);

        await radioGroup.CheckByIndexAsync(1).ConfigureAwait(false);

        await Page.GetByTestId("Radio__root").Nth(1).Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task CheckByText()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);
        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);
        await items[1].InputLocator.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);

        await radioGroup.CheckByTextAsync("TODO 2").ConfigureAwait(false);

        await Page.GetByTestId("Radio__root").Nth(1).Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetCheckedRadio()
    {
        var radioGroup = await GetRadioGroupAsync("checked").ConfigureAwait(false);
        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);
        await items[1].InputLocator.Expect().ToBeCheckedAsync().ConfigureAwait(false);

        var actual = await radioGroup.GetCheckedRadioAsync().ConfigureAwait(false);

        (await actual.GetTextAsync().ConfigureAwait(false)).Should().Be("TODO 2");
    }

    [Test]
    public async Task GetByValue()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetByValueAsync("2").ConfigureAwait(false);

        (await actual.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("TODO 2");
    }

    [Test]
    public async Task GetByIndex()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetByIndexAsync(1).ConfigureAwait(false);

        (await actual.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("TODO 2");
    }

    [Test]
    public async Task GetByText()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetByTextAsync("TODO 2").ConfigureAwait(false);

        (await actual.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("TODO 2");
    }

    [Test]
    public async Task Hover()
    {
        var radioGroup = await GetRadioGroupAsync("with-tooltip").ConfigureAwait(false);
        await radioGroup.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await radioGroup.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var radioGroup = await GetRadioGroupAsync("with-tooltip").ConfigureAwait(false);
        await radioGroup.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await radioGroup.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("RadioGroupId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var radioGroup = await GetRadioGroupAsync("default").ConfigureAwait(false);

        var actual = await radioGroup.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<RadioGroup> GetRadioGroupAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"radiogroup--{storyName}")).ConfigureAwait(false);
        return new RadioGroup(Page.GetByTestId("RadioGroupId"));
    }
}