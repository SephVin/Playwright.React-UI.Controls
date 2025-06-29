# Playwright.ReactUI.Controls.Extensions

Библиотека предоставляет набор расширений к **Playwright.ReactUI.Controls**, а также атрибуты для автозаполнения контролов в PageObjects и PageElements

### Как использовать  

**Примеры для компонента [Input](https://tech.skbkontur.ru/kontur-ui/?path=/docs/react-ui_input-data-input--docs):**  

+ `await input.AppendTextAsync("newValue").ConfigureAwait(false);` - добавление значения `newValue` к уже существующему в Input  
+ `await input.WaitToBeVisibleAsync().ConfigureAwait(false);` - ожидание видимости компонента на странице  
+ `await input.WaitToHaveValueAsync("TODO").ConfigureAwait(false);` - ожидание значения `TODO` в Input'e  

**AutoFillControlsAttribute**

Чтобы воспользоваться атрибутом **AutoFillControls** необходимо следующее:
- Страница (PageObject) должна наследоваться от **PageBase**. Если у вас есть свой базовый класс страницы, то он должен наследовать **PageBase**
- Составной / сложный компонент (PageElement), т.е. контрол, который состоит из нескольких контролов (см. пример ниже), должен наследоваться от **CompoundControlBase**, а не **ControlBase**
- На PageObject / PageElement навесить атрибут [AutoFillControls]

Для заполнения самих контролов существует несколько атрибутов:
- **RootByTid** - ищет контрол по переданному data-tid'у
- **RootByLocator** - ищет контрол по переданному селектору (css / xpath)
- **ChildByTid** - ищет элемент списка по переданному data-tid'у; используется **только** для инициализации **ControlList** совместно с **RootByTid / RootByLocator**
- **ChildByLocator** - ищет элемент списка по переданному селектору (css / xpath); используется **только** для инициализации **ControlList** совместно с **RootByTid / RootByLocator**
- **SkipAutoFillControl** - если по каким-то причинам контрол нельзя автозаполнить, то необходимо навесить на него атрибут **SkipAutoFillControl** и инициализировать в конструкторе

Библиотека предоставляет возможность создать свой атрибут для заполнения контролов. Для этого надо реализовать **IRootLocatorAttribute** и(или) **IChildLocatorAttribute** (см. пример ниже)    
**Если появится желание реализовать свой атрибут, то лучше сначало прийти в меня. Возможно ваш атрибут лучше поместить в библиотеку**

Если никакой атрибут заполнения контрола не указан, то **AutoFillControls** будет искать контрол по data-tid'у имени свойства

**Примеры использования AutoFillControlsAttribute**

```
// PageObject
[AutoFillControls]
public class TestPage : PageBase
{
    public TestPage(IPage page)
        : base(page)
    {
    }

    // Контрол инициализируется с data-tid'ом Compound
    public Compound Compound { get; init; }

    // Контрол инициализируется с data-tid'ом LinkId
    [RootByTid("LinkId")]
    public Link Link { get; init; }

    // Контрол инициализируется с локатором LocatorId (здесь может быть css / xpath)
    [RootByLocator("LocatorId")]
    public Input Input { get; init; }
}

// PageElement
[AutoFillControls]
public class Compound : CompoundControlBase
{
    public Compound(ILocator rootLocator)
        : base(rootLocator)
    {
        Button = new Button(rootLocator.GetByText("ButtonId"));
    }

    // Контрол инициализируется в конструкторе и не будет автозаполняться
    [SkipAutoFillControl]
    public Button Button { get; init; }

    // Для создания списка необходимо указать Root* и Child* атрибуты. Child атрибут должен быть обязательно указан
    [RootByTid("RootList")]
    [ChildByLocator("ChildItem")]
    public ControlList<Label> List { get; init; }
}
```

**Пример реализации IRootLocatorAttribute**

```
// Ищет контрол по GetByText
[AttributeUsage(AttributeTargets.Property)]
public class RootByTextAttribute : Attribute, IRootLocatorAttribute
{
    public RootByTextAttribute(string selector) => Selector = selector;
    public string Selector { get; }

    public ILocator Resolve(ILocator locator) => locator.GetByText(Selector);

    public ILocator Resolve(IPage page) => page.GetByText(Selector);
}
```

# Минимальные требования

+ netstandard2.0 / NET6
+ Playwright 1.51.0
+ @skbkontur/react-ui 4.25.2 (рекомендуется использовать последние версии)