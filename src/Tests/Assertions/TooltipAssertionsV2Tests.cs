using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TooltipAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.CloseAsync().ConfigureAwait(false);

        await tooltip.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToHaveAttributeAsync("data-tid", "PopupContent").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToHaveTextAsync("TooltipText ссылка").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToHaveTextAsync(new Regex("^TooltipText.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToContainTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().ToContainTextAsync(new Regex("^TooltipText.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    private async Task<Tooltip> GetTooltipAsync()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--with-tooltip")).ConfigureAwait(false);
        var tooltip = new Button(Page.GetByTestId("ButtonId"));
        await tooltip.HoverAsync().ConfigureAwait(false);

        return await tooltip.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);
    }
}