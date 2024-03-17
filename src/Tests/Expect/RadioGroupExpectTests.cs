using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class RadioGroupExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var visibleRadioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("UnknownRadioGroupId"));
        await visibleRadioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadioGroup.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var visibleRadioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("UnknownRadioGroupId"));
        await visibleRadioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadioGroup.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var visibleRadioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));
        var notExistingRadioGroup = new RadioGroup(Page.GetByTestId("UnknownRadioGroupId"));
        await visibleRadioGroup.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingRadioGroup.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.Expect().ToHaveAttributeAsync("data-tid", "RadioGroupId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("radiogroup--default")).ConfigureAwait(false);
        var radioGroup = new RadioGroup(Page.GetByTestId("RadioGroupId"));

        await radioGroup.Expect().Not.ToHaveAttributeAsync("data-tid", "not-RadioGroupId").ConfigureAwait(false);
    }
}