using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TooltipExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        await tooltip.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await tooltip.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitOpenedWithText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        await tooltip.WaitOpenedWithTextAsync("TODO").ConfigureAwait(false);
    }
}