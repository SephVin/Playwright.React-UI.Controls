using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TabExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var visibleTab = new Tab(Page.GetByTestId("TabId1"));
        var notExistingButton = new Tab(Page.GetByTestId("UnknownTabId"));
        await visibleTab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingButton.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--disabled")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        await tab.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--error")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        await tab.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--warning")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        await tab.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitActive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        await tab.WaitActiveAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitInactive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId2"));

        await tab.WaitInactiveAsync().ConfigureAwait(false);
    }
}