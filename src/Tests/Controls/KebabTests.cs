using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class KebabTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Kebab_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));
        await kebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await kebab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Kebab_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var visibleKebab = new Kebab(Page.GetByTestId("KebabId"));
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingKebab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Kebab_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--disabled")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        var actual = await kebab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Kebab_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        var actual = await kebab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Open_Menu()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.ClickAsync().ConfigureAwait(false);
        var actual = await kebab.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task SelectByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.SelectByTextAsync("TODO 2").ConfigureAwait(false);

        await Page.GetByTestId("StaticToast").GetByTestId("ToastView__root")
            .Expect()
            .ToHaveTextAsync("Clicked TODO 2")
            .ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.SelectByIndexAsync(1).ConfigureAwait(false);

        await Page.GetByTestId("StaticToast").GetByTestId("ToastView__root")
            .Expect()
            .ToHaveTextAsync("Clicked TODO 2")
            .ConfigureAwait(false);
    }
}