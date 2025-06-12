using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ControlListAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var list = await GetControlListAsync("hidden").ConfigureAwait(false);
        await list.WaitForAsync().ConfigureAwait(false);

        await list.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveCount()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().ToHaveCountAsync(3).ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().ToHaveAttributeAsync("data-tid", "RootId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var list = await GetControlListAsync("default").ConfigureAwait(false);
        await list.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    private async Task<ControlList<Radio>> GetControlListAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"controllist--{storyName}")).ConfigureAwait(false);

        return new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
    }
}