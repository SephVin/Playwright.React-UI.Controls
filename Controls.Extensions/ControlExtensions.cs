using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class ControlExtensions
{
    public static async Task WaitPresenceAsync(
        this ControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public static async Task WaitAbsenceAsync(
        this ControlBase control,
        LocatorAssertionsToBeVisibleOptions? options = default)
        => await control.Expect().Not.ToBeVisibleAsync(options).ConfigureAwait(false);
}