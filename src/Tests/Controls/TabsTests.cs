using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TabsTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Tabs_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        await tabs.WaitForAsync().ConfigureAwait(false);

        var actual = await tabs.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Tabs_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var visibleTabs = new Tabs(Page.GetByTestId("TabsId"));
        var notExistingTabs = new Tabs(Page.GetByTestId("HiddenTabs"));
        await visibleTabs.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingTabs.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetActive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        await tabs.RootLocator.GetByTestId("Tab__root").Nth(2).ClickAsync().ConfigureAwait(false);

        var actual = tabs.GetActive();

        (await actual.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("Third");
    }

    [Test]
    public async Task Select()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.SelectAsync("Third").ConfigureAwait(false);

        var tabLocator = tabs.RootLocator.GetByTestId("Tab__root").Nth(2);
        (await tabLocator.GetAttributeAsync(DataVisualState.Active).ConfigureAwait(false)).Should().Be(string.Empty);
    }

    [Test]
    public async Task GetFirst()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        (await tab.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("First");
    }

    [Test]
    public async Task GetByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        (await tab.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("Third");
    }

    [Test]
    public async Task GetByName()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var tab = await tabs.GetByNameAsync("Third").ConfigureAwait(false);

        (await tab.RootLocator.InnerTextAsync().ConfigureAwait(false)).Should().Be("Third");
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var actual = await tabs.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var actual = await tabs.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var actual = await tabs.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("TabsId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var actual = await tabs.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        var actual = await tabs.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }
}