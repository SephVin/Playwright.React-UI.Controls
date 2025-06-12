using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class HtmlButtonExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var htmlButton = await GetHtmlButtonAsync("hidden").ConfigureAwait(false);
        await htmlButton.WaitForAsync().ConfigureAwait(false);

        await htmlButton.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var htmlButton = await GetHtmlButtonAsync("disabled").ConfigureAwait(false);
        await htmlButton.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToHaveAttributeAsync("data-tid", "HtmlButtonId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainTextToContainText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);
        await htmlButton.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var htmlButton = await GetHtmlButtonAsync("default").ConfigureAwait(false);

        await htmlButton.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await htmlButton.RootLocator.FocusAsync().ConfigureAwait(false);
        await htmlButton.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<HtmlButton> GetHtmlButtonAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"htmlbutton--{storyName}")).ConfigureAwait(false);
        return new HtmlButton(Page.GetByTestId("HtmlButtonId"));
    }
}