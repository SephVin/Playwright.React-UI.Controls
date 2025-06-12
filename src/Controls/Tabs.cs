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

    public async Task SelectAsync(string tabName)
        => await tabsLocator.GetByText(tabName).ClickAsync().ConfigureAwait(false);

    public Tab GetActive() => new(activeTabLocator);

    public async Task<Tab> GetFirstAsync()
        => await List.GetItemAsync(0).ConfigureAwait(false);

    public async Task<Tab> GetByIndexAsync(int index)
        => await List.GetItemAsync(index).ConfigureAwait(false);

    public async Task<Tab> GetByNameAsync(string name)
        => await List.GetFirstItemAsync(async x => await x.GetTextAsync().ConfigureAwait(false) == name)
            .ConfigureAwait(false);

    public async Task<Tab> GetByNameAsync(Regex regex)
        => await List.GetFirstItemAsync(
            async x =>
            {
                var text = await x.GetTextAsync().ConfigureAwait(false);
                return regex.IsMatch(text);
            }).ConfigureAwait(false);

    public new TabsAssertionsV2 ExpectV2() => new(this);
}