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

Для "подключения" набора достаточно добавить к своему компоненту следующую строчку:
```
public new HeaderAssertions ExpectV2() => new(this);
```

# Playwright.ReactUI.Controls.Extensions

Библиотека предоставляет набор расширений к **Playwright.ReactUI.Controls**

### Как использовать  

**Примеры для компонента [Input](https://tech.skbkontur.ru/kontur-ui/?path=/docs/react-ui_input-data-input--docs):**  

+ `await input.AppendTextAsync("newValue").ConfigureAwait(false);` - добавление значения `newValue` к уже существующему в Input  
+ `await input.WaitToBeVisibleAsync().ConfigureAwait(false);` - ожидание видимости компонента на странице  
+ `await input.WaitToHaveValueAsync("TODO").ConfigureAwait(false);` - ожидание значения `TODO` в Input'e  

# Минимальные требования

+ netstandard2.0 / NET6
+ Playwright 1.51.0
+ @skbkontur/react-ui 4.25.2 (рекомендуется использовать последние версии)

# Запуск Storybook

Для запуска тестов в проектах Controls и Controls.Extensions необходим Storybook. Его можно запустить локально или в docker-контейнере 

#### Локальный запуск

+ Установить Node.js (проверялось на версии 18.19.0)
+ Запустить скрипт `scripts/RunLocalStorybook.ps1`

#### Запуск в Docker

+ Установить Docker
+ Запустить скрипт `scripts/RunStorybookInDocker.ps1`
