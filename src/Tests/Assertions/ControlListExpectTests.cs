using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Assertions;

public class ControlListExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var visibleList = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        var notExistingList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await visibleList.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingList.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var visibleList = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        var notExistingList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await visibleList.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingList.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var visibleList = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        var notExistingList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));
        await visibleList.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingList.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().ToHaveAttributeAsync("data-tid", "RootId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().Not.ToHaveAttributeAsync("data-tid", "not-RadioGroupId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().ToHaveCountAsync(3).ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RootId"),
            locator => locator.Locator("[data-tid='Radio__root']"),
            x => new Radio(x));

        await list.Expect().Not.ToHaveCountAsync(2).ConfigureAwait(false);
    }
}