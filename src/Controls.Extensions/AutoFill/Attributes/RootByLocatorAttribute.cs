using System;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class RootByLocatorAttribute : Attribute, IRootLocatorAttribute
{
    public RootByLocatorAttribute(string selector) => Selector = selector;
    public string Selector { get; }

    public ILocator Resolve(ILocator locator) => locator.Locator(Selector);

    public ILocator Resolve(IPage page) => page.Locator(Selector);
}