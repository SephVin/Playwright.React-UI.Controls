using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

public interface IRootLocatorAttribute
{
    string Selector { get; }
    ILocator Resolve(ILocator locator);
    ILocator Resolve(IPage page);
}