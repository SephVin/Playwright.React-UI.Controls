using System;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Controls;

public class TabTests : TestsBase
{
    [Test]
    public async Task IsVisible_Return_True_When_Tab_Is_Visible()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));
        await tab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await tab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsVisible_Return_False_When_Tab_Is_Not_Exists()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var visibleTab = new Tab(Page.GetByTestId("TabId1"));
        var notExistingTab = new Tab(Page.GetByTestId("UnknownTabId"));
        await visibleTab.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        var actual = await notExistingTab.IsVisibleAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsDisabled_Return_True_When_Tab_Is_Disabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--disabled")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        var actual = await tab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsDisabled_Return_False_When_Tab_Is_Enabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        var actual = await tab.IsDisabledAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsActive_Return_True_When_Tab_Is_Active()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        var actual = await tab.IsActiveAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task IsActive_Return_False_When_Tab_Is_Inactive()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId2"));

        var actual = await tab.IsActiveAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task IsActive_Throws_When_Attribute_Is_Not_Set()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--attribute-is-not-set")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        Assert.ThrowsAsync<Exception>(() => tab.IsActiveAsync());
    }

    [Test]
    public async Task HasError_Return_True_When_Tab_With_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--error")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        var actual = await tab.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasError_Return_False_When_Tab_Without_Error()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        var actual = await tab.HasErrorAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task HasWarning_Return_True_When_Tab_With_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--warning")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId"));

        var actual = await tab.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeTrue();
    }

    [Test]
    public async Task HasWarning_Return_False_When_Tab_Without_Warning()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var tab = new Tab(Page.GetByTestId("TabId1"));

        var actual = await tab.HasWarningAsync().ConfigureAwait(false);

        actual.Should().BeFalse();
    }

    [Test]
    public async Task Click()
    {
        await Page.GotoAsync(StorybookUrl.Get("tab--default")).ConfigureAwait(false);
        var context = Page.GetByTestId("TabId2");
        var tab = new Tab(context);

        await tab.ClickAsync().ConfigureAwait(false);

        await context.Expect().ToHaveAttributeAsync("data-active", "true").ConfigureAwait(false);
    }
}