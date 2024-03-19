using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class ToggleTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Toggle_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));
        await toggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await toggle.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Toggle_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var visibleToggle = new Toggle(Page.GetByTestId("ToggleId"));
        var notExistingToggle = new Toggle(Page.GetByTestId("UnknownToggleId"));
        await visibleToggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingToggle.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Toggle_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--disabled")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Toggle_Is_Loading()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--loading")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Toggle_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Toggle_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Toggle_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Toggle_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--error")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Toggle_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Toggle_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--warning")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Toggle_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Set_Checked_State_When_Toggle_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.ClickAsync().ConfigureAwait(false);

        await toggle.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click_Should_Set_Unchecked_State_When_Toggle_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.ClickAsync().ConfigureAwait(false);

        await toggle.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Should_Set_Checked_State_When_Toggle_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.CheckAsync().ConfigureAwait(false);

        await toggle.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Should_Do_Nothing_When_Toggle_Is_Already_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.CheckAsync().ConfigureAwait(false);

        await toggle.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Should_Set_Unchecked_State_When_Toggle_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.UncheckAsync().ConfigureAwait(false);

        await toggle.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Should_Do_Nothing_When_Toggle_Is_Already_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.UncheckAsync().ConfigureAwait(false);

        await toggle.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetText_Returns_Toggle_Label()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        var actual = await toggle.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }
}