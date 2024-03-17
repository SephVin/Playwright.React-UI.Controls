using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class SelectTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_SelectButton_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));
        await select.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await select.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_True_When_SelectLink_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));
        await select.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await select.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_SelectButton_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingSelect.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsVisible_Return_False_When_SelectLink_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingSelect.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_SelectButton_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--disabled-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_SelectLink_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--disabled-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_SelectButton_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_SelectLink_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Select_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--error")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Select_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Select_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--warning")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Select_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_For_SelectButton_When_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--filled-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("Two");
    }

    [Test]
    public async Task GetValue_Return_Placeholder_For_SelectButton_When_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.GetValueAsync().ConfigureAwait(false);

        // ReSharper disable StringLiteralTypo
        actual.Should().Be("Ничего не выбрано");
        // ReSharper restore StringLiteralTypo
    }

    [Test]
    public async Task GetValue_Return_Value_For_SelectLink_When_Filled()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--filled-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("Two");
    }

    [Test]
    public async Task GetValue_Return_Placeholder_For_SelectLink_When_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        var actual = await select.GetValueAsync().ConfigureAwait(false);

        // ReSharper disable StringLiteralTypo
        actual.Should().Be("Ничего не выбрано");
        // ReSharper restore StringLiteralTypo
    }

    [Test]
    public async Task SelectValue_In_SelectButton()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-button")).ConfigureAwait(false);
        var context = Page.GetByTestId("SelectId");
        var select = new Select(context);

        await select.SelectValueAsync("Three").ConfigureAwait(false);

        await context.Expect().ToHaveTextAsync("Three").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectValue_In_SelectLink()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--default-link")).ConfigureAwait(false);
        var context = Page.GetByTestId("SelectId");
        var select = new Select(context);

        await select.SelectValueAsync("Three").ConfigureAwait(false);

        await context.Expect().ToHaveTextAsync("Three").ConfigureAwait(false);
    }

    [Test]
    public async Task SelectValueBySearch()
    {
        await Page.GotoAsync(StorybookUrl.Get("select--search")).ConfigureAwait(false);
        var context = Page.GetByTestId("SelectId");
        var select = new Select(context);

        await select.SelectFirstValueBySearchAsync("T").ConfigureAwait(false);

        await context.Expect().ToHaveTextAsync("Two").ConfigureAwait(false);
    }
}