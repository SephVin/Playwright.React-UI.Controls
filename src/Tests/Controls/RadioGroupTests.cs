using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class RadioGroupTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_RadioGroup_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        await radioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await radioGroup.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_RadioGroup_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var visibleRadioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("UnknownRadioGroupId"));
        await visibleRadioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingRadioGroup.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_RadioGroup_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--disabled")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_RadioGroup_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Not_All_Radio_Are_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--disabled-item")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_RadioGroup_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--error")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_True_When_Not_All_Radio_Has_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--error-item")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_RadioGroup_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_RadioGroup_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--warning")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Not_All_Radio_Has_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--warning-item")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_RadioGroup_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetItems()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var items = await radioGroup.GetItemsAsync().ConfigureAwait(false);

        items.Should().HaveCount(2);
    }

    [Test]
    public async Task CheckByValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("RadioGroupId");
        var radioGroup = new RadioGroup(context);

        await radioGroup.CheckByValueAsync("2").ConfigureAwait(false);

        var items = await context.Locator("[data-tid='Radio__root']").AllAsync().ConfigureAwait(false);
        await items.Last().Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task CheckByIndex()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("RadioGroupId");
        var radioGroup = new RadioGroup(context);

        await radioGroup.CheckByIndexAsync(1).ConfigureAwait(false);

        var items = await context.Locator("[data-tid='Radio__root']").AllAsync().ConfigureAwait(false);
        await items.Last().Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task CheckByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("RadioGroupId");
        var radioGroup = new RadioGroup(context);

        await radioGroup.CheckByTextAsync("TODO 2").ConfigureAwait(false);

        var items = await context.Locator("[data-tid='Radio__root']").AllAsync().ConfigureAwait(false);
        await items.Last().Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetCheckedRadio()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--checked")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.GetCheckedRadioAsync().ConfigureAwait(false);

        var text = await actual.GetTextAsync().ConfigureAwait(false);
        text.Should().Be("TODO 2");
    }

    [Test]
    public async Task GetRadioIndexByText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.GetRadioIndexByTextAsync("TODO 2").ConfigureAwait(false);

        actual.Should().Be(1);
    }

    [Test]
    public async Task GetRadioIndexByValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        var actual = await radioGroup.GetRadioIndexByValueAsync("2").ConfigureAwait(false);

        actual.Should().Be(1);
    }
}