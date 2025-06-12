using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class TabExpectTests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.WaitForAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--hidden")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.WaitForAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(1).ConfigureAwait(false);

        await tab.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(3).ConfigureAwait(false);

        await tab.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveAttributeAsync("data-tid", "Tab__root").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToContainTextAsync("Fi").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeActive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tab.ExpectV2().ToBeActiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeInactive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().ToBeInactiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await tab.RootLocator.FocusAsync().ConfigureAwait(false);
        await tab.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }
}