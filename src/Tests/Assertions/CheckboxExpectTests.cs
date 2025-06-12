using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class CheckboxExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var visibleCheckbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("UnknownCheckboxId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCheckbox.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--disabled")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--disabled")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--disabled")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var visibleCheckbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("UnknownCheckboxId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCheckbox.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var visibleCheckbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("UnknownCheckboxId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingCheckbox.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToHaveAttributeAsync("data-tid", "CheckboxId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToHaveAttributeAsync("data-tid", "not-CheckboxId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.Expect().Not.ToHaveTextAsync("NOT-TODO").ConfigureAwait(false);
    }
}