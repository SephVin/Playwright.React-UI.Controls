using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class FileUploaderExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var fileUploader = await GetFileUploaderAsync("hidden").ConfigureAwait(false);
        await fileUploader.WaitForAsync().ConfigureAwait(false);

        await fileUploader.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var fileUploader = await GetFileUploaderAsync("disabled").ConfigureAwait(false);
        await fileUploader.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var fileUploader = await GetFileUploaderAsync("error").ConfigureAwait(false);
        await fileUploader.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var fileUploader = await GetFileUploaderAsync("warning").ConfigureAwait(false);
        await fileUploader.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitToHaveAttributeAsync("data-tid", "FileUploaderId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainUploadedFiles_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");
        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);

        await fileUploader.WaitToContainUploadedFilesAsync(new[] { "file-1.txt" }).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainUploadedFiles_With_Multiple_File()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");
        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);

        await fileUploader.WaitToContainUploadedFilesAsync(new[] { "file-1.txt", "file-2.txt" })
            .ConfigureAwait(false);
    }

    private async Task<FileUploader> GetFileUploaderAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"fileuploader--{storyName}")).ConfigureAwait(false);
        return new FileUploader(Page.GetByTestId("FileUploaderId"));
    }

    private static string GetPath(string fileName) => Path.GetFullPath(Path.Combine("Files", fileName));
}