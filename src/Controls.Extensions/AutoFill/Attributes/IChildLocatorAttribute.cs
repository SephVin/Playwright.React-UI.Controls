using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

public interface IChildLocatorAttribute
{
    string Selector { get; }
    ILocator Resolve(ILocator locator);
}