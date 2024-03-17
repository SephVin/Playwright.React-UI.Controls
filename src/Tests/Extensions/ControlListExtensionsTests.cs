using System.Linq;
using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Extensions;

public class ControlListExtensionsTests : TestsBase
{
    [Test]
    public async Task WaitPresence()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));
        await list.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await list.WaitPresenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitAbsence()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var visibleList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));
        var notExistList = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId2"),
            "[data-tid='Radio__root']",
            x => new Radio(x));
        await visibleList.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistList.WaitAbsenceAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task WaitCount()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));

        await list.WaitCountAsync(3).ConfigureAwait(false);
    }

    [Test]
    public async Task ClickFirstItem()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));

        await list.ClickFirstItemAsync().ConfigureAwait(false);

        var items = await list.GetItemsAsync().ConfigureAwait(false);
        await items.First().Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ClickLastItem()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));

        await list.ClickLastItemAsync().ConfigureAwait(false);

        var items = await list.GetItemsAsync().ConfigureAwait(false);
        await items.Last().Expect().ToBeCheckedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task GetFirst()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));

        var actual = await list.GetFirstAsync().ConfigureAwait(false);

        await actual.Expect().ToHaveTextAsync("TODO 1").ConfigureAwait(false);
    }

    [Test]
    public async Task GetLast()
    {
        await Page.GotoAsync(StorybookUrl.Get("controllist--default")).ConfigureAwait(false);
        var list = new ControlList<Radio>(
            Page.GetByTestId("RadioGroupId"),
            "[data-tid='Radio__root']",
            x => new Radio(x));

        var actual = await list.GetLastAsync().ConfigureAwait(false);

        await actual.Expect().ToHaveTextAsync("TODO 3").ConfigureAwait(false);
    }
}