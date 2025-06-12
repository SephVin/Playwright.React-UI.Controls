using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class RadioExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var visibleRadio = new Radio(Page.GetByTestId("RadioId"));
        var notExistingRadio = new Radio(Page.GetByTestId("UnknownRadioId"));
        await visibleRadio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadio.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--checked")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeChecked()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--disabled")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--disabled")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--disabled")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var visibleRadio = new Radio(Page.GetByTestId("RadioId"));
        var notExistingRadio = new Radio(Page.GetByTestId("UnknownRadioId"));
        await visibleRadio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadio.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var visibleRadio = new Radio(Page.GetByTestId("RadioId"));
        var notExistingRadio = new Radio(Page.GetByTestId("UnknownRadioId"));
        await visibleRadio.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadio.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToHaveAttributeAsync("data-tid", "RadioId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToHaveAttributeAsync("data-tid", "not-RadioId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToHaveTextAsync("NOT-TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--with-value")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().ToHaveValueAsync("RadioValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("radio--default")).ConfigureAwait(false);
        var radio = new Radio(Page.GetByTestId("RadioId"));

        await radio.Expect().Not.ToHaveValueAsync("2").ConfigureAwait(false);
    }
}