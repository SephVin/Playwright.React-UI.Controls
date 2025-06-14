using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class LinkAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var link = await GetLinkAsync("hidden").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);

        await link.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var link = await GetLinkAsync("disabled").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);

        await link.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveAttributeAsync("data-tid", "LinkId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveHref()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveHrefAsync("https://google.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveHref_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().ToHaveHrefAsync(new Regex("^https://google.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveHref()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveHrefAsync("https://youtube.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveHref_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.ExpectV2().NotToHaveHrefAsync(new Regex("^https://you.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        await link.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await link.RootLocator.FocusAsync().ConfigureAwait(false);
        await link.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Link> GetLinkAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"link--{storyName}")).ConfigureAwait(false);
        return new Link(Page.GetByTestId("LinkId"));
    }
}