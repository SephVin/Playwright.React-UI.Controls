using System.Threading.Tasks;

namespace Playwright.ReactUI.Controls.Extensions;

public static class TabsExtensions
{
    public static async Task WaitToHaveActiveTabAsync(this Tabs tabs, string tabName)
        => await tabs.ExpectV2().ToHaveActiveTabAsync(tabName).ConfigureAwait(false);

    public static async Task WaitNotToHaveActiveTabAsync(this Tabs tabs, string tabName)
        => await tabs.ExpectV2().NotToHaveActiveTabAsync(tabName).ConfigureAwait(false);

    public static async Task WaitToContainTabsAsync(
        this Tabs tabs,
        string[] tabNames,
        int timeoutInMilliseconds = 15000)
        => await tabs.ExpectV2().ToContainTabsAsync(tabNames, timeoutInMilliseconds).ConfigureAwait(false);
}