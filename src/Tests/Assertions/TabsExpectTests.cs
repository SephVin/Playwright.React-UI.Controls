using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TabsExpectTests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--hidden")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        await tabs.WaitForAsync().ConfigureAwait(false);

        await tabs.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().ToHaveAttributeAsync("data-tid", "TabsId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveActiveTab()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().ToHaveActiveTabAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveActiveTab()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().NotToHaveActiveTabAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainTabs()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.ExpectV2().ToContainTabsAsync(
            new[]
                { "First", "Second", "Third", "Fourth" }
        ).ConfigureAwait(false);
    }
}