using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class DateInputTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_DateInput_Is_Visible()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.WaitForAsync().ConfigureAwait(false);

        var actual = await dateInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_DateInput_Is_Not_Exists()
    {
        var visibleDateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        var notExistingDateInput = new DateInput(Page.GetByTestId("HiddenDatePicker"));
        await visibleDateInput.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingDateInput.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_DateInput_Is_Disabled()
    {
        var dateInput = await GetDateInputAsync("disabled").ConfigureAwait(false);

        var actual = await dateInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_DateInput_Is_Enabled()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_DateInput_With_Error()
    {
        var dateInput = await GetDateInputAsync("error").ConfigureAwait(false);

        var actual = await dateInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_DateInput_Without_Error()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        var actual = await dateInput.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_DateInput_With_Warning()
    {
        var dateInput = await GetDateInputAsync("warning").ConfigureAwait(false);

        var actual = await dateInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_DateInput_Without_Warning()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetValue_Return_Value_When_DateInput_Value_Is_Not_Empty()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);

        var actual = await dateInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().Be("01.01.2024");
    }

    [Test]
    public async Task GetValue_Return_Empty_When_DateInput_Value_Is_Empty()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.GetValueAsync().ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task Fill_New_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.NativeInputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await dateInput.FillAsync("02.01.2024").ConfigureAwait(false);

        await dateInput.NativeInputLocator.Expect().ToHaveValueAsync("02.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Rewrite_Existing_Value()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await dateInput.FillAsync("02.01.2024").ConfigureAwait(false);

        await dateInput.NativeInputLocator.Expect().ToHaveValueAsync("02.01.2024").ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_With_Empty_String()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await dateInput.FillAsync(string.Empty).ConfigureAwait(false);

        await dateInput.NativeInputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Clear()
    {
        var dateInput = await GetDateInputAsync("filled").ConfigureAwait(false);
        await dateInput.NativeInputLocator.Expect().ToHaveValueAsync("01.01.2024").ConfigureAwait(false);

        await dateInput.ClearAsync().ConfigureAwait(false);

        await dateInput.NativeInputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Click()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.ClickAsync().ConfigureAwait(false);

        await dateInput.RootLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Hover()
    {
        var dateInput = await GetDateInputAsync("with-tooltip").ConfigureAwait(false);
        await dateInput.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await dateInput.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Focus_And_Blur()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);
        await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.FocusAsync().ConfigureAwait(false);
        await dateInput.RootLocator.Expect().ToBeFocusedAsync().ConfigureAwait(false);

        await dateInput.BlurAsync().ConfigureAwait(false);
        await dateInput.RootLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var dateInput = await GetDateInputAsync("with-tooltip").ConfigureAwait(false);
        await dateInput.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await dateInput.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("DateInputId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var dateInput = await GetDateInputAsync("default").ConfigureAwait(false);

        var actual = await dateInput.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<DateInput> GetDateInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"dateinput--{storyName}")).ConfigureAwait(false);
        return new DateInput(Page.GetByTestId("DateInputId"));
    }
}