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
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.WaitForAsync().ConfigureAwait(false);

        await tab.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--hidden")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);
        await tab.WaitForAsync().ConfigureAwait(false);

        await tab.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(1).ConfigureAwait(false);

        await tab.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(3).ConfigureAwait(false);

        await tab.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveAttributeAsync("data-tid", "Tab__root").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitToContainTextAsync("Fi").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetFirstAsync().ConfigureAwait(false);

        await tab.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeActive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);
        await tab.ClickAsync().ConfigureAwait(false);

        await tab.WaitToBeActiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeInactive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitToBeInactiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("tabs--default")).ConfigureAwait(false);
        var tabs = new Tabs(Page.GetByTestId("TabsId"));
        var tab = await tabs.GetByIndexAsync(2).ConfigureAwait(false);

        await tab.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await tab.RootLocator.FocusAsync().ConfigureAwait(false);
        await tab.WaitToBeFocusedAsync().ConfigureAwait(false);
    }
}