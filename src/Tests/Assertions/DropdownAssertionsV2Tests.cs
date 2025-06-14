using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class DropdownAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var dropdown = await GetDropdownAsync("hidden").ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);

        await dropdown.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var dropdown = await GetDropdownAsync("disabled").ConfigureAwait(false);
        await dropdown.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var dropdown = await GetDropdownAsync("error").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var dropdown = await GetDropdownAsync("warning").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveAttributeAsync("data-tid", "DropdownId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainItems()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        await dropdown.ExpectV2().ToContainItemsAsync(new[] { "Here goes the header", "TODO 2" })
            .ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        await dropdown.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await dropdown.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await dropdown.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Dropdown> GetDropdownAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dropdown--{storyName}")).ConfigureAwait(false);
        return new Dropdown(Page.GetByTestId("DropdownId"));
    }
}