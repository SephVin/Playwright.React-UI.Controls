using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls.Assertions;

public class ControlListAssertionsV2<TItem> : ControlBaseAssertionsV2 where TItem : ControlBase
{
    private readonly ControlList<TItem> controlList;

    public ControlListAssertionsV2(ControlList<TItem> controlList)
        : base(controlList)
    {
        this.controlList = controlList;
    }

    public override async Task ToBeVisibleAsync(LocatorAssertionsToBeVisibleOptions? options = default)
        => await controlList.ItemsLocator.First.Expect().ToBeVisibleAsync(options).ConfigureAwait(false);

    public override async Task ToBeHiddenAsync(LocatorAssertionsToBeHiddenOptions? options = default)
        => await controlList.ItemsLocator.First.Expect().ToBeHiddenAsync(options).ConfigureAwait(false);

    public async Task ToHaveCountAsync(int number, LocatorAssertionsToHaveCountOptions? options = default)
        => await controlList.ItemsLocator.Expect().ToHaveCountAsync(number, options).ConfigureAwait(false);

    public async Task ToBeEmptyAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await controlList.ItemsLocator.Expect().ToHaveCountAsync(0, options).ConfigureAwait(false);

    public async Task NotToBeEmptyAsync(LocatorAssertionsToHaveCountOptions? options = default)
        => await controlList.ItemsLocator.Expect().Not.ToHaveCountAsync(0, options).ConfigureAwait(false);
}