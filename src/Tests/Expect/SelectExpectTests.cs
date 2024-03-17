using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class SelectExpectTests : TestsBase
{
    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task ToBeAttached(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToBeAttached(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingSelect.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--disabled-button")]
    [TestCase("select--disabled-link")]
    public async Task ToBeDisabled(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToBeDisabled(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task ToBeEnabled(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--disabled-button")]
    [TestCase("select--disabled-link")]
    public async Task NotToBeEnabled(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task ToBeHidden(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingSelect.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToBeHidden(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task ToBeVisible(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToBeVisible(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var visibleSelect = new Select(Page.GetByTestId("SelectId"));
        var notExistingSelect = new Select(Page.GetByTestId("UnknownSelectId"));
        await visibleSelect.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingSelect.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task ToHaveAttribute(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToHaveAttributeAsync("data-tid", "SelectId").ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToHaveAttribute(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().Not.ToHaveAttributeAsync("data-tid", "not-SelectId").ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--filled-button")]
    [TestCase("select--filled-link")]
    public async Task ToHaveText(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().ToHaveTextAsync("Two").ConfigureAwait(false);
    }

    [Test]
    [TestCase("select--default-button")]
    [TestCase("select--default-link")]
    public async Task NotToHaveText(string storyName)
    {
        await Page.GotoAsync(StorybookUrl.Get(storyName)).ConfigureAwait(false);
        var select = new Select(Page.GetByTestId("SelectId"));

        await select.Expect().Not.ToHaveTextAsync("Not-TODO").ConfigureAwait(false);
    }
}