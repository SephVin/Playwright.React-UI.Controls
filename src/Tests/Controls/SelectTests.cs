using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class SelectTests : TestsBase
{
    private static IEnumerable<TestCaseData> SelectCases()
    {
        yield return new TestCaseData("button");
        yield return new TestCaseData("link");
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsVisible_Return_True_When_Select_Is_Visible(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.WaitForAsync().ConfigureAwait(false);

        var actual = await select.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsVisible_Return_False_When_Select_Is_Not_Exists(string selectType)
    {
        var visibleSelect = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        var notExistingSelect = new Select(Page.GetByTestId("HiddenSelectId"));
        await visibleSelect.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingSelect.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsDisabled_Return_True_When_Select_Is_Disabled(string selectType)
    {
        var select = await GetSelectAsync($"disabled-{selectType}").ConfigureAwait(false);

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsDisabled_Return_False_When_SelectLink_Is_Enabled(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Select_With_Error()
    {
        var select = await GetSelectAsync("error").ConfigureAwait(false);

        var actual = await select.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Select_Without_Error()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);

        var actual = await select.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Select_With_Warning()
    {
        var select = await GetSelectAsync("warning").ConfigureAwait(false);

        var actual = await select.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Select_Without_Warning()
    {
        var select = await GetSelectAsync("default").ConfigureAwait(false);

        var actual = await select.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsMenuOpened_Return_False_When_Menu_Is_Closed(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task IsMenuOpened_Return_False_When_Menu_Is_Opened(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.RootLocator.ClickAsync().ConfigureAwait(false);

        var actual = await select.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task GetSelectedValue_Return_Value_When_Select_Is_Filled(string selectType)
    {
        var select = await GetSelectAsync($"filled-{selectType}").ConfigureAwait(false);

        var actual = await select.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().Be("Two");
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task GetSelectedValue_Return_Placeholder_When_Select_Is_Empty(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().Be("Ничего не выбрано");
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task Select(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.SelectAsync("Three").ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("Three").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task Select_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.SelectAsync(new Regex("^Thre.*")).ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("Three").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task SelectFirst(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.SelectFirstAsync("o").ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("One").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task SelectFirst_With_Regex(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        await select.SelectFirstAsync(new Regex("^O.*")).ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("One").ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task Click(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ButtonOrLinkLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await select.ClickAsync().ConfigureAwait(false);
        var actual = await select.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
        await select.ButtonOrLinkLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task Focus_And_Blur(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);
        await select.ButtonOrLinkLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await select.FocusAsync().ConfigureAwait(false);
        await select.ButtonOrLinkLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await select.BlurAsync().ConfigureAwait(false);
        await select.ButtonOrLinkLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task HasAttribute_Return_True_When_Attribute_Exist(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("SelectId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_For_SelectButton_When_Attribute_Exist_Without_Value()
    {
        var select = await GetSelectAsync("default-button").ConfigureAwait(false);

        var actual = await select.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    [TestCaseSource(nameof(SelectCases))]
    public async Task GetMenuItems(string selectType)
    {
        var select = await GetSelectAsync($"default-{selectType}").ConfigureAwait(false);

        var actual = await select.GetMenuItemsAsync().ConfigureAwait(false);
        var items = await actual.GetItemsAsync().ConfigureAwait(false);

        var itemValues = await items.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        itemValues.Should().BeEquivalentTo("One", "Two", "Three", "Four");
    }

    [Test]
    public async Task FillSearch_And_Select()
    {
        var select = await GetSelectAsync("search").ConfigureAwait(false);

        await select.FillSearchAsync("Three").ConfigureAwait(false);
        await select.SelectAsync("Three").ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("Three").ConfigureAwait(false);
    }

    [Test]
    public async Task FillSearch_And_SelectFirst()
    {
        var select = await GetSelectAsync("search").ConfigureAwait(false);

        await select.FillSearchAsync("o").ConfigureAwait(false);
        await select.SelectFirstAsync("o").ConfigureAwait(false);

        await select.ButtonOrLinkLocator.Expect().ToHaveTextAsync("One").ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var select = await GetSelectAsync("with-tooltip").ConfigureAwait(false);
        await select.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await select.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var select = await GetSelectAsync("with-tooltip").ConfigureAwait(false);
        await select.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await select.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    private async Task<Select> GetSelectAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"select--{storyName}")).ConfigureAwait(false);
        return new Select(Page.GetByTestId("SelectId"));
    }
}