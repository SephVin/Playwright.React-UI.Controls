using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TooltipExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.CloseAsync().ConfigureAwait(false);

        await tooltip.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToHaveAttributeAsync("data-tid", "PopupContent").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToHaveTextAsync("TooltipText ссылка").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToHaveTextAsync(new Regex("^TooltipText.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToContainTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitToContainTextAsync(new Regex("^TooltipText.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    private async Task<Tooltip> GetTooltipAsync()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--with-tooltip")).ConfigureAwait(false);
        var tooltip = new Button(Page.GetByTestId("ButtonId"));
        await tooltip.HoverAsync().ConfigureAwait(false);

        return await tooltip.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);
    }
}