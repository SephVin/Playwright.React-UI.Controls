using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class FxInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_FxInput_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await fxInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_FxInput_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var visibleFxInput = new FxInput(Page.GetByTestId("FxInputId"));
        var notExistingFxInput = new FxInput(Page.GetByTestId("UnknownFxInputId"));
        await visibleFxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingFxInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_FxInput_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--disabled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_FxInput_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsAuto_Return_True_WHen_FxInput_In_AutoMode()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--auto")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await fxInput.IsAutoAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsAuto_Return_False_WHen_FxInput_In_AutoMode()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await fxInput.IsAutoAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_FxInput_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--error")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_FxInput_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_FxInput_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--warning")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_FxInput_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Input()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.ClickAsync().ConfigureAwait(false);

        await fxInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetValue_Return_Empty_When_FxInput_Is_Not_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_FxInput_Is_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        var actual = await fxInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await fxInput.FillAsync("newValue").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.FillAsync("newValue").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.FillAsync(string.Empty).ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_FxInput_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await fxInput.PressAsync("a").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.PressAsync("a").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("aTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await fxInput.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("newValueTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.ClearAsync().ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.FocusAsync().ConfigureAwait(false);

        await fxInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.ClickAsync().ConfigureAwait(false);
        await fxInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.BlurAsync().ConfigureAwait(false);

        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task SetAuto_Should_Change_Value_On_Auto()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.SetAutoAsync().ConfigureAwait(false);

        await fxInput.Expect().ToHaveValueAsync("auto").ConfigureAwait(false);
    }
}