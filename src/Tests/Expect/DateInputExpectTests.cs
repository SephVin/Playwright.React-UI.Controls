using System.Threading.Tasks;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Tests.Helpers;

namespace Playwright.ReactUI.Tests.Expect;

public class DateInputExpectTests : TestsBase
{
    [Test]
    public async Task ToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));
        await dateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await dateInput.Expect().ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeAttached()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var visibleDateInput = new DateInput(Page.GetByTestId("DateInputId"));
        var notExistingDateInput = new DateInput(Page.GetByTestId("UnknownDateInputId"));
        await visibleDateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDateInput.Expect().Not.ToBeAttachedAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--disabled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeDisabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToBeDisabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEditable()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--disabled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToBeEditableAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEmpty()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--filled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToBeEmptyAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeEnabled()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--disabled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToBeEnabledAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var visibleDateInput = new DateInput(Page.GetByTestId("DateInputId"));
        var notExistingDateInput = new DateInput(Page.GetByTestId("UnknownDateInputId"));
        await visibleDateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDateInput.Expect().ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeHidden()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToBeHiddenAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task NotToBeVisible()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var visibleDateInput = new DateInput(Page.GetByTestId("DateInputId"));
        var notExistingDateInput = new DateInput(Page.GetByTestId("UnknownDateInputId"));
        await visibleDateInput.Expect().ToBeVisibleAsync().ConfigureAwait(false);

        await notExistingDateInput.Expect().Not.ToBeVisibleAsync().ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToHaveAttributeAsync("data-tid", "DateInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveAttribute()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToHaveAttributeAsync("type", "not-DateInputId").ConfigureAwait(false);
    }

    [Test]
    public async Task ToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--filled")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().ToHaveTextAsync("24.08.2022").ConfigureAwait(false);
    }

    [Test]
    public async Task NotToHaveText()
    {
        await Page.GotoAsync(StorybookUrl.Get("dateinput--default")).ConfigureAwait(false);
        var dateInput = new DateInput(Page.GetByTestId("DateInputId"));

        await dateInput.Expect().Not.ToHaveTextAsync("24.08.2022").ConfigureAwait(false);
    }
}