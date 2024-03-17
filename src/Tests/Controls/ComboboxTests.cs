using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public sealed class ComboboxTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Combobox_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));
        await combobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await combobox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Combobox_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var visibleCombobox = new Combobox(Page.GetByTestId("ComboboxId"));
        var notExistingCombobox = new Combobox(Page.GetByTestId("UnknownComboboxId"));
        await visibleCombobox.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingCombobox.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Combobox_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--disabled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Combobox_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Combobox_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--error")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Combobox_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Combobox_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--warning")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Combobox_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Focus_Into_Combobox()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));
        await combobox.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.ClickAsync().ConfigureAwait(false);

        await combobox.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetSelectedValue_Return_Empty_When_Combobox_Value_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetSelectedValue_Return_Value_When_Combobox_Value_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--filled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        var actual = await combobox.GetSelectedValueAsync().ConfigureAwait(false);

        actual.Should().Be("First");
    }

    [Test]
    public async Task SelectFirst_Set_First_Value_From_Combobox()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectFirstAsync("th").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Third").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirst_With_Loading()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--loading")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectFirstAsync("th").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Third").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectFirst_Multiple_Selects()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectFirstAsync("th").ConfigureAwait(false);
        await combobox.SelectFirstAsync("Second").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectSingle_Set_Single_Value_From_Combobox()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectSingleAsync("Third").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Third").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectSingle_With_Loading()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--loading")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectSingleAsync("Third").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Third").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectSingle_Multiple_Selects()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.SelectSingleAsync("Third").ConfigureAwait(false);
        await combobox.SelectSingleAsync("Second").ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectSingle_Throws_When_Menu_Have_More_Than_One_Values()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        Assert.ThrowsAsync<PlaywrightException>(() => combobox.SelectSingleAsync("Th"));
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--filled")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));

        await combobox.ClearAsync().ConfigureAwait(false);

        await combobox.Expect().ToHaveTextAsync(string.Empty).ConfigureAwait(false);
    }

    [Test]
    public async Task Focus()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));
        await combobox.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.FocusAsync().ConfigureAwait(false);

        await combobox.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Blur()
    {
        await Page.GotoAsync(StorybookUrl.Get("combobox--default")).ConfigureAwait(false);
        var combobox = new Combobox(Page.GetByTestId("ComboboxId"));
        await combobox.ClickAsync().ConfigureAwait(false);
        await combobox.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await combobox.BlurAsync().ConfigureAwait(false);

        await combobox.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }
}