using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TooltipTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Tooltip_Is_Opened()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);
        await tooltip.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await tooltip.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task GetTooltip()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.HoverAsync().ConfigureAwait(false);
        var tooltip = await input.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);
        await tooltip.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await tooltip.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Tooltip_Is_Not_Opened()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await tooltip.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText_Return_Tooltip_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        var text = await tooltip.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TODO");
    }

    [Test]
    public async Task Close()
    {
        await Page.GotoAsync(StorybookUrl.Get("tooltip--default")).ConfigureAwait(false);
        var tooltip = new Tooltip(Page.GetByTestId("TooltipId"));
        var input = new Input(Page.GetByTestId("InputId"));
        await input.HoverAsync().ConfigureAwait(false);

        await tooltip.CloseAsync().ConfigureAwait(false);

        await tooltip.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }
}