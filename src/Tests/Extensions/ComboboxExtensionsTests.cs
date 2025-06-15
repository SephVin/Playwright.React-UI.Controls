using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ComboBoxExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var combobox = await GetComboBoxAsync("hidden").ConfigureAwait(false);
        await combobox.WaitForAsync().ConfigureAwait(false);

        await combobox.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEnabled()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeDisabled()
    {
        var combobox = await GetComboBoxAsync("disabled").ConfigureAwait(false);
        await combobox.WaitToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveError()
    {
        var combobox = await GetComboBoxAsync("error").ConfigureAwait(false);
        await combobox.WaitToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveError()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitNotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveWarning()
    {
        var combobox = await GetComboBoxAsync("warning").ConfigureAwait(false);
        await combobox.WaitToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveWarning()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitNotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitToHaveAttributeAsync("data-tid", "ComboBoxId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.WaitToHaveValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveValue_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.WaitToHaveValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.WaitNotToHaveValueAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveValue_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.WaitNotToHaveValueAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeEmpty_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);

        await combobox.WaitToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeEmpty_When_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.WaitNotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToBeEmpty_When_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.WaitNotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeFocused_And_WaitNotToBeFocused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.WaitNotToBeFocusedAsync().ConfigureAwait(false);

        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);
        await combobox.WaitToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeContainItems()
    {
        var combobox = await GetComboBoxAsync("loading").ConfigureAwait(false);

        await combobox.WaitToBeContainItemsAsync(new[] { "First", "Third", "Fifth", "MenuItem" })
            .ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelect()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);

        await combobox.FillAndSelectAsync("First").ConfigureAwait(false);

        await combobox.ExpectV2().ToHaveValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task FillAndSelectFirst()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);

        await combobox.FillAndSelectFirstAsync("Fir").ConfigureAwait(false);

        await combobox.ExpectV2().ToHaveValueAsync("First").ConfigureAwait(false);
    }

    private async Task<Combobox> GetComboBoxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"combobox--{storyName}")).ConfigureAwait(false);
        return new Combobox(Page.GetByTestId("ComboBoxId"));
    }
}