using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class LabelTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Label_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));
        await label.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await label.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Button_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var visibleLabel = new Label(Page.GetByTestId("LabelId"));
        var notExistingLabel = new Label(Page.GetByTestId("UnknownLabelId"));
        await visibleLabel.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingLabel.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetText_Return_Label_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        var text = await label.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TO DO");
    }
}