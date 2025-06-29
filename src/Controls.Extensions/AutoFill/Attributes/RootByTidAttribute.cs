using System;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class RootByTidAttribute : Attribute, IRootLocatorAttribute
{
    public RootByTidAttribute(string selector) => Selector = selector;
    public string Selector { get; }

    public ILocator Resolve(ILocator locator) => locator.GetByTestId(Selector);
    public ILocator Resolve(IPage page) => page.GetByTestId(Selector);
}