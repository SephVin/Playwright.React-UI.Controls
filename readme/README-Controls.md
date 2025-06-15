# Playwright.ReactUI.Controls

Библиотека предназначена для взаимодействия с компонентами [@skbkontur/react-ui](https://github.com/skbkontur/retail-ui) при тестировании с помощью [Playwright.NET](https://github.com/microsoft/playwright-dotnet)

### Как использовать  

В качестве примера взят компонент [Input](https://tech.skbkontur.ru/kontur-ui/?path=/docs/react-ui_input-data-input--docs):  
`<Input data-tid="InputId" />`

**Инициализация**  
`var input = new Input(page.GetByTestId("InputId"));`  

**Взаимодействие**  
`await input.FillAsync("newValue").ConfigureAwait(false);`  

**Проверка**  
`await input.ExpectV2().ToHaveValueAsync("newValue").ConfigureAwait(false);`  

**Создание своего компонента**  
```
public class Header : ControlBase
{
    public Header(ILocator rootLocator)
        : base(rootLocator)
    {
        SomeInput = new Input(rootLocator.GetByTestId("InputId"));
    }
    
    public Input SomeInput { get; }
}
```

**Создание набора ассертов к своему компоненту**
```
public class HeaderAssertions : ControlBaseAssertionsV2
{
    private readonly Header header;
    
    public HeaderAssertions(Header header)
        : base(header)
    {
        this.header = header;
    }
    
    public async Task ToBeVisibleAsync()
        => await header.RootLocator.Expect().ToBeVisibleAsync().ConfigureAwait(false);
}
```

Для "подключения" набора достаточно добавить к своему компоненту:
```
public new HeaderAssertions ExpectV2() => new(this);
```


# Минимальные требования

+ netstandard2.0 / NET6
+ Playwright 1.51.0
+ @skbkontur/react-ui 4.25.2 (рекомендуется использовать последние версии)