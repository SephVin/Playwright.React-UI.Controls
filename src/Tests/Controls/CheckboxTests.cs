using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class CheckboxTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Checkbox_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        await checkbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await checkbox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Checkbox_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var visibleCheckbox = new Checkbox(Page.GetByTestId("CheckboxId"));
        var notExistingCheckbox = new Checkbox(Page.GetByTestId("UnknownCheckboxId"));
        await visibleCheckbox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingCheckbox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Checkbox_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--disabled")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Checkbox_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Checkbox_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Checkbox_Is_InitialIndeterminate()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--initial-indeterminate")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Checkbox_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Checkbox_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--error")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Checkbox_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Checkbox_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--warning")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Checkbox_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Set_Checked_State_When_Checkbox_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.ClickAsync().ConfigureAwait(false);

        await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click_Should_Set_Unchecked_State_When_Checkbox_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.ClickAsync().ConfigureAwait(false);

        await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Should_Set_Checked_State_When_Checkbox_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.CheckAsync().ConfigureAwait(false);

        await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Should_Do_Nothing_When_Checkbox_Is_Already_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.CheckAsync().ConfigureAwait(false);

        await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Should_Set_Unchecked_State_When_Checkbox_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--checked")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.UncheckAsync().ConfigureAwait(false);

        await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Uncheck_Should_Do_Nothing_When_Checkbox_Is_Already_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        await checkbox.UncheckAsync().ConfigureAwait(false);

        await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetText_Returns_Checkbox_Label()
    {
        await Page.GotoAsync(StorybookUrl.Get("checkbox--default")).ConfigureAwait(false);
        var checkbox = new Checkbox(Page.GetByTestId("CheckboxId"));

        var actual = await checkbox.GetTextAsync().ConfigureAwait(false);

        actual.Should().Be("TODO");
    }
}