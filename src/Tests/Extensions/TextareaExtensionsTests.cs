using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TextareaExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var textarea = await GetTextareaAsync("hidden").ConfigureAwait(false);
        await textarea.WaitForAsync().ConfigureAwait(false);

        await textarea.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var textarea = await GetTextareaAsync("disabled").ConfigureAwait(false);
        await textarea.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var textarea = await GetTextareaAsync("error").ConfigureAwait(false);
        await textarea.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var textarea = await GetTextareaAsync("warning").ConfigureAwait(false);
        await textarea.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitToHaveAttributeAsync("data-tid", "TextareaId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.WaitToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_After_Fill()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.WaitToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.WaitNotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_After_Fill()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.FillAsync("1").ConfigureAwait(false);

        await textarea.WaitNotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeEmpty()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.WaitNotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocusedToBeFocused_And_WaitNotToBeFocused()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        await textarea.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await textarea.TextareaLocator.FocusAsync().ConfigureAwait(false);
        await textarea.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Textarea> GetTextareaAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"textarea--{storyName}")).ConfigureAwait(false);
        return new Textarea(Page.GetByTestId("TextareaId"));
    }
}