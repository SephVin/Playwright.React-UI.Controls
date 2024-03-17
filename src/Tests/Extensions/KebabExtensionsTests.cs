using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class KebabExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var visibleKebab = new Kebab(Page.GetByTestId("KebabId"));
        var notExistingKebab = new Kebab(Page.GetByTestId("UnknownKebabId"));
        await visibleKebab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingKebab.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--disabled")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.WaitDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("kebab--default")).ConfigureAwait(false);
        var kebab = new Kebab(Page.GetByTestId("KebabId"));

        await kebab.WaitEnabledAsync().ConfigureAwait(false);
    }
}