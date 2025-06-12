using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ComboBoxExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var visibleCombobox = new Combobox(Page.GetByTestId("ComboBoxId"));
        var notExistingCombobox = new Combobox(Page.GetByTestId("UnknownComboboxId"));
        await visibleCombobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCombobox.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--disabled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--disabled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--disabled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));
        await combobox.ClickAsync().ConfigureAwait(false);

        await combobox.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var visibleCombobox = new Combobox(Page.GetByTestId("ComboBoxId"));
        var notExistingCombobox = new Combobox(Page.GetByTestId("UnknownComboboxId"));
        await visibleCombobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCombobox.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var visibleCombobox = new Combobox(Page.GetByTestId("ComboBoxId"));
        var notExistingCombobox = new Combobox(Page.GetByTestId("UnknownComboboxId"));
        await visibleCombobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCombobox.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToHaveAttributeAsync("data-tid", "ComboBoxId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToHaveAttributeAsync("data-tid", "not-ComboboxId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--filled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().ToHaveTextAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--filled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboBoxId"));

        await combobox.Expect().Not.ToHaveTextAsync("NotFirst").ConfigureAwait(false);
    }
}