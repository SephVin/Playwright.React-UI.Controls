using System.IO;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class FileUploaderAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var fileUploader = await GetFileUploaderAsync("hidden").ConfigureAwait(false);
        await fileUploader.WaitForAsync().ConfigureAwait(false);

        await fileUploader.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var fileUploader = await GetFileUploaderAsync("disabled").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var fileUploader = await GetFileUploaderAsync("error").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var fileUploader = await GetFileUploaderAsync("warning").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToHaveAttributeAsync("data-tid", "FileUploaderId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainUploadedFiles_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");
        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);

        await fileUploader.ExpectV2().ToContainUploadedFilesAsync(new[] { "file-1.txt" }).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainUploadedFiles_With_Multiple_File()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");
        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);

        await fileUploader.ExpectV2().ToContainUploadedFilesAsync(new[] { "file-1.txt", "file-2.txt" })
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