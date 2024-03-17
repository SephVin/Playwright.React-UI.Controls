using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class ButtonExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var visibleButton = new Button(Page.GetByTestId("ButtonId"));
        var notExistingButton = new Button(Page.GetByTestId("UnknownButtonId"));
        await visibleButton.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingButton.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--disabled")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--error")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--warning")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitText()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.WaitTextAsync("TODO").ConfigureAwait(false);
    }
}