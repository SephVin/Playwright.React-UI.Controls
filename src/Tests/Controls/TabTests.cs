using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TabTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Tab_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.WaitForAsync().ConfigureAwait(false);

        var actual = await tab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Tab_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var visibleTab = await tabs.GetFirstAsync().ConfigureAwait(false);
        var notExistingTab = new Tab(Page.GetByTestId("HiddenTab"));
        await visibleTab.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingTab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Tab_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(1).ConfigureAwait(false);

        var actual = await tab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Tab_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Tab_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(3).ConfigureAwait(false);

        var actual = await tab.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Tab_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Tab_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        var actual = await tab.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Tab_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsActive_Return_True_When_Tab_Is_Active()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.IsActiveAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsActive_Return_False_When_Tab_Is_Inactive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        var actual = await tab.IsActiveAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("First");
    }

    [Test]
    public async Task Click()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ClickAsync().ConfigureAwait(false);

        (await tab.RootLocator.GetAttributeAsync(DataVisualState.Active).ConfigureAwait(false)).Should().BeEmpty();
    }

    [Test]
    public async Task Hover()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--with-tooltip")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await tab.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await tab.FocusAsync().ConfigureAwait(false);
        await tab.RootLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await tab.BlurAsync().ConfigureAwait(false);
        await tab.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--with-tooltip")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.HoverAsync().ConfigureAwait(false);

        var tooltip = await tab.GetTooltipAsyncAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("Tab__root");
    }

    [Test]
    public async Task HasAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--with-tooltip")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task HasAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        var actual = await tab.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }
}