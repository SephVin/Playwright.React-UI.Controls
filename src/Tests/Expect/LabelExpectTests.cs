using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class LabelExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var visibleLabel = new Label(Page.GetByTestId("LabelId"));
        var notExistingLabel = new Label(Page.GetByTestId("UnknownLabelId"));
        await visibleLabel.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLabel.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var visibleLabel = new Label(Page.GetByTestId("LabelId"));
        var notExistingLabel = new Label(Page.GetByTestId("UnknownLabelId"));
        await visibleLabel.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLabel.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var visibleLabel = new Label(Page.GetByTestId("LabelId"));
        var notExistingLabel = new Label(Page.GetByTestId("UnknownLabelId"));
        await visibleLabel.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingLabel.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().ToHaveAttributeAsync("data-tid", "LabelId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().Not.ToHaveAttributeAsync("data-tid", "not-LabelId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().ToHaveTextAsync("TO DO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("label--default")).ConfigureAwait(false);
        var label = new Label(Page.GetByTestId("LabelId"));

        await label.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}