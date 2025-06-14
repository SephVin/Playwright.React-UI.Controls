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

public sealed class ComboBoxTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Combobox_Is_Visible()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);
        await combobox.WaitForAsync().ConfigureAwait(false);

        var actual = await combobox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Combobox_Is_Not_Exists()
    {
        var visibleCombobox = await GetComboboxAsync("default").ConfigureAwait(false);
        var notExistingCombobox = new Combobox(Page.GetByTestId("HiddenComboBox"));
        await visibleCombobox.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingCombobox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Combobox_Is_Disabled()
    {
        var combobox = await GetComboboxAsync("disabled").ConfigureAwait(false);

        var actual = await combobox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Combobox_Is_Enabled()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Combobox_With_Error()
    {
        var combobox = await GetComboboxAsync("error").ConfigureAwait(false);

        var actual = await combobox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Combobox_Without_Error()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Combobox_With_Warning()
    {
        var combobox = await GetComboboxAsync("warning").ConfigureAwait(false);

        var actual = await combobox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Combobox_Without_Warning()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetSelectedValue_Return_Empty_When_Combobox_Is_Not_Filled_And_Is_Focused()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetSelectedValue_Return_Empty_When_Combobox_Is_Not_Filled_And_Is_Not_Focused()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetSelectedValue_Return_Value_When_Combobox_Is_Filled_And_Focused()
    {
        var combobox = await GetComboboxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().Be("First");
    }

    [Test]
    public async Task GetSelectedValue_Return_Value_When_Combobox_Is_Filled_And_Not_Focused()
    {
        var combobox = await GetComboboxAsync("filled").ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().Be("First");
    }

    private static IEnumerable<TestCaseData> FillAndSelectFirstCases()
    {
        yield return new TestCaseData("default", "", "Th", "Third");
        yield return new TestCaseData("default", "sec", "Sec", "Second");
        yield return new TestCaseData("loading", "", "Th", "Third");
        yield return new TestCaseData("loading", "sec", "Sec", "Second");
    }

    [Test]
    [TestCaseSource(nameof(FillAndSelectFirstCases))]
    public async Task Fill_And_SelectFirst(
        string storyName,
        string fillValue,
        string selectValue,
        string expected)
    {
        var combobox = await GetComboboxAsync(storyName).ConfigureAwait(false);

        await combobox.FillAsync(fillValue).ConfigureAwait(false);
        await combobox.SelectFirstAsync(selectValue).ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be(expected);
    }

    [Test]
    [TestCaseSource(nameof(FillAndSelectFirstCases))]
    public async Task Fill_And_SelectFirst_With_Regex(
        string storyName,
        string fillValue,
        string selectValue,
        string expected)
    {
        var combobox = await GetComboboxAsync(storyName).ConfigureAwait(false);

        await combobox.FillAsync(fillValue).ConfigureAwait(false);
        await combobox.SelectFirstAsync(new Regex($"^{selectValue}.*")).ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be(expected);
    }

    [Test]
    public async Task Fill_And_SelectFirst_With_Multiple_Selects()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        await combobox.FillAsync("first").ConfigureAwait(false);
        await combobox.SelectFirstAsync("First").ConfigureAwait(false);
        await combobox.FillAsync("Th").ConfigureAwait(false);
        await combobox.SelectFirstAsync("Third").ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be("Third");
    }

    private static IEnumerable<TestCaseData> FillAndSelectCases()
    {
        yield return new TestCaseData("default", "Third", "Third", "Third");
        yield return new TestCaseData("loading", "Fourth", "Fourth", "Fourth");
    }

    [Test]
    [TestCaseSource(nameof(FillAndSelectCases))]
    public async Task Fill_And_Select(
        string storyName,
        string fillValue,
        string selectValue,
        string expected)
    {
        var combobox = await GetComboboxAsync(storyName).ConfigureAwait(false);

        await combobox.FillAsync(fillValue).ConfigureAwait(false);
        await combobox.SelectAsync(selectValue).ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be(expected);
    }

    [Test]
    [TestCaseSource(nameof(FillAndSelectCases))]
    public async Task Fill_And_Select_With_Regex(
        string storyName,
        string fillValue,
        string selectValue,
        string expected)
    {
        var combobox = await GetComboboxAsync(storyName).ConfigureAwait(false);

        await combobox.FillAsync(fillValue).ConfigureAwait(false);
        await combobox.SelectAsync(new Regex($"^{selectValue}.*")).ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be(expected);
    }

    [Test]
    public async Task Fill_And_Select_With_Multiple_Selects()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        await combobox.FillAsync("first").ConfigureAwait(false);
        await combobox.SelectAsync("First").ConfigureAwait(false);
        await combobox.FillAsync("Fifth").ConfigureAwait(false);
        await combobox.SelectAsync("Fifth").ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().Be("Fifth");
    }

    [Test]
    public async Task Select_Throws_When_Menu_Have_More_Than_One_Values()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        Assert.ThrowsAsync<PlaywrightException>(
            async () =>
            {
                await combobox.FillAsync("Th").ConfigureAwait(false);
                await combobox.SelectAsync("Th").ConfigureAwait(false);
            }
        );
    }

    [Test]
    public async Task Clear_Filled_Value()
    {
        var combobox = await GetComboboxAsync("filled").ConfigureAwait(false);

        await combobox.ClearAsync().ConfigureAwait(false);

        (await combobox.NativeInputLocator.InputValueAsync().ConfigureAwait(false)).Should().BeEmpty();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Combobox()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.ClickAsync().ConfigureAwait(false);

        await combobox.NativeInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var combobox = await GetComboboxAsync("with-tooltip").ConfigureAwait(false);
        await combobox.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await combobox.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.FocusAsync().ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.BlurAsync().ConfigureAwait(false);
        await combobox.NativeInputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var combobox = await GetComboboxAsync("with-tooltip").ConfigureAwait(false);
        await combobox.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await combobox.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("ComboBoxId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var combobox = await GetComboboxAsync("default").ConfigureAwait(false);

        var actual = await combobox.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    [Test]
    public async Task GetMenuItems()
    {
        var combobox = await GetComboboxAsync("loading").ConfigureAwait(false);

        var actual = await combobox.GetMenuItemsAsync().ConfigureAwait(false);
        var items = await actual.GetItemsAsync().ConfigureAwait(false);

        var itemValues = await items.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        itemValues.Should().BeEquivalentTo("First", "Second", "Third", "Fourth", "Fifth", "Sixth", "MenuItem");
    }

    private async Task<Combobox> GetComboboxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"combobox--{storyName}")).ConfigureAwait(false);
        return new Combobox(Page.GetByTestId("ComboBoxId"));
    }
}