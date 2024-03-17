using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class TextareaExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var visibleTextarea = new Textarea(Page.GetByTestId("TextareaId"));
        var notExistingTextarea = new Textarea(Page.GetByTestId("UnknownTextareaId"));
        await visibleTextarea.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingTextarea.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--disabled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--error")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--warning")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--default")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitValue()
    {
        await Page.GotoAsync(StorybookUrl.Get("textarea--filled")).ConfigureAwait(false);
        var textarea = new Textarea(Page.GetByTestId("TextareaId"));

        await textarea.WaitValueAsync("TODO").ConfigureAwait(false);
    }
}