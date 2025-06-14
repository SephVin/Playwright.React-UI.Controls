using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class AutocompleteExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var visibleAutocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("UnknownAutocompleteId"));
        await visibleAutocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingAutocomplete.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--error")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--warning")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Autocomplete_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.AppendTextAsync("newValue").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Autocomplete_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.AppendTextAsync("a").ConfigureAwait(false);

        // ReSharper disable once StringLiteralTypo
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleepera").ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelectFirstSuggestion()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.FillAndSelectFirstSuggestionAsync("Grey").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelectSuggestionByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.FillAndSelectSuggestionByIndexAsync("Grey", 1).ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirstSuggestion()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.FillAsync("Grey").ConfigureAwait(false);

        await autocomplete.SelectFirstSuggestionAsync().ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendTextAndSelectFirstSuggestion()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.FillAsync("Grey").ConfigureAwait(false);

        await autocomplete.AppendTextAndSelectFirstSuggestionAsync(" F").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.FocusAndBlurAsync().ConfigureAwait(false);

        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--disabled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.WaitToBeDisabledAsync().ConfigureAwait(false);
    }
}