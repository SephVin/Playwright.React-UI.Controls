using System.Threading.Tasks;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls;

public interface IFocusable
{
    Task FocusAsync(LocatorFocusOptions? options = default);
}