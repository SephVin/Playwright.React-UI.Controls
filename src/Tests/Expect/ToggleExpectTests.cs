using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class ToggleExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var visibleToggle = new Toggle(Page.GetByTestId("ToggleId"));
        var notExistingToggle = new Toggle(Page.GetByTestId("UnknownToggleId"));
        await visibleToggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingToggle.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--checked")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--disabled")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--disabled")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--disabled")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var visibleToggle = new Toggle(Page.GetByTestId("ToggleId"));
        var notExistingToggle = new Toggle(Page.GetByTestId("UnknownToggleId"));
        await visibleToggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingToggle.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var visibleToggle = new Toggle(Page.GetByTestId("ToggleId"));
        var notExistingToggle = new Toggle(Page.GetByTestId("UnknownToggleId"));
        await visibleToggle.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingToggle.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToHaveAttributeAsync("data-tid", "ToggleId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToHaveAttributeAsync("data-tid", "not-ToggleId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("toggle--default")).ConfigureAwait(false);
        var toggle = new Toggle(Page.GetByTestId("ToggleId"));

        await toggle.Expect().Not.ToHaveTextAsync("NOT-TODO").ConfigureAwait(false);
    }
}