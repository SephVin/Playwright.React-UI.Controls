using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class LocatorExtensions
{
    public static ILocatorAssertions Expect(this ILocator locator)
        => Microsoft.Playwright.Assertions.Expect(locator);

    public static async Task<string?> GetAttributeValueAsync(
        this ILocator locator,
        string attributeName,
        LocatorGetAttributeOptions? options = default)
        => await locator.GetAttributeAsync(attributeName, options).ConfigureAwait(false);
}