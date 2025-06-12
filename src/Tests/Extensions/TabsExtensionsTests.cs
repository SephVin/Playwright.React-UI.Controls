using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TabsExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--hidden")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        await tabs.WaitForAsync().ConfigureAwait(false);

        await tabs.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitToHaveAttributeAsync("data-tid", "TabsId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveActiveTab()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tabs.WaitToHaveActiveTabAsync("Third").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveActiveTab()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tabs.WaitNotToHaveActiveTabAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainTabs()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));

        await tabs.WaitToContainTabsAsync(
            new[]
                { "First", "Second", "Third", "Fourth" }
        ).ConfigureAwait(false);
    }
}