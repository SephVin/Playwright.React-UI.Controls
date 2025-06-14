using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class LinkExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var link = await GetLinkAsync("hidden").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);

        await link.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var link = await GetLinkAsync("disabled").ConfigureAwait(false);
        await link.WaitForAsync().ConfigureAwait(false);

        await link.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveAttributeAsync("data-tid", "LinkId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveHref()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveHrefAsync("https://google.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveHref_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitToHaveHrefAsync(new Regex("^https://google.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveHref()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveHrefAsync("https://youtube.com/").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveHref_With_Regex()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);
        await link.WaitNotToHaveHrefAsync(new Regex("^https://you.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var link = await GetLinkAsync("default").ConfigureAwait(false);

        await link.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await link.RootLocator.FocusAsync().ConfigureAwait(false);
        await link.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Link> GetLinkAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"link--{storyName}")).ConfigureAwait(false);
        return new Link(Page.GetByTestId("LinkId"));
    }
}