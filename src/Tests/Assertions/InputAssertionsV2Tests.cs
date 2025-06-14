using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class InputAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var input = await GetInputAsync("hidden").ConfigureAwait(false);
        await input.WaitForAsync().ConfigureAwait(false);

        await input.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var input = await GetInputAsync("disabled").ConfigureAwait(false);
        await input.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var input = await GetInputAsync("error").ConfigureAwait(false);
        await input.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var input = await GetInputAsync("warning").ConfigureAwait(false);
        await input.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().ToHaveAttributeAsync("data-tid", "InputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.ExpectV2().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_After_Fill()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.FillAsync("newValue").ConfigureAwait(false);

        await input.ExpectV2().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_After_Fill()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.FillAsync("1").ConfigureAwait(false);

        await input.ExpectV2().NotToHaveValueAsync("Test").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        await input.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await input.InputLocator.FocusAsync().ConfigureAwait(false);
        await input.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Input> GetInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"input--{storyName}")).ConfigureAwait(false);
        return new Input(Page.GetByTestId("InputId"));
    }
}