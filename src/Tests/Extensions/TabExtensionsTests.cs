using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TabExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var tabs = await GetTabsAsync("hidden").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(1).ConfigureAwait(false);

        await tab.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(3).ConfigureAwait(false);

        await tab.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveAttributeAsync("data-tid", "Tab__root").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveTextAsync(new Regex("^TODO77.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToContainTextAsync("Fi").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToContainTextAsync(new Regex("^Firs.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToContainTextAsync(new Regex("^TODO77.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeActive()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tab.WaitToBeActiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeInactive()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitToBeInactiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var tabs = await GetTabsAsync("default").ConfigureAwait(false);
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await tab.RootLocator.FocusAsync().ConfigureAwait(false);
        await tab.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Tabs> GetTabsAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"tabs--{storyName}")).ConfigureAwait(false);
        return new Tabs(Page.GetByTestId("TabsId"));
    }
}