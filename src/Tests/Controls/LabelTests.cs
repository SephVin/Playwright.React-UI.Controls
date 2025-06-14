using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class LabelTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Label_Is_Visible()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitForAsync().ConfigureAwait(false);

        var actual = await label.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Button_Is_Not_Exists()
    {
        var visibleLabel = await GetLabelAsync("default").ConfigureAwait(false);
        var notExistingLabel = new Label(Page.GetByTestId("HiddenLabel"));
        await visibleLabel.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingLabel.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var text = await label.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TODO");
    }

    [Test]
    public async Task Hover()
    {
        var label = await GetLabelAsync("with-tooltip").ConfigureAwait(false);
        await label.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await label.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var label = await GetLabelAsync("with-tooltip").ConfigureAwait(false);
        await label.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await label.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var actual = await label.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var actual = await label.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var actual = await label.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("LabelId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var actual = await label.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);

        var actual = await label.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Label> GetLabelAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"label--{storyName}")).ConfigureAwait(false);
        return new Label(Page.GetByTestId("LabelId"));
    }
}