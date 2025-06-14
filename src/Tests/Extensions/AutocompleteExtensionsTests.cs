using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class AutocompleteExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var autocomplete = await GetAutocompleteAsync("hidden").ConfigureAwait(false);
        await autocomplete.WaitForAsync().ConfigureAwait(false);

        await autocomplete.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var autocomplete = await GetAutocompleteAsync("disabled").ConfigureAwait(false);
        await autocomplete.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var autocomplete = await GetAutocompleteAsync("error").ConfigureAwait(false);
        await autocomplete.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var autocomplete = await GetAutocompleteAsync("warning").ConfigureAwait(false);
        await autocomplete.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitToHaveAttributeAsync("data-tid", "InputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.WaitToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_After_Fill()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.FillAsync("TO").ConfigureAwait(false);

        await autocomplete.WaitToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue_After_Fill()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.FillAsync("1").ConfigureAwait(false);

        await autocomplete.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToBeEmpty()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.WaitNoToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        await autocomplete.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.FocusAsync().ConfigureAwait(false);
        await autocomplete.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Empty()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await autocomplete.AppendTextAsync("newValue").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Not_Empty()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await autocomplete.AppendTextAsync("a").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("TODOa").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.FocusAndBlurAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelectFirstSuggestion()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        await autocomplete.FillAndSelectFirstSuggestionAsync("Grey").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelectSuggestion()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        await autocomplete.FillAndSelectSuggestionAsync("Grey", 1).ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    private async Task<Autocomplete> GetAutocompleteAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"autocomplete--{storyName}")).ConfigureAwait(false);
        return new Autocomplete(Page.GetByTestId("AutocompleteId"));
    }
}