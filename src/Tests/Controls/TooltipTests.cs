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
    public async Task IsVisible_Return_True_When_Tooltip_Is_Visible()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);
        await tooltip.WaitForAsync().ConfigureAwait(false);

        var actual = await tooltip.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Tooltip_Is_Not_Exist()
    {
        var visibleTooltip = await GetTooltipAsync().ConfigureAwait(false);
        await visibleTooltip.WaitForAsync().ConfigureAwait(false);
        var notExistingTooltip = new Tooltip(Page.GetByTestId("HiddenTooltip"));

        var actual = await notExistingTooltip.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var actual = await tooltip.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TooltipText ссылка");
    }

    [Test]
    public async Task GetContent_And_Close()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var content = tooltip.GetContent();
        await content.Expect().ToHaveTextAsync("TooltipText ссылка").ConfigureAwait(false);

        await tooltip.CloseAsync().ConfigureAwait(false);
        await content.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var actual = await tooltip.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var actual = await tooltip.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var actual = await tooltip.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("PopupContent");
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var tooltip = await GetTooltipAsync().ConfigureAwait(false);

        var actual = await tooltip.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Tooltip> GetTooltipAsync()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--with-tooltip")).ConfigureAwait(false);
        var tooltip = new Button(Page.GetByTestId("ButtonId"));
        await tooltip.HoverAsync().ConfigureAwait(false);

        return await tooltip.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);
    }
}