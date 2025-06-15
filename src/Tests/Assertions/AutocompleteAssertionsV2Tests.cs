using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class AutocompleteAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var autocomplete = await GetAutocompleteAsync("hidden").ConfigureAwait(false);
        await autocomplete.WaitForAsync().ConfigureAwait(false);

        await autocomplete.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var autocomplete = await GetAutocompleteAsync("disabled").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var autocomplete = await GetAutocompleteAsync("error").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var autocomplete = await GetAutocompleteAsync("warning").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToHaveAttributeAsync("data-tid", "AutocompleteId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToHaveValueAsync("Resident Sleeper").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_After_Fill()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.FillAsync("newValue").ConfigureAwait(false);

        await autocomplete.ExpectV2().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_After_Fill()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.FillAsync("1").ConfigureAwait(false);

        await autocomplete.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);
        await autocomplete.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var autocomplete = await GetAutocompleteAsync("filled").ConfigureAwait(false);
        await autocomplete.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var autocomplete = await GetAutocompleteAsync("default").ConfigureAwait(false);

        await autocomplete.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await autocomplete.InputLocator.FocusAsync().ConfigureAwait(false);
        await autocomplete.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Autocomplete> GetAutocompleteAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"autocomplete--{storyName}")).ConfigureAwait(false);
        return new Autocomplete(Page.GetByTestId("AutocompleteId"));
    }
}