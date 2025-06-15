using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class FxInputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var fxInput = await GetFxInputAsync("hidden").ConfigureAwait(false);
        await fxInput.WaitForAsync().ConfigureAwait(false);

        await fxInput.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var fxInput = await GetFxInputAsync("disabled").ConfigureAwait(false);
        await fxInput.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var fxInput = await GetFxInputAsync("error").ConfigureAwait(false);
        await fxInput.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var fxInput = await GetFxInputAsync("warning").ConfigureAwait(false);
        await fxInput.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitToHaveAttributeAsync("data-tid", "FxInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.WaitToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_After_Fill()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.FillAsync("TO").ConfigureAwait(false);

        await fxInput.WaitToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue_After_Fill()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.FillAsync("1").ConfigureAwait(false);

        await fxInput.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToBeEmpty()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.WaitNoToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        await fxInput.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.InputLocator.FocusAsync().ConfigureAwait(false);
        await fxInput.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Empty()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await fxInput.AppendTextAsync("newValue").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Not_Empty()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await fxInput.AppendTextAsync("a").ConfigureAwait(false);

        await fxInput.InputLocator.Expect().ToHaveValueAsync("TODOa").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.FocusAndBlurAsync().ConfigureAwait(false);

        await fxInput.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeAuto()
    {
        var fxInput = await GetFxInputAsync("auto").ConfigureAwait(false);
        await fxInput.WaitToBeAutoAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeAuto()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.WaitNotToBeAutoAsync().ConfigureAwait(false);
    }

    private async Task<FxInput> GetFxInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"fxinput--{storyName}")).ConfigureAwait(false);
        return new FxInput(Page.GetByTestId("FxInputId"));
    }
}