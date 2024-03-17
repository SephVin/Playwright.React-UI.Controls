using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class AutocompleteTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Autocomplete_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await autocomplete.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Autocomplete_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var visibleAutocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("UnknownAutocompleteId"));
        await visibleAutocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingAutocomplete.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Autocomplete_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--disabled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Autocomplete_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Autocomplete_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--error")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Autocomplete_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Autocomplete_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--warning")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Autocomplete_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Autocomplete()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.ClickAsync().ConfigureAwait(false);

        await autocomplete.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Autocomplete_Is_Not_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Autocomplete_Is_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        var actual = await autocomplete.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("Resident Sleeper");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.FillAsync("newValue").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.FillAsync("newValue").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.FillAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_And_Select_Suggestion()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.FillAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(1).ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_Autocomplete_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.PressAsync("a").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.PressAsync("a").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("aResident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("newValueResident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_And_Select_First_Suggestion()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.PressSequentiallyAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(0).ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.ClearAsync().ConfigureAwait(false);

        await autocomplete.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.FocusAsync().ConfigureAwait(false);

        await autocomplete.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.ClickAsync().ConfigureAwait(false);
        await autocomplete.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.BlurAsync().ConfigureAwait(false);

        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }
}