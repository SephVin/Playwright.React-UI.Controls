using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class FileUploaderExtensions
{
    public static async Task WaitEnabledAsync(
        this FileUploader input,
        LocatorAssertionsToBeEnabledOptions? options = default)
        => await input.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitDisabledAsync(
        this FileUploader input,
        LocatorAssertionsToBeDisabledOptions? options = default)
        => await input.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);
}