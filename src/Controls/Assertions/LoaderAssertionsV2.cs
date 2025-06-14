using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class LoaderAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Loader loader;

    public LoaderAssertionsV2(Loader loader)
        : base(loader)
    {
        this.loader = loader;
    }

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await loader.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}