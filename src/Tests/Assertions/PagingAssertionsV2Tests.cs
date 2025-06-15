using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class PagingAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var paging = await GetPagingAsync("hidden").ConfigureAwait(false);
        await paging.WaitForAsync().ConfigureAwait(false);

        await paging.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var paging = await GetPagingAsync("disabled").ConfigureAwait(false);
        await paging.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().ToHaveAttributeAsync("data-tid", "PagingId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHavePagesCount()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.ExpectV2().ToHavePagesCountAsync(8).ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveActivePage()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.GoToLastPageAsync().ConfigureAwait(false);

        await paging.ExpectV2().ToHaveActivePageAsync(8).ConfigureAwait(false);
    }

    private async Task<Paging> GetPagingAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"paging--{storyName}")).ConfigureAwait(false);
        return new Paging(Page.GetByTestId("PagingId"));
    }
}