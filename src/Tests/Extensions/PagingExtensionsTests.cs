using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class PagingExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var paging = await GetPagingAsync("hidden").ConfigureAwait(false);
        await paging.WaitForAsync().ConfigureAwait(false);

        await paging.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var paging = await GetPagingAsync("disabled").ConfigureAwait(false);
        await paging.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitActivePage()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitActivePageAsync(2).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitPagesCount()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitPagesCountAsync(8).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitToHaveAttributeAsync("data-tid", "PagingId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var paging = await GetPagingAsync("default").ConfigureAwait(false);
        await paging.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    private async Task<Paging> GetPagingAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"paging--{storyName}")).ConfigureAwait(false);
        return new Paging(Page.GetByTestId("PagingId"));
    }
}