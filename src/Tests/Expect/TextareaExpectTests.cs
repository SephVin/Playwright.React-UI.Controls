using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class TextareaExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var visibleTextarea = new Textarea(Page.GetByTestId("TextareaId"));
        var notExistingTextarea = new Textarea(Page.GetByTestId("UnknownTextareaId"));
        await visibleTextarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTextarea.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--disabled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--disabled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--disabled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var visibleTextarea = new Textarea(Page.GetByTestId("TextareaId"));
        var notExistingTextarea = new Textarea(Page.GetByTestId("UnknownTextareaId"));
        await visibleTextarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTextarea.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var visibleTextarea = new Textarea(Page.GetByTestId("TextareaId"));
        var notExistingTextarea = new Textarea(Page.GetByTestId("UnknownTextareaId"));
        await visibleTextarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTextarea.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToHaveAttributeAsync("data-tid", "TextareaId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToHaveAttributeAsync("data-tid", "not-text").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.Expect().Not.ToHaveValueAsync("TODO1").ConfigureAwait(false);
    }
}