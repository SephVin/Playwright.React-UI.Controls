using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class RadioTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Radio_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));
        await radio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await radio.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Radio_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var visibleRadio = new Radio(Page.GetByTestId("RadioId"));
        var notExistingRadio = new Radio(Page.GetByTestId("UnknownRadioId"));
        await visibleRadio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingRadio.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Radio_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--disabled")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Radio_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsChecked_Return_True_When_Radio_Is_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--checked")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsChecked_Return_False_When_Radio_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.IsCheckedAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_Radio_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--error")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Radio_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Radio_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--warning")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Radio_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var actual = await radio.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click_Should_Check_Radio()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("RadioId");
        var radio = new Radio(context);

        await radio.ClickAsync().ConfigureAwait(false);

        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetValue_Return_Radio_Text()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var text = await radio.GetTextAsync().ConfigureAwait(false);

        text.Should().Be("TODO");
    }

    [Test]
    public async Task GetText_Return_Radio_Value()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        var text = await radio.GetValueAsync().ConfigureAwait(false);

        text.Should().Be("1");
    }

    [Test]
    public async Task Check_Should_Set_Checked_State_When_Radio_Is_Unchecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.CheckAsync().ConfigureAwait(false);

        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Check_Should_Do_Nothing_When_Radio_Is_Already_Checked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--checked")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.CheckAsync().ConfigureAwait(false);

        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }
}