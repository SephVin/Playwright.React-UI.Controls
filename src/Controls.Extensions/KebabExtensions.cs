using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions;

public static class KebabExtensions
{
    public static async Task WaitToBeEnabledAsync(
        this Kebab kebab,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await kebab.ExpectV2().ToBeEnabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToBeDisabledAsync(
        this Kebab kebab,
        LocatorAssertionsToHaveAttributeOptions? options = default
    ) => await kebab.ExpectV2().ToBeDisabledAsync(options).ConfigureAwait(false);

    public static async Task WaitToContainItemsAsync(
        this Kebab kebab,
        string[] itemTexts,
        int timeoutInMilliseconds = 10000
    ) => await kebab.ExpectV2().ToContainItemsAsync(itemTexts, timeoutInMilliseconds).ConfigureAwait(false);
}