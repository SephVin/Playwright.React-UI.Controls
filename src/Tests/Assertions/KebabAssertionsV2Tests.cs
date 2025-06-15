using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class KebabAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var kebab = await GetKebabAsync("hidden").ConfigureAwait(false);
        await kebab.WaitForAsync().ConfigureAwait(false);

        await kebab.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        var kebab = await GetKebabAsync("disabled").ConfigureAwait(false);
        await kebab.ExpectV2().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().ToHaveAttributeAsync("data-tid", "KebabId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);
        await kebab.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainItems()
    {
        var kebab = await GetKebabAsync("default").ConfigureAwait(false);

        await kebab.ExpectV2().ToContainItemsAsync(new[] { "TODO 1" })
            .ConfigureAwait(false);
    }

    private async Task<Kebab> GetKebabAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"kebab--{storyName}")).ConfigureAwait(false);
        return new Kebab(Page.GetByTestId("KebabId"));
    }
}