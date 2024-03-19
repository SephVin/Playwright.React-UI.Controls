using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

internal static class PageExtensions
{
    public static IPageAssertions Expect(this IPage page)
        => Microsoft.Playwright.Assertions.Expect(page);
}