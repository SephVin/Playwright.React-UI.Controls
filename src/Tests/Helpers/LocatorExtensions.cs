using Microsoft.Playwright;

namespace Playwright.ReactUI.Tests.Helpers;

public static class LocatorExtensions
{
    public static ILocatorAssertions Expect(this ILocator locator)
        => Assertions.Expect(locator);
}