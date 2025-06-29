using System;
using System.Reflection;
using FluentAssertions;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Controls;
using Playwright.ReactUI.Controls.Extensions.AutoFill;
using Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

#pragma warning disable CS8618

namespace Playwright.ReactUI.Tests.Extensions.AutoFill;

public class AutoFillControlsTests : TestsBase
{
    [Test]
    public void AutoFill()
    {
        var page = new TestPage(Page);

        GetSelectorValue(page.Button.RootLocator).Should().Be("internal:testid=[data-tid=\"Button\"]");
        GetSelectorValue(page.Link.RootLocator).Should().Be("internal:testid=[data-tid=\"LinkId\"]");
        GetSelectorValue(page.Input.RootLocator).Should().Be("LocatorId");

        GetSelectorValue(page.Compound.RootLocator).Should().Be("internal:testid=[data-tid=\"Compound\"]");
        GetSelectorValue(page.Compound.Button.RootLocator).Should()
            .Be("internal:testid=[data-tid=\"Compound\"] >> internal:text=\"ButtonId\"i");
        GetSelectorValue(page.Compound.List.ItemsLocator).Should()
            .Be("internal:testid=[data-tid=\"Compound\"] >> RootList >> ChildItem");
    }

    private static string GetSelectorValue(ILocator locator)
    {
        var fieldInfo = locator.GetType().GetField("_selector", BindingFlags.Instance | BindingFlags.NonPublic);

        if (fieldInfo == null)
            throw new InvalidOperationException("Поле _selector не найдено");

        return fieldInfo.GetValue(locator)?.ToString() ?? string.Empty;
    }
}

[AutoFillControls]
public class TestPage : PageBase
{
    public TestPage(IPage page)
        : base(page)
    {
    }

    public Compound Compound { get; init; }

    public Button Button { get; init; }

    [RootByTid("LinkId")]
    public Link Link { get; init; }

    [RootByLocator("LocatorId")]
    public Input Input { get; init; }
}

[AutoFillControls]
public class Compound : CompoundControlBase
{
    public Compound(ILocator rootLocator)
        : base(rootLocator)
    {
        Button = new Button(rootLocator.GetByText("ButtonId"));
    }

    [SkipAutoFillControl]
    public Button Button { get; init; }

    [RootByLocator("RootList")]
    [ChildByLocator("ChildItem")]
    public ControlList<Label> List { get; init; }
}