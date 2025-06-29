using System.Reflection;
using Microsoft.Playwright;
using Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill;

/// <summary>
///     Используй CompoundControlBase только в том случае, если планируешь использовать AutoFillControlsAttribute
/// </summary>
public class CompoundControlBase : ControlBase
{
    protected CompoundControlBase(ILocator rootLocator)
        : base(rootLocator)
    {
        ExecuteInitAction();
    }

    private void ExecuteInitAction()
    {
        var attr = GetType().GetCustomAttribute<AutoFillControlsAttribute>();
        attr?.OnInit(this);
    }
}