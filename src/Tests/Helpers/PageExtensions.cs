﻿using Microsoft.Playwright;

namespace Playwright.ReactUI.Tests.Helpers;

public static class PageExtensions
{
    public static IPageAssertions Expect(this IPage page)
        => Assertions.Expect(page);
}