using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;

namespace Playwright.ReactUI.Controls;

public class Toast : ControlBase
{
    public Toast(ILocator rootLocator)
        : base(rootLocator)
    {
    }

    public async Task GetTextAsync(LocatorInnerTextOptions? options = default)
        => await RootLocator.InnerTextAsync(options).ConfigureAwait(false);

    public new ToastAssertionsV2 ExpectV2() => new(this);
}