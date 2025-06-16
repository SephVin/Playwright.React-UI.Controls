using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class HtmlButtonAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var htmlButton = await GetHtmlButtonAsync("hidden").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);

        await htmlButton.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var htmlButton = await GetHtmlButtonAsync("disabled").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToHaveAttributeAsync("data-tid", "ButtonId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        await htmlButton.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await htmlButton.RootLocator.FocusAsync().ConfigureAwait(false);
        await htmlButton.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<HtmlButton> GetHtmlButtonAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"htmlbutton--{storyName}")).ConfigureAwait(false);
        return new HtmlButton(Page.GetByTestId("ButtonId"));
    }
}