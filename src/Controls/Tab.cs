using System;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Assertions;
using Playwright.ReactUI.Controls.Extensions;

namespace Playwright.ReactUI.Controls;

public class Tab : ControlBase
{
    public Tab(ILocator context)
        : base(context)
    {
    }

    public async Task<bool> IsDisabledAsync(LocatorGetAttributeOptions? options = default)
        => await GetAttributeValueAsync("tabindex", options).ConfigureAwait(false) is "-1";

    public async Task<bool> IsActiveAsync(LocatorGetAttributeOptions? options = default)
    {
        var attributeValue = await GetAttributeValueAsync("data-active", options).ConfigureAwait(false);

        if (attributeValue == null)
        {
            throw new Exception("data-active attribute is not set");
        }

        return attributeValue == "true";
    }

    public override ILocatorAssertions Expect() => new TabAssertions(Context.Expect());
}