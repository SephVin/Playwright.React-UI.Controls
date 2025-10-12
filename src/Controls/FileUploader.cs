using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Controls.Providers;

namespace Playwright.ReactUI.Controls;

public class FileUploader : ControlBase
{
    private readonly ILocator inputLocator;

    public FileUploader(ILocator rootLocator)
        : base(rootLocator)
    {
        inputLocator = rootLocator.Locator("input");
        Files = new ControlList<File>(
            rootLocator,
            locator => locator.Locator("[data-tid='FileUploader__file']"),
            locator => new File(locator)
        );
    }

    public ControlList<File> Files { get; }

    public async Task<bool> IsDisabledAsync(LocatorIsDisabledOptions? options = default)
        => await inputLocator.IsDisabledAsync(options).ConfigureAwait(false);

    public async Task SetInputFilesAsync(
        string value,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(value, options).ConfigureAwait(false);

    public async Task SetInputFilesAsync(
        IEnumerable<string> files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public async Task SetInputFilesAsync(
        FilePayload files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public async Task SetInputFilesAsync(
        IEnumerable<FilePayload> files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public async Task RemoveAllFilesAsync(LocatorClickOptions? options = default)
    {
        var files = await Files.GetItemsAsync().ConfigureAwait(false);

        for (var i = files.Count - 1; i >= 0; i--)
        {
            await files[i].RemoveAsync(options).ConfigureAwait(false);
        }
    }

    public async Task RemoveFileAsync(string name, LocatorClickOptions? options = default)
    {
        var file = await Files.GetFirstItemAsync(
            async file =>
            {
                var fileNames = await file.Name.GetTextAsync().ConfigureAwait(false);
                return fileNames.Equals(name, StringComparison.OrdinalIgnoreCase);
            }).ConfigureAwait(false);

        await file.RemoveAsync(options).ConfigureAwait(false);
    }

    public async Task RemoveFileAsync(int index, LocatorClickOptions? options = default)
    {
        var file = Files.GetItem(index);
        await file.RemoveAsync(options).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<string>> GetUploadedFileNamesAsync()
    {
        var files = await Files.GetItemsAsync().ConfigureAwait(false);

        return await files
            .ToAsyncEnumerable()
            .SelectAwait(async x => await x.Name.GetTextAsync().ConfigureAwait(false))
            .ToArrayAsync()
            .ConfigureAwait(false);
    }

    public async Task<Tooltip> GetTooltipAsync(TooltipType type)
        => await TooltipProvider.GetTooltipAsync(type, this).ConfigureAwait(false);

    [Obsolete("Используй ExpectV2. В будущих версиях этот метод будет удален")]
    public override ILocatorAssertions Expect() => inputLocator.Expect();

    public new FileUploaderAssertionsV2 ExpectV2() => new(this, inputLocator);
}

public class File : ControlBase
{
    internal File(ILocator rootLocator)
        : base(rootLocator)
    {
        Name = new Label(rootLocator.Locator("[data-tid='FileUploader__fileName']"));
        Size = new Label(rootLocator.Locator("[data-tid='FileUploader__fileSize']"));
        Icon = new Label(rootLocator.Locator("[data-tid='FileUploader__fileIcon']"));
    }

    public Label Name { get; }
    public Label Size { get; }
    public Label Icon { get; }

    public async Task RemoveAsync(LocatorClickOptions? options = default)
        => await Icon.ClickAsync(options).ConfigureAwait(false);
}