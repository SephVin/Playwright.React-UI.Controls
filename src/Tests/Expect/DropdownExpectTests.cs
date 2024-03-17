using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class DropdownExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var visibleDropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        var notExistingDropdown = new Dropdown(Page.GetByTestId("UnknownDropdownId"));
        await visibleDropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDropdown.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--disabled")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--disabled")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var visibleDropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        var notExistingDropdown = new Dropdown(Page.GetByTestId("UnknownDropdownId"));
        await visibleDropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDropdown.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var visibleDropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        var notExistingDropdown = new Dropdown(Page.GetByTestId("UnknownDropdownId"));
        await visibleDropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDropdown.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().ToHaveAttributeAsync("type", "button").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.Expect().Not.ToHaveAttributeAsync("type", "not-button").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var button = new Dropdown(Page.GetByTestId("DropdownId"));

        await button.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var button = new Dropdown(Page.GetByTestId("DropdownId"));

        await button.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}