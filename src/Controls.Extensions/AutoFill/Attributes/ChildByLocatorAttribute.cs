using System;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ChildByLocatorAttribute : Attribute, IChildLocatorAttribute
{
    public ChildByLocatorAttribute(string selector) => Selector = selector;
    public string Selector { get; }

    public ILocator Resolve(ILocator locator) => locator.Locator(Selector);
}