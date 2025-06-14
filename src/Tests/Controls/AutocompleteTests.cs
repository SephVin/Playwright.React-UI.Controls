using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class AutocompleteTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Autocomplete_Is_Visible()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.WaitForAsync().ConfigureAwait(false);

        var actual = await autocomplete.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Autocomplete_Is_Not_Exist()
    {
        var visibleAutocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("HiddenAutocomplete"));
        await visibleAutocomplete.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingAutocomplete.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Autocomplete_Is_Disabled()
    {
        var autocomplete = await GetAutocompleteAsync("disabled").ConfigureAwait(false);

        var actual = await autocomplete.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Autocomplete_Is_Enabled()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Autocomplete_With_Error()
    {
        var autocomplete = await GetAutocompleteAsync("error").ConfigureAwait(false);

        var actual = await autocomplete.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Autocomplete_Without_Error()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Autocomplete_With_Warning()
    {
        var autocomplete = await GetAutocompleteAsync("warning").ConfigureAwait(false);

        var actual = await autocomplete.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Autocomplete_Without_Warning()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_Autocomplete_Is_Filled()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);

        var actual = await autocomplete.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("Resident Sleeper");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_Autocomplete_Is_Not_Filled()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await autocomplete.FillAsync("newValue").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.FillAsync("newValue").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.FillAsync(string.Empty).ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_And_SelectSuggestion_By_Index()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);

        await autocomplete.FillAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(1).ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_And_SelectSuggestion_By_Text()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);

        await autocomplete.FillAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync("Grey Space").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_And_SelectSuggestion_By_Regex()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);

        await autocomplete.FillAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(new Regex("^Grey Sp.*")).ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Space").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_And_SelectFirstSuggestion()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);

        await autocomplete.FillAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectFirstSuggestionAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_When_Autocomplete_Is_Empty()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await autocomplete.PressAsync("a").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("a").ConfigureAwait(false);
    }

    [Test]
    public async Task Press_Add_Char_At_The_Beginning_Of_Existing_Value()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.PressAsync("a").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("aResident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_New_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await autocomplete.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_Add_Value_At_The_Beginning_Of_Existing_Value()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.PressSequentiallyAsync("newValue").ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("newValueResident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task PressSequentially_And_SelectSuggestion()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        await autocomplete.PressSequentiallyAsync("Grey").ConfigureAwait(false);
        await autocomplete.SelectSuggestionAsync(0).ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Grey Face").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);

        await autocomplete.ClearAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.ClickAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.FocusAsync().ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.BlurAsync().ConfigureAwait(false);
        await autocomplete.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var autocomplete = await GetAutocompleteAsync("with-tooltip").ConfigureAwait(false);
        await autocomplete.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await autocomplete.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var autocomplete = await GetAutocompleteAsync("with-tooltip").ConfigureAwait(false);
        await autocomplete.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await autocomplete.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("AutocompleteId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        var actual = await autocomplete.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Autocomplete> GetAutocompleteAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"autocomplete--{storyName}")).ConfigureAwait(false);
        return new Autocomplete(Page.GetByTestId("AutocompleteId"));
    }
}