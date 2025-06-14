using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TabAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var tabs = await GetTabsAsync("hidden").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(1).ConfigureAwait(false);

        await tab.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(3).ConfigureAwait(false);

        await tab.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveAttributeAsync("data-tid", "Tab__root").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveTextAsync(new Regex("^TODO77.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToContainTextAsync("Fi").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToContainTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToContainTextAsync(new Regex("^TODO77.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeActive()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeActiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeInactive()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().ToBeInactiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await tab.RootLocator.FocusAsync().ConfigureAwait(false);
        await tab.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Tabs> GetTabsAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"tabs--{storyName}")).ConfigureAwait(false);
        return new Tabs(Page.GetByTestId("TabsId"));
    }
}