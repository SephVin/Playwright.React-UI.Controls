using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ButtonAssertionsTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var visibleButton = new Button(Page.GetByTestId("ButtonId"));
        var notExistingButton = new Button(Page.GetByTestId("UnknownButtonId"));
        await visibleButton.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingButton.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--disabled")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--disabled")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var visibleButton = new Button(Page.GetByTestId("ButtonId"));
        var notExistingButton = new Button(Page.GetByTestId("UnknownButtonId"));
        await visibleButton.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingButton.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var visibleButton = new Button(Page.GetByTestId("ButtonId"));
        var notExistingButton = new Button(Page.GetByTestId("UnknownButtonId"));
        await visibleButton.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingButton.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToHaveAttributeAsync("data-tid", "ButtonId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().Not.ToHaveAttributeAsync("data-tid", "ButtonId2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        await button.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}