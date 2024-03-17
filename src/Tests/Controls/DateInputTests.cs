using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DateInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DateInput_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));
        await dateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await dateInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DateInput_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var visibleDateInput = new DateInput(Page.GetByTestId("DateInputId"));
        var notExistingDateInput = new DateInput(Page.GetByTestId("UnknownDateInputId"));
        await visibleDateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingDateInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_DateInput_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--disabled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_DateInput_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_DateInput_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--error")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_DateInput_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_DateInput_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--warning")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_DateInput_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Empty_When_DateInput_Value_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetValue_Return_Value_When_DateInput_Value_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--filled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        var actual = await dateInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("24.08.2022");
    }

    [Test]
    public async Task Fill_New_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.FillAsync("01.01.2024").ConfigureAwait(false);

        await dateInput.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--filled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));
        await dateInput.Expect().ToHaveValueAsync("24.08.2022").ConfigureAwait(false);

        await dateInput.FillAsync("01.01.2024").ConfigureAwait(false);

        await dateInput.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Clear_Existing_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--filled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.ClearAsync().ConfigureAwait(false);

        await dateInput.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);
    }
}