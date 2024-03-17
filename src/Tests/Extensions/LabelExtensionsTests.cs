using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class LabelExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var visibleLabel = new Label(Page.GetByTestId("LabelId"));
        var notExistingLabel = new Label(Page.GetByTestId("UnknownLabelId"));
        await visibleLabel.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLabel.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitText()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.WaitTextAsync("TO DO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitTextContains()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.WaitTextContainsAsync("DO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitTextNotContains()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.WaitTextNotContainsAsync("A").ConfigureAwait(false);
    }
}