using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ComboBoxAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var combobox = await GetComboBoxAsync("hidden").ConfigureAwait(false);
        await combobox.WaitForAsync().ConfigureAwait(false);

        await combobox.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var combobox = await GetComboBoxAsync("disabled").ConfigureAwait(false);
        await combobox.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveError()
    {
        var combobox = await GetComboBoxAsync("error").ConfigureAwait(false);
        await combobox.ExpectV2().ToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveError()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().NotToHaveErrorAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveWarning()
    {
        var combobox = await GetComboBoxAsync("warning").ConfigureAwait(false);
        await combobox.ExpectV2().ToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveWarning()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().NotToHaveWarningAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().ToHaveAttributeAsync("data-tid", "ComboBoxId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.ExpectV2().ToHaveValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveValue_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.ExpectV2().ToHaveValueAsync("First").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.ExpectV2().NotToHaveValueAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveValue_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.ExpectV2().NotToHaveValueAsync("Second").ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty_When_ComboBox_Is_Focused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty_When_ComboBox_Is_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);

        await combobox.ExpectV2().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty_When_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);
        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);

        await combobox.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty_When_Not_Focused()
    {
        var combobox = await GetComboBoxAsync("filled").ConfigureAwait(false);

        await combobox.ExpectV2().NotToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeFocused_And_NotToBeFocused()
    {
        var combobox = await GetComboBoxAsync("default").ConfigureAwait(false);
        await combobox.ExpectV2().NotToBeFocusedAsync().ConfigureAwait(false);

        await combobox.RootLocator.ClickAsync().ConfigureAwait(false);
        await combobox.ExpectV2().ToBeFocusedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainItems()
    {
        var combobox = await GetComboBoxAsync("loading").ConfigureAwait(false);

        await combobox.ExpectV2().ToContainItemsAsync(new[] { "First", "Third", "Fifth", "MenuItem" })
            .ConfigureAwait(false);
    }

    private async Task<Combobox> GetComboBoxAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"combobox--{storyName}")).ConfigureAwait(false);
        return new Combobox(Page.GetByTestId("ComboBoxId"));
    }
}