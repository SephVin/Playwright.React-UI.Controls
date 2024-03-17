using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class AutocompleteExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var visibleAutocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("UnknownAutocompleteId"));
        await visibleAutocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingAutocomplete.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--disabled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--disabled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--disabled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        await autocomplete.ClickAsync().ConfigureAwait(false);

        await autocomplete.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var visibleAutocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("UnknownAutocompleteId"));
        await visibleAutocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingAutocomplete.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var visibleAutocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));
        var notExistingAutocomplete = new Autocomplete(Page.GetByTestId("UnknownAutocompleteId"));
        await visibleAutocomplete.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingAutocomplete.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToHaveAttributeAsync("type", "text").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--default")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToHaveAttributeAsync("type", "not-text").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("autocomplete--filled")).ConfigureAwait(false);
        var autocomplete = new Autocomplete(Page.GetByTestId("AutocompleteId"));

        await autocomplete.Expect().Not.ToHaveValueAsync("TODO1").ConfigureAwait(false);
    }
}