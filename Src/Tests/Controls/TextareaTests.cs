using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TextareaTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Textarea_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));
        await textarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await textarea.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Textarea_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var visibleTextarea = new Textarea(Page.GetByTestId("TextareaId"));
        var notExistingTextarea = new Textarea(Page.GetByTestId("UnknownTextareaId"));
        await visibleTextarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingTextarea.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Textarea_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--disabled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Textarea_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Textarea_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--error")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Textarea_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Textarea_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--warning")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Textarea_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Textarea_Is_Not_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Textarea_Is_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        var actual = await textarea.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));
        await textarea.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));
        await textarea.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));
        await textarea.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.FillAsync(string.Empty).ConfigureAwait(false);

        await textarea.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));
        await textarea.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await textarea.ClearAsync().ConfigureAwait(false);

        await textarea.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }
}