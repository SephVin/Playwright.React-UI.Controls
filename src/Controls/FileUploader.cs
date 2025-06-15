using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class FileUploader : ControlBase
{
    private readonly ILocator inputLocator;

    public FileUploader(ILocator context)
        : base(context)
    {
        inputLocator = context.Locator("input");
    }

    public virtual async Task SetInputFilesAsync(
        string value,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(value, options).ConfigureAwait(false);

    public virtual async Task SetInputFilesAsync(
        IEnumerable<string> files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public virtual async Task SetInputFilesAsync(
        FilePayload files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public virtual async Task SetInputFilesAsync(
        IEnumerable<FilePayload> files,
        LocatorSetInputFilesOptions? options = default
    ) => await inputLocator.SetInputFilesAsync(files, options).ConfigureAwait(false);

    public override ILocatorAssertions Expect() => inputLocator.Expect();
}