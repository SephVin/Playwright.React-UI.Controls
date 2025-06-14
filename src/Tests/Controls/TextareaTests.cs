using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TextareaTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Textarea_Is_Visible()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitForAsync().ConfigureAwait(false);

        var actual = await textarea.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Textarea_Is_Not_Exist()
    {
        var visibleTextarea = await GetTextareaAsync("default").ConfigureAwait(false);
        var notExistingTextarea = new Textarea(Page.GetByTestId("HiddenTextarea"));
        await visibleTextarea.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingTextarea.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Textarea_Is_Disabled()
    {
        var textarea = await GetTextareaAsync("disabled").ConfigureAwait(false);

        var actual = await textarea.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Textarea_Is_Enabled()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Textarea_With_Error()
    {
        var textarea = await GetTextareaAsync("error").ConfigureAwait(false);

        var actual = await textarea.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Textarea_Without_Error()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Textarea_With_Warning()
    {
        var textarea = await GetTextareaAsync("warning").ConfigureAwait(false);

        var actual = await textarea.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Textarea_Without_Warning()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Textarea_Is_Filled()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);

        var actual = await textarea.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Textarea_Is_Not_Filled()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.FillAsync(string.Empty).ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_Input_Is_Empty()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await textarea.PressAsync("a").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.PressAsync("a").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("aTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await textarea.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToHaveValueAsync("newValueTODO").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.ClearAsync().ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await textarea.ClickAsync().ConfigureAwait(false);

        await textarea.TextareaLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await textarea.FocusAsync().ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await textarea.BlurAsync().ConfigureAwait(false);
        await textarea.TextareaLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var textarea = await GetTextareaAsync("with-tooltip").ConfigureAwait(false);
        await textarea.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await textarea.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var textarea = await GetTextareaAsync("with-tooltip").ConfigureAwait(false);
        await textarea.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await textarea.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("TextareaId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        var actual = await textarea.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Textarea> GetTextareaAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"textarea--{storyName}")).ConfigureAwait(false);
        return new Textarea(Page.GetByTestId("TextareaId"));
    }
}