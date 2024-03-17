using System;
using System.Threading.Tasks;

namespace Playwright.ReactUI.Controls.Extensions;

public static class CheckboxExtensions
{
    public static async Task WaitCheckedAsync(this Checkbox checkbox)
        => await checkbox.Expect().ToBeCheckedAsync().ConfigureAwait(false);

    public static async Task WaitUncheckedAsync(this Checkbox checkbox)
        => await checkbox.Expect().Not.ToBeCheckedAsync().ConfigureAwait(false);

    public static async Task WaitEnabledAsync(this Checkbox checkbox)
        => await checkbox.Expect().ToBeEnabledAsync().ConfigureAwait(false);

    public static async Task WaitDisabledAsync(this Checkbox checkbox)
        => await checkbox.Expect().ToBeDisabledAsync().ConfigureAwait(false);

    public static async Task CheckAsync(this Checkbox checkbox)
    {
        if (await checkbox.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new Exception("Checkbox already checked");
        }

        await checkbox.ClickAsync().ConfigureAwait(false);
    }

    public static async Task UncheckAsync(this Checkbox checkbox)
    {
        if (!await checkbox.IsCheckedAsync().ConfigureAwait(false))
        {
            throw new Exception("Checkbox already unchecked");
        }

        await checkbox.ClickAsync().ConfigureAwait(false);
    }
}