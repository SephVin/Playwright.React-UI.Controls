using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class TextareaAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var button = await GetTextareaAsync("default").ConfigureAwait(false);
        await button.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var textarea = await GetTextareaAsync("hidden").ConfigureAwait(false);
        await textarea.WaitForAsync().ConfigureAwait(false);

        await textarea.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var textarea = await GetTextareaAsync("disabled").ConfigureAwait(false);
        await textarea.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var textarea = await GetTextareaAsync("error").ConfigureAwait(false);
        await textarea.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var textarea = await GetTextareaAsync("warning").ConfigureAwait(false);
        await textarea.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().ToHaveAttributeAsync("data-tid", "TextareaId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.ExpectV2().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_After_Fill()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.FillAsync("newValue").ConfigureAwait(false);

        await textarea.ExpectV2().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_After_Fill()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.FillAsync("1").ConfigureAwait(false);

        await textarea.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);
        await textarea.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var textarea = await GetTextareaAsync("filled").ConfigureAwait(false);
        await textarea.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var textarea = await GetTextareaAsync("default").ConfigureAwait(false);

        await textarea.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await textarea.TextareaLocator.FocusAsync().ConfigureAwait(false);
        await textarea.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Textarea> GetTextareaAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"textarea--{storyName}")).ConfigureAwait(false);
        return new Textarea(Page.GetByTestId("TextareaId"));
    }
}