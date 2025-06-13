using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class DropdownMenuAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var dropdownMenu = await GetDropdownMenuAsync("hidden").ConfigureAwait(false);
        await dropdownMenu.WaitForAsync().ConfigureAwait(false);

        await dropdownMenu.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToHaveAttributeAsync("data-tid", "DropdownMenuId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainItems()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        await dropdownMenu.ExpectV2().ToContainItemsAsync(new[] { "Here goes the header", "TODO 2" })
            .ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        await dropdownMenu.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await dropdownMenu.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await dropdownMenu.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DropdownMenu> GetDropdownMenuAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"dropdownmenu--{storyName}")).ConfigureAwait(false);
        return new DropdownMenu(Page.GetByTestId("DropdownMenuId"));
    }
}