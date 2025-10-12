using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Constants;

namespace Playwright.ReactUI.Controls;

public class Tabs : ControlBase
{
    private readonly ILocator tabsLocator;
    private readonly ILocator activeTabLocator;

    public Tabs(ILocator rootLocator)
        : base(rootLocator)
    {
        tabsLocator = RootLocator.Locator("[data-tid='Tab__root']");
        activeTabLocator = tabsLocator.And(RootLocator.Locator($"[{DataVisualState.Active}='']"));
        List = new ControlList<Tab>(
            RootLocator,
            _ => tabsLocator,
            x => new Tab(x)
        );
    }

    public ControlList<Tab> List { get; }

    public async Task SelectAsync(string tabName, LocatorClickOptions? options = default)
        => await tabsLocator.GetByText(tabName).ClickAsync(options).ConfigureAwait(false);

    public Tab GetActive() => new(activeTabLocator);
    public Tab GetFirst() => List.GetItem(0);
    public Tab GetByIndex(int index) => List.GetItem(index);

    public async Task<Tab> GetByNameAsync(string name, int timeoutInMilliseconds = 10000)
        => await List.GetFirstItemAsync(
            async tab =>
            {
                var tabName = await tab.GetTextAsync().ConfigureAwait(false);
                return tabName.Equals(name, StringComparison.OrdinalIgnoreCase);
            },
            timeoutInMilliseconds
        ).ConfigureAwait(false);

    public async Task<Tab> GetByNameAsync(Regex regex, int timeoutInMilliseconds = 10000)
        => await List.GetFirstItemAsync(
            async tab =>
            {
                var tabName = await tab.GetTextAsync().ConfigureAwait(false);
                return regex.IsMatch(tabName);
            },
            timeoutInMilliseconds
        ).ConfigureAwait(false);

    public new TabsAssertionsV2 ExpectV2() => new(this);
}