using System;
using System.Linq;
using System.Reflection;
using Microsoft.Playwright;

namespace Playwright.ReactUI.Controls.Extensions.AutoFill.Attributes;

[AttributeUsage(AttributeTargets.Class)]
public class AutoFillControlsAttribute : Attribute
{
    private const BindingFlags bindingFlags = BindingFlags.Instance |
        BindingFlags.Public |
        BindingFlags.NonPublic |
        BindingFlags.GetProperty |
        BindingFlags.SetProperty;

    public void OnInit(PageBase pageInstance)
        => InitControl(pageInstance);

    public void OnInit(CompoundControlBase compoundControlInstance)
        => InitControl(compoundControlInstance);

    private static void InitControl(object instance)
    {
        var type = instance.GetType();

        foreach (var property in type.GetProperties(bindingFlags))
        {
            if (property.IsDefined(typeof(SkipAutoFillControlAttribute)) ||
                !typeof(ControlBase).IsAssignableFrom(property.PropertyType))
            {
                continue;
            }

            var rootLocator = GetRootLocator(property, instance);

            var value = property.PropertyType.IsGenericType &&
                property.PropertyType.GetGenericTypeDefinition() == typeof(ControlList<>)
                    ? CreateControlList(property, rootLocator, instance)
                    : Activator.CreateInstance(property.PropertyType, rootLocator)
                    ?? throw new ArgumentException($"Значение для '{property.Name}' равно null");

            SetProperty(property, instance, value);
        }
    }

    private static ILocator GetRootLocator(PropertyInfo property, object instance)
    {
        var locatorAttribute = property
            .GetCustomAttributes()
            .OfType<IRootLocatorAttribute>()
            .FirstOrDefault();

        return instance switch
        {
            CompoundControlBase compound => locatorAttribute?.Resolve(compound.RootLocator) ??
                compound.RootLocator.GetByTestId(property.Name),
            PageBase page => locatorAttribute?.Resolve(page.Page) ?? page.Page.GetByTestId(property.Name),
            _ => throw new NotSupportedException(
                $"Неизвестный тип контейнера. Ожидался '{nameof(CompoundControlBase)}' или '{nameof(PageBase)}'")
        };
    }

    private static object CreateControlList(PropertyInfo property, ILocator rootLocator, object instance)
    {
        var locatorAttribute = property
                .GetCustomAttributes()
                .OfType<IChildLocatorAttribute>()
                .FirstOrDefault()
            ?? throw new ArgumentException(
                $"Не задан '{nameof(ChildByTidAttribute)}' для '{property.Name}' в '{instance}'"
            );

        var itemType = property.PropertyType.GetGenericArguments().First();
        var listType = typeof(ControlList<>).MakeGenericType(itemType);
        var factoryType = typeof(Func<,>).MakeGenericType(typeof(ILocator), itemType);
        var factoryMethod = typeof(AutoFillControlsAttribute)
            .GetMethod(nameof(CreateControl), BindingFlags.Static | BindingFlags.NonPublic)!
            .MakeGenericMethod(itemType);

        var itemFactory = Delegate.CreateDelegate(factoryType, factoryMethod);

        return Activator.CreateInstance(
            listType,
            rootLocator,
            (Func<ILocator, ILocator>)(locator => locatorAttribute.Resolve(locator)),
            itemFactory
        ) ?? throw new InvalidOperationException(
            $"Не удалось создать '{listType}'. Убедись, что верно указал значения атрибутов. " +
            $"Или используй '{nameof(SkipAutoFillControlAttribute)}' и инициализируй контрол в конструкторе"
        );
    }

    private static T CreateControl<T>(ILocator locator) where T : ControlBase
        => (T)(Activator.CreateInstance(typeof(T), locator)
                ?? throw new InvalidOperationException(
                    $"Не удалось создать экземпляр '{typeof(T)}'. " +
                    "Убедись, что у него есть публичный конструктор с параметром ILocator. " +
                    $"Или используй '{nameof(SkipAutoFillControlAttribute)}' и инициализируй контрол в конструкторе"
                )
            );

    private static void SetProperty(PropertyInfo property, object instance, object value)
    {
        try
        {
            property.SetValue(instance, value);
        }
        catch (Exception e)
        {
            throw new ArgumentException(
                $"Не удалось установить значение для '{property.Name}' в '{instance}'. Возможно, отсутствует сеттер",
                e
            );
        }
    }
}