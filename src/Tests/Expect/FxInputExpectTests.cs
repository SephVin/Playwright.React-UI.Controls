using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class FxInputExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var visibleFxInput = new FxInput(Page.GetByTestId("FxInputId"));
        var notExistingFxInput = new FxInput(Page.GetByTestId("UnknownFxInputId"));
        await visibleFxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingFxInput.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--disabled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--disabled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--disabled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));
        await fxInput.ClickAsync().ConfigureAwait(false);

        await fxInput.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var visibleFxInput = new FxInput(Page.GetByTestId("FxInputId"));
        var notExistingFxInput = new FxInput(Page.GetByTestId("UnknownFxInputId"));
        await visibleFxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingFxInput.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var visibleFxInput = new FxInput(Page.GetByTestId("FxInputId"));
        var notExistingFxInput = new FxInput(Page.GetByTestId("UnknownFxInputId"));
        await visibleFxInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingFxInput.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToHaveAttributeAsync("type", "text").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--default")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToHaveAttributeAsync("type", "not-text").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("fxinput--filled")).ConfigureAwait(false);
        var fxInput = new FxInput(Page.GetByTestId("FxInputId"));

        await fxInput.Expect().Not.ToHaveValueAsync("TODO1").ConfigureAwait(false);
    }
}