namespace Playwright.ReactUI.Tests.Helpers;

public static class StorybookUrl
{
    public static string Get(string storyName)
        => $"http://localhost:6006/iframe.html?id={storyName}&viewMode=story";
}