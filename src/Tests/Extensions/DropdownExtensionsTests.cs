using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class DropdownExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var visibleDropdown = new Dropdown(Page.GetByTestId("DropdownId"));
        var notExistingDropdown = new Dropdown(Page.GetByTestId("UnknownDropdownId"));
        await visibleDropdown.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDropdown.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitError()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--error")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitErrorAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitErrorAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarning()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--warning")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitWarningAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitWarningAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--disabled")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dropdown--default")).ConfigureAwait(false);
        var dropdown = new Dropdown(Page.GetByTestId("DropdownId"));

        await dropdown.WaitTextAsync("TODO").ConfigureAwait(false);
    }
}