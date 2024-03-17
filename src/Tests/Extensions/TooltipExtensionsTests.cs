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
    public async Task WaitPresenceWithText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        await tooltip.WaitPresenceWithTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task OpenSingleLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--with-single-link")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        await tooltip.OpenSingleLinkAsync().ConfigureAwait(false);

        await Page.Expect().ToHaveURLAsync("https://kontur.ru/").ConfigureAwait(false);
    }

    [Test]
    public async Task OpenLinkByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--with-links")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        // ReSharper disable once StringLiteralTypo
        await tooltip.OpenLinkByTextAsync("ссылка 2").ConfigureAwait(false);

        await Page.Expect().ToHaveURLAsync("https://school.kontur.ru/").ConfigureAwait(false);
    }
}