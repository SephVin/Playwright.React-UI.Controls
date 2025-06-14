using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class DropdownExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var dropdown = await GetDropdownAsync("hidden").ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);

        await dropdown.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var dropdown = await GetDropdownAsync("disabled").ConfigureAwait(false);
        await dropdown.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var dropdown = await GetDropdownAsync("error").ConfigureAwait(false);
        await dropdown.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var dropdown = await GetDropdownAsync("warning").ConfigureAwait(false);
        await dropdown.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToHaveAttributeAsync("data-tid", "DropdownId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);
        await dropdown.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainItems()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        await dropdown.WaitToContainItemsAsync(new[] { "Here goes the header", "TODO 2" })
            .ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var dropdown = await GetDropdownAsync("default").ConfigureAwait(false);

        await dropdown.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await dropdown.ButtonLocator.FocusAsync().ConfigureAwait(false);
        await dropdown.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Dropdown> GetDropdownAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dropdown--{storyName}")).ConfigureAwait(false);
        return new Dropdown(Page.GetByTestId("DropdownId"));
    }
}