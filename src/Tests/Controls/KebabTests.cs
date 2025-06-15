using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class KebabTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Kebab_Is_Visible()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.WaitForAsync().ConfigureAwait(false);

        var actual = await kebab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Kebab_Is_Not_Exists()
    {
        var visibleKebab = await GetKebabAsync("default").ConfigureAwait(false);
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingKebab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Kebab_Is_Disabled()
    {
        var kebab = await GetKebabAsync("disabled").ConfigureAwait(false);

        var actual = await kebab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Kebab_Is_Enabled()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_False_When_Menu_Is_Closed()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsMenuOpened_Return_True_When_Menu_Is_Opened()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.RootLocator.ClickAsync().ConfigureAwait(false);

        var actual = await kebab.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task SelectByText()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await kebab.SelectByTextAsync("TODO 2").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByText_With_Regex()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await kebab.SelectByTextAsync(new Regex("^TODO 2.*")).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByIndex()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await kebab.SelectByIndexAsync(1).ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectByDataTid()
    {
        var kebab = await GetKebabAsync("with-menu-data-tid").ConfigureAwait(false);
        var toast = new Toast(Page.GetByTestId("ToastView__root"));
        await toast.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await kebab.SelectByDataTidAsync("TODO2").ConfigureAwait(false);

        await toast.RootLocator.Expect().ToHaveTextAsync("Clicked TODO 2").ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        await kebab.ClickAsync().ConfigureAwait(false);
        var actual = await kebab.IsMenuOpenedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task Hover()
    {
        var dropdown = await GetKebabAsync("with-tooltip").ConfigureAwait(false);
        await dropdown.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dropdown.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetMenuItems()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.GetMenuItemsAsync().ConfigureAwait(false);
        var items = await actual.GetItemsAsync().ConfigureAwait(false);
        var itemValues = await items.ToAsyncEnumerable()
            .SelectAwait(async x => await x.GetTextAsync().ConfigureAwait(false))
            .ToListAsync()
            .ConfigureAwait(false);

        itemValues.Should().BeEquivalentTo("TODO 1", "TODO 2");
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("KebabId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        var actual = await kebab.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<Kebab> GetKebabAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"kebab--{storyName}")).ConfigureAwait(false);
        return new Kebab(Page.GetByTestId("KebabId"));
    }
}