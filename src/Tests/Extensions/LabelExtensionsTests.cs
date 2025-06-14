using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class LabelExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitToBeVisible()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToBeHidden()
    {
        var label = await GetLabelAsync("hidden").ConfigureAwait(false);
        await label.WaitForAsync().ConfigureAwait(false);

        await label.WaitToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_With_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToHaveAttributeAsync("data-tid", "LabelId").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveAttribute_Without_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToHaveAttributeAsync("data-tid").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_With_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToHaveAttributeAsync("data-tid", "WrongValue").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveAttribute_Without_Attribute_Value()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToHaveAttributeAsync("data-tid-2").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToHaveTextAsync("TODO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToHaveText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToHaveTextAsync(new Regex("^TO.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToHaveTextAsync("TODO777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToHaveText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToHaveTextAsync(new Regex("^TOD1.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToContainTextAsync("TO").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitToContainText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitToContainTextAsync(new Regex("^T.*")).ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToContainTextAsync("777").ConfigureAwait(false);
    }

    [Test]
    public async Task WaitNotToContainText_With_Regex()
    {
        var label = await GetLabelAsync("default").ConfigureAwait(false);
        await label.WaitNotToContainTextAsync(new Regex("^7.*")).ConfigureAwait(false);
    }

    private async Task<Label> GetLabelAsync(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get($"label--{storyName}")).ConfigureAwait(false);
        return new Label(Page.GetByTestId("LabelId"));
    }
}