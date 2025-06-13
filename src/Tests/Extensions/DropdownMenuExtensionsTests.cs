using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class DropdownMenuExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var dropdownMenu = await GetDropdownMenuAsync("hidden").ConfigureAwait(false);
        await dropdownMenu.WaitForAsync().ConfigureAwait(false);

        await dropdownMenu.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToHaveAttributeAsync("data-tid", "DropdownMenuId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);
        await dropdownMenu.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainItems()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        await dropdownMenu.WaitToContainItemsAsync(new[] { "Here goes the header", "TODO 2" })
            .ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var dropdownMenu = await GetDropdownMenuAsync("default").ConfigureAwait(false);

        await dropdownMenu.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await dropdownMenu.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await dropdownMenu.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<DropdownMenu> GetDropdownMenuAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"dropdownmenu--{storyName}")).ConfigureAwait(false);
        return new DropdownMenu(Page.GetByTestId("DropdownMenuId"));
    }
}