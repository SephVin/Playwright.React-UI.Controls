using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class InputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var input = await GetInputAsync("hidden").ConfigureAwait(false);
        await input.WaitForAsync().ConfigureAwait(false);

        await input.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var input = await GetInputAsync("disabled").ConfigureAwait(false);
        await input.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var input = await GetInputAsync("error").ConfigureAwait(false);
        await input.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var input = await GetInputAsync("warning").ConfigureAwait(false);
        await input.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitToHaveAttributeAsync("data-tid", "InputId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.WaitToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_After_Fill()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.FillAsync("TO").ConfigureAwait(false);

        await input.WaitToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToHaveValue_After_Fill()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.FillAsync("1").ConfigureAwait(false);

        await input.WaitNoToHaveValueAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNoToBeEmpty()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.WaitNoToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);

        await input.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await input.InputLocator.FocusAsync().ConfigureAwait(false);
        await input.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Empty()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().ToBeEmptyAsync().ConfigureAwait(false);

        await input.AppendTextAsync("newValue").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Not_Empty()
    {
        var input = await GetInputAsync("filled").ConfigureAwait(false);
        await input.InputLocator.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.AppendTextAsync("a").ConfigureAwait(false);

        await input.InputLocator.Expect().ToHaveValueAsync("TODOa").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        var input = await GetInputAsync("default").ConfigureAwait(false);
        await input.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.FocusAndBlurAsync().ConfigureAwait(false);

        await input.InputLocator.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    private async Task<Input> GetInputAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"input--{storyName}")).ConfigureAwait(false);
        return new Input(Page.GetByTestId("InputId"));
    }
}