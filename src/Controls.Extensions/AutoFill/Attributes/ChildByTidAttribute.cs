using System;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

[AttributeUsage(AttributeTargets.Property)]
public class ChildByTidAttribute : Attribute, IChildLocatorAttribute
{
    public ChildByTidAttribute(string selector) => Selector = selector;
    public string Selector { get; }

    public ILocator Resolve(ILocator locator) => locator.GetByTestId(Selector);
}