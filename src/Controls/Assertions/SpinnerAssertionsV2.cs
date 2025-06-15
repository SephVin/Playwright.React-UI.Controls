using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class SpinnerAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Spinner spinner;

    public SpinnerAssertionsV2(Spinner spinner)
        : base(spinner)
    {
        this.spinner = spinner;
    }

    public async Task ToHaveTextAsync(string text, LocatorAssertionsToHaveTextOptions? options = default)
        => await spinner.RootLocator.Expect().ToHaveTextAsync(text, options).ConfigureAwait(false);
}