using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class TextareaAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly Textarea textarea;

    public TextareaAssertionsV2(Textarea textarea)
        : base(textarea)
    {
        this.textarea = textarea;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await textarea.TextareaLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await textarea.TextareaLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.TextareaLocator.Expect().ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task NotToHaveValueAsync(string value, LocatorAssertionsToHaveValueOptions? options = default)
        => await textarea.TextareaLocator.Expect().Not.ToHaveValueAsync(value, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.TextareaLocator.Expect().ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToBeEmptyOptions? options = default)
        => await textarea.TextareaLocator.Expect().Not.ToBeEmptyAsync(options).ConfigureAwait(false);

    public async Task ToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.TextareaLocator.Expect().ToBeFocusedAsync(options).ConfigureAwait(false);

    public async Task NotToBeFocusedAsync(LocatorAssertionsToBeFocusedOptions? options = default)
        => await textarea.TextareaLocator.Expect().Not.ToBeFocusedAsync(options).ConfigureAwait(false);
}