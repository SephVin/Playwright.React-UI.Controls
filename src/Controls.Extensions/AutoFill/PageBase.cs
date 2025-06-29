using System.Reflection;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill;

/// <summary>
///     Используй PageBase только в том случае, если планируешь использовать AutoFillControlsAttribute
/// </summary>
public class PageBase
{
    protected PageBase(IPage page)
    {
        Page = page;
        ExecuteInitAction();
    }

    public IPage Page { get; }

    private void ExecuteInitAction()
    {
        var attr = GetType().GetCustomAttribute<AutoFillControlsAttribute>();
        attr?.OnInit(this);
    }
}