using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class InputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Input_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await input.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Input_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var visibleInput = new Input(Page.GetByTestId("InputId"));
        var notExistingInput = new Input(Page.GetByTestId("UnknownInputId"));
        await visibleInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Input_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--disabled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Input_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Input_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--error")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Input_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Input_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--warning")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Input_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Input()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.ClickAsync().ConfigureAwait(false);

        await input.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Input_Is_Not_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Input_Is_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        var actual = await input.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await input.FillAsync("newValue").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.FillAsync("newValue").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.FillAsync(string.Empty).ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Input_With_Time_Type()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--time-type")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.FillAsync("12:34").ConfigureAwait(false);
        await input.FillAsync("13:56").ConfigureAwait(false);
        await input.FillAsync("21:05").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("21:05").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Input_With_Date_Type()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--date-type")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.FillAsync("2020-02-01").ConfigureAwait(false);
        await input.FillAsync("2021-04-03").ConfigureAwait(false);
        await input.FillAsync("2022-06-04").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("2022-06-04").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Input_With_Number_Type()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--number-type")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.FillAsync("1").ConfigureAwait(false);
        await input.FillAsync("2").ConfigureAwait(false);
        await input.FillAsync("3").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("3").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Input_With_Mask()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--time-mask")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.FillAsync("1234").ConfigureAwait(false);
        await input.FillAsync("1356").ConfigureAwait(false);
        await input.FillAsync("2105").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("21:05").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_Input_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await input.PressAsync("a").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.PressAsync("a").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("aTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await input.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("newValueTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.ClearAsync().ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.FocusAsync().ConfigureAwait(false);

        await input.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.ClickAsync().ConfigureAwait(false);
        await input.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await input.BlurAsync().ConfigureAwait(false);

        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }
}