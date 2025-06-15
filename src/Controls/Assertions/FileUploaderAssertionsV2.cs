using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class FileUploaderAssertionsV2 : ControlBaseAssertionsV2
{
    private readonly FileUploader fileUploader;
    private readonly ILocator inputLocator;

    public FileUploaderAssertionsV2(FileUploader fileUploader, ILocator inputLocator)
        : base(fileUploader)
    {
        this.fileUploader = fileUploader;
        this.inputLocator = inputLocator;
    }

    public async Task ToBeEnabledAsync(LocatorAssertionsToBeEnabledOptions? options = default)
        => await inputLocator.Expect().ToBeEnabledAsync(options).ConfigureAwait(false);

    public async Task ToBeDisabledAsync(LocatorAssertionsToBeDisabledOptions? options = default)
        => await inputLocator.Expect().ToBeDisabledAsync(options).ConfigureAwait(false);

    public async Task ToContainUploadedFilesAsync(
        string[] expectedFileNames,
        int timeoutInMilliseconds = 10000)
    {
        using var cts = new CancellationTokenSource(timeoutInMilliseconds);

        while (true)
        {
            try
            {
                var fileNames = await fileUploader.GetUploadedFileNamesAsync().ConfigureAwait(false);
                var set = new HashSet<string>(fileNames, StringComparer.OrdinalIgnoreCase);

                if (expectedFileNames.All(x => set.Contains(x)))
                {
                    return;
                }

                await Task.Delay(100, cts.Token).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                break;
            }
        }

        throw new TimeoutException(
            $"Не дождались наличия элементов [{string.Join(", ", expectedFileNames)}] в списке FileUploader за {timeoutInMilliseconds}ms.");
    }
}