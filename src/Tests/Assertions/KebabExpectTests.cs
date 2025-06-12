using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class KebabExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var visibleKebab = new Kebab(Page.GetByTestId("KebabId"));
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingKebab.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--disabled")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--disabled")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var visibleKebab = new Kebab(Page.GetByTestId("KebabId"));
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingKebab.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var visibleKebab = new Kebab(Page.GetByTestId("KebabId"));
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingKebab.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var button = new Kebab(Page.GetByTestId("KebabId"));

        await button.Expect().ToHaveAttributeAsync("data-tid", "KebabId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var button = new Kebab(Page.GetByTestId("KebabId"));

        await button.Expect().Not.ToHaveAttributeAsync("data-tid", "not-KebabId").ConfigureAwait(false);
    }
}