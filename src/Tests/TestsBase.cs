﻿using System;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;
using Playwright.ReactUI.Tests.Helpers;

[assembly: LevelOfParallelism(4)]

namespace Playwright.ReactUI.Tests;

[Parallelizable(ParallelScope.Self)]
public class TestsBase
{
    private IBrowser browser = null!;
    private IBrowserContext browserContext = null!;
    private IPlaywright playwright = null!;
    protected IPage Page { get; private set; } = null!;

    [OneTimeSetUp]
    public async Task OneTimeSetUpAsync()
    {
        playwright = await Microsoft.Playwright.Playwright.CreateAsync().ConfigureAwait(false);
        playwright.Selectors.SetTestIdAttribute("data-tid");
        browser = await LaunchBrowserAsync().ConfigureAwait(false);
        browserContext = await browser.NewContextAsync(
            new BrowserNewContextOptions
            {
                JavaScriptEnabled = true,
                ViewportSize = ViewportSize.NoViewport,
                Locale = "ru-RU"
            }
        ).ConfigureAwait(false);
        SetAssertionsDefaultTimeout();
    }

    [SetUp]
    public async Task SetUpAsync()
    {
        Page = await browserContext.NewPageAsync().ConfigureAwait(false);
    }

    [TearDown]
    public async Task TearDownAsync()
    {
        await Page.CloseAsync().ConfigureAwait(false);
    }

    [OneTimeTearDown]
    public async Task OneTimeTearDownAsync()
    {
        await browserContext.CloseAsync().ConfigureAwait(false);
        playwright.Dispose();
    }

    private async Task<IBrowser> LaunchBrowserAsync()
    {
        var options = new BrowserTypeLaunchOptions
        {
            Headless = BuildServerDetector.Detected,
            IgnoreDefaultArgs = new[] { "--enable-automation" },
            Args = new[] { "--start-maximized" },
            ChromiumSandbox = false
        };

        try
        {
            return await playwright.Chromium.LaunchAsync(options).ConfigureAwait(false);
        }
        catch (PlaywrightException e) when (e.Message.Contains("Executable doesn't exist"))
        {
            var exitCode = Program.Main(new[] { "install", "chromium" });

            if (exitCode != 0)
            {
                throw new Exception($"Playwright exited with code {exitCode}");
            }

            return await playwright.Chromium.LaunchAsync(options).ConfigureAwait(false);
        }
    }

    // https://github.com/microsoft/playwright-dotnet/issues/2603
    private static void SetAssertionsDefaultTimeout()
    {
        typeof(Microsoft.Playwright.Playwright).Assembly.GetType("Microsoft.Playwright.Core.AssertionsBase")!
            .GetMethod("SetDefaultTimeout", BindingFlags.Static | BindingFlags.Public)!
            .Invoke(null, new object[] { 10 * 1000 });
    }
}