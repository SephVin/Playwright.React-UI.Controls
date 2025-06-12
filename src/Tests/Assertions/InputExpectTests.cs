using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class InputExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var visibleInput = new Input(Page.GetByTestId("InputId"));
        var notExistingInput = new Input(Page.GetByTestId("UnknownInputId"));
        await visibleInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingInput.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--disabled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--disabled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--disabled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.ClickAsync().ConfigureAwait(false);

        await input.Expect().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeFocused()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var visibleInput = new Input(Page.GetByTestId("InputId"));
        var notExistingInput = new Input(Page.GetByTestId("UnknownInputId"));
        await visibleInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingInput.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var visibleInput = new Input(Page.GetByTestId("InputId"));
        var notExistingInput = new Input(Page.GetByTestId("UnknownInputId"));
        await visibleInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingInput.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToHaveAttributeAsync("data-tid", "InputId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToHaveAttributeAsync("data-tid", "InputId2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.Expect().Not.ToHaveValueAsync("TODO1").ConfigureAwait(false);
    }
}