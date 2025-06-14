using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class FxInputAssertionsV2 : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var fxInput = await GetFxInputAsync("hidden").ConfigureAwait(false);
        await fxInput.WaitForAsync().ConfigureAwait(false);

        await fxInput.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var fxInput = await GetFxInputAsync("disabled").ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var fxInput = await GetFxInputAsync("error").ConfigureAwait(false);
        await fxInput.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var fxInput = await GetFxInputAsync("warning").ConfigureAwait(false);
        await fxInput.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().ToHaveAttributeAsync("data-tid", "FxInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.ExpectV2().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_After_Fill()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.FillAsync("newValue").ConfigureAwait(false);

        await fxInput.ExpectV2().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_After_Fill()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.FillAsync("1").ConfigureAwait(false);

        await fxInput.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var fxInput = await GetFxInputAsync("filled").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);

        await fxInput.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await fxInput.InputLocator.FocusAsync().ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeAuto()
    {
        var fxInput = await GetFxInputAsync("auto").ConfigureAwait(false);
        await fxInput.ExpectV2().ToBeAutoAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAuto()
    {
        var fxInput = await GetFxInputAsync("default").ConfigureAwait(false);
        await fxInput.ExpectV2().NotToBeAutoAsync().ConfigureAwait(false);
    }

    private async Task<FxInput> GetFxInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"fxinput--{storyName}")).ConfigureAwait(false);
        return new FxInput(Page.GetByTestId("FxInputId"));
    }
}