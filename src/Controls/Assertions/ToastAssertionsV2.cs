using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ToastAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Toast toast;

    public ToastAssertionsV2(Toast toast)
        : base(toast.RootLocator)
    {
        this.toast = toast;
    }

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await toast.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);

    public async Task ToHaveTextAsync(Regex regex, LocatorAssertionsToHaveTextOptions? options = default)
        => await toast.RootLocator.Expect().ToHaveTextAsync(regex, options).ConfigureAwait(false);
}