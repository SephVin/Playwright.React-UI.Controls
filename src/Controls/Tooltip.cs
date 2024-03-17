﻿using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public class Tooltip : ControlBase
{
    private readonly ILocator closeLocator;
    private readonly Label content;

    public Tooltip(ILocator context)
        // note: remove Locator("[data-tid='PopupContent']") after deleting react-selenium-testing.js
        : base(context.Locator("[data-tid='PopupContent']"))
    {
        content = new Label(Context.Locator("[data-tid='Tooltip__content']"));
        closeLocator = Context.Locator("[data-tid='Tooltip__crossIcon']");
    }

    public async Task<string> GetTextAsync(LocatorInnerTextOptions? options = default)
        => await content.GetTextAsync(options).ConfigureAwait(false);

    public ControlList<Link> GetLinks()
        => new(Context, "[data-tid='Tooltip__content'] a", x => new Link(x));

    public async Task CloseAsync(LocatorClickOptions? options = default)
        => await closeLocator.ClickAsync(options).ConfigureAwait(false);
}