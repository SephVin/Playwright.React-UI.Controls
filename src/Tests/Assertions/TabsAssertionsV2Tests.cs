using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TabsAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var tabs = await GetTabsAsync("hidden").ConfigureAwait(false);
        await tabs.WaitForAsync().ConfigureAwait(false);

        await tabs.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().ToHaveAttributeAsync("data-tid", "TabsId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveActiveTab()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().ToHaveActiveTabAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveActiveTab()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        await tabs.ExpectV2().NotToHaveActiveTabAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainTabs()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);

        await tabs.ExpectV2().ToContainTabsAsync(
            new[]
                { "First", "Second", "Third", "Fourth" }
        ).ConfigureAwait(false);
    }

    private async Task<Tabs> GetTabsAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"tabs--{storyName}")).ConfigureAwait(false);
        return new Tabs(Page.GetByTestId("TabsId"));
    }
}