using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class LabelAssertionsV2Tests : TestsBase
{
    [Test]
    public async Task ToBeVisible()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        var label = await GetLabelAsync("hidden").ConfigureAwait(false);
        await label.WaitForAsync().ConfigureAwait(false);

        await label.ExpectV2().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_With_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToHaveAttributeAsync("data-tid", "LabelId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute_Without_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_With_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute_Without_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task ToContainText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().ToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToContainText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.ExpectV2().NotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    private async Task<Label> GetLabelAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"label--{storyName}")).ConfigureAwait(false);
        return new Label(Page.GetByTestId("LabelId"));
    }
}