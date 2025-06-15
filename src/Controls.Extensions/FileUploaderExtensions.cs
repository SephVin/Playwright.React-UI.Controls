using System;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class FileUploaderExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this FileUploader fileUploader,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await fileUploader.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this FileUploader input,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await input.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToContainUploadedFilesAsync(
        this FileUploader fileUploader,
        string[] fileNames,
        int timeoutInMilliseconds = 10000
    ) => await fileUploader.ExpectV2().ToContainUploadedFilesAsync(fileNames, timeoutInMilliseconds)
        .ConfigureAwait(false);

    [Obsolete("Используй WaitToBeEnabledAsync")]
    public static async Task WaitEnabledAsync(
        this FileUploader fileUploader,
        LocatorAssertionsToBeEnabledOptions? options = default
    ) => await fileUploader.WaitToBeEnabledAsync(options).ConfigureAwait(false);

    [Obsolete("Используй WaitToBeDisabledAsync")]
    public static async Task WaitDisabledAsync(
        this FileUploader input,
        LocatorAssertionsToBeDisabledOptions? options = default
    ) => await input.WaitToBeDisabledAsync(options).ConfigureAwait(false);
}