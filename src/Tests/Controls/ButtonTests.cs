using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class ButtonTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Button_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));
        await button.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await button.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Button_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var visibleButton = new Button(Page.GetByTestId("ButtonId"));
        var notExistingButton = new Button(Page.GetByTestId("UnknownButtonId"));
        await visibleButton.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingButton.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Button_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--disabled")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Button_Is_Loading()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--loading")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Button_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Button_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--error")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Button_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Button_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--warning")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Button_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var actual = await button.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));
        await button.WaitForAsync().ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await button.ClickAsync().ConfigureAwait(false);

        await toast.RootLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetText_Return_Button_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("button--default")).ConfigureAwait(false);
        var button = new Button(Page.GetByTestId("ButtonId"));

        var text = await button.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TODO");
    }
}