using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public sealed class InputExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var visibleInput = new Input(Page.GetByTestId("InputId"));
        var notExistingInput = new Input(Page.GetByTestId("UnknownInputId"));
        await visibleInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingInput.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--error")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--warning")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task Fill_Input_With_Mask()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--time-mask")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.FillAsync("1234").ConfigureAwait(false);
        await input.FillAsync("1356").ConfigureAwait(false);
        await input.FillAsync("2105").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("21:05").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync(string.Empty).ConfigureAwait(false);

        await input.AppendTextAsync("newValue").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);
    }

    [Test]
    public async Task AppendText_When_Input_Is_Not_Empty()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().ToHaveValueAsync("TODO").ConfigureAwait(false);

        await input.AppendTextAsync("a").ConfigureAwait(false);

        await input.Expect().ToHaveValueAsync("TODOa").ConfigureAwait(false);
    }

    [Test]
    public async Task FocusAndBlur()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));
        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);

        await input.FocusAndBlurAsync().ConfigureAwait(false);

        await input.Expect().Not.ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--filled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitValueAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValueAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitValueAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--default")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("input--disabled")).ConfigureAwait(false);
        var input = new Input(Page.GetByTestId("InputId"));

        await input.WaitDisabledAsync().ConfigureAwait(false);
    }
}