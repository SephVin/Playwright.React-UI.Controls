using System.IO;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Constants;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class FileUploaderTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_FileUploader_Is_Visible()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        await fileUploader.WaitForAsync().ConfigureAwait(false);

        var actual = await fileUploader.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_FileUploader_Is_Not_Exist()
    {
        var visibleFileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var notExistingFileUploader = new FileUploader(Page.GetByTestId("HiddenFileUploader"));
        await visibleFileUploader.WaitForAsync().ConfigureAwait(false);

        var actual = await notExistingFileUploader.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_FileUploader_Is_Disabled()
    {
        var fileUploader = await GetFileUploaderAsync("disabled").ConfigureAwait(false);

        var actual = await fileUploader.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_FileUploader_Is_Enabled()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasError_Return_True_When_FileUploader_With_Error()
    {
        var fileUploader = await GetFileUploaderAsync("error").ConfigureAwait(false);

        var actual = await fileUploader.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_FileUploader_Without_Error()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_FileUploader_With_Warning()
    {
        var fileUploader = await GetFileUploaderAsync("warning").ConfigureAwait(false);

        var actual = await fileUploader.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_FileUploader_Without_Warning()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task SetInputFiles_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");

        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToHaveCountAsync(1).ConfigureAwait(false);
        var file = await fileUploader.Files.GetFirstItemAsync().ConfigureAwait(false);
        await file.Name.ExpectV2().ToHaveTextAsync("file-1.txt").ConfigureAwait(false);
    }

    [Test]
    public async Task SetInputFiles_With_Multiple_Files()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");

        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);

        var fileNames = await fileUploader.GetUploadedFileNamesAsync().ConfigureAwait(false);
        fileNames.Should().BeEquivalentTo("file-1.txt", "file-2.txt");
    }

    [Test]
    public async Task RemoveAllFiles_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");
        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveAllFilesAsync().ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task RemoveAllFiles_With_Multiple_Files()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");
        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveAllFilesAsync().ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task RemoveFile_By_Text_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");
        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveFileAsync("file-1.txt").ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task RemoveFile_By_Text_With_Multiple_Files()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");
        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveFileAsync("file-1.txt").ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToHaveCountAsync(1).ConfigureAwait(false);

        var fileNames = await fileUploader.GetUploadedFileNamesAsync().ConfigureAwait(false);
        fileNames.Should().BeEquivalentTo("file-2.txt");
    }

    [Test]
    public async Task RemoveFile_By_Index_With_Single_File()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);
        var filePath = GetPath("file-1.txt");
        await fileUploader.SetInputFilesAsync(filePath).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveFileAsync(0).ConfigureAwait(false);

        await fileUploader.Files.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task RemoveFile_By_Index_With_Multiple_Files()
    {
        var fileUploader = await GetFileUploaderAsync("multiple").ConfigureAwait(false);
        var filePath1 = GetPath("file-1.txt");
        var filePath2 = GetPath("file-2.txt");
        await fileUploader.SetInputFilesAsync(new[] { filePath1, filePath2 }).ConfigureAwait(false);
        await fileUploader.Files.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);

        await fileUploader.RemoveFileAsync(1).ConfigureAwait(false);

        var fileNames = await fileUploader.GetUploadedFileNamesAsync().ConfigureAwait(false);
        fileNames.Should().BeEquivalentTo("file-1.txt");
    }

    [Test]
    public async Task Hover()
    {
        var fileUploader = await GetFileUploaderAsync("with-tooltip").ConfigureAwait(false);
        await fileUploader.WaitForAsync().ConfigureAwait(false);
        var tooltipLocator = Page.GetByText("TooltipText");
        await tooltipLocator.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden })
            .ConfigureAwait(false);

        await fileUploader.HoverAsync().ConfigureAwait(false);

        await tooltipLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetTooltip()
    {
        var fileUploader = await GetFileUploaderAsync("with-tooltip").ConfigureAwait(false);
        await fileUploader.RootLocator.HoverAsync().ConfigureAwait(false);

        var tooltip = await fileUploader.GetTooltipAsync(TooltipType.Information).ConfigureAwait(false);

        await tooltip.RootLocator.Expect().ToHaveTextAsync("TooltipText").ConfigureAwait(false);
    }

    [Test]
    public async Task HasAttribute_Return_True_When_Attribute_Exist()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.HasAttributeAsync("data-tid").ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasAttribute_Return_False_When_Attribute_Not_Exist()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.HasAttributeAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task GetAttribute_Return_Attribute_Value_When_Attribute_Exist_With_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.GetAttributeValueAsync("data-tid").ConfigureAwait(false);

        actual.Should().Be("FileUploaderId");
    }

    [Test]
    public async Task GetAttribute_Return_Empty_When_Attribute_Exist_Without_Value()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.GetAttributeValueAsync("data-attribute-without-value").ConfigureAwait(false);

        actual.Should().BeEmpty();
    }

    [Test]
    public async Task GetAttribute_Return_Null_When_Attribute_Not_Exist()
    {
        var fileUploader = await GetFileUploaderAsync("default").ConfigureAwait(false);

        var actual = await fileUploader.GetAttributeValueAsync("data-tid-2").ConfigureAwait(false);

        actual.Should().BeNull();
    }

    private async Task<FileUploader> GetFileUploaderAsync(string storyName)
    {
        // ReSharper disable once StringLiteralTypo
        await Page.GotoAsync(StorybookUrl.Get($"fileuploader--{storyName}")).ConfigureAwait(false);
        return new FileUploader(Page.GetByTestId("FileUploaderId"));
    }

    private static string GetPath(string fileName) => Path.GetFullPath(Path.Combine("Files", fileName));
}