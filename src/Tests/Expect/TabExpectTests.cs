using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class TabExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var visibleTab = new Tab(Page.GetByTestId("TabId1"));
        var notExistingTab = new Tab(Page.GetByTestId("UnknownTabId"));
        await visibleTab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTab.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--disabled")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        await tab.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--disabled")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        await tab.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var visibleTab = new Tab(Page.GetByTestId("TabId1"));
        var notExistingTab = new Tab(Page.GetByTestId("UnknownTabId"));
        await visibleTab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTab.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var visibleTab = new Tab(Page.GetByTestId("TabId1"));
        var notExistingTab = new Tab(Page.GetByTestId("UnknownTabId"));
        await visibleTab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTab.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().ToHaveAttributeAsync("data-tid", "TabId1").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().Not.ToHaveAttributeAsync("href", "https://google-2.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().ToHaveTextAsync("Fuji").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}