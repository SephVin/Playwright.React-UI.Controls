# Playwright.React-UI.Controls

Библиотека предназначена для взаимодействия с компонентами [@skbkontur/react-ui](https://github.com/skbkontur/retail-ui) при тестировании с помощью [Playwright.NET](https://github.com/microsoft/playwright-dotnet)

### Как использовать  

В качестве примера взят компонент [Input](https://tech.skbkontur.ru/react-ui/#/Components/Input):  
`<Input data-tid="InputId" />`

**Инициализация**  
`var input = new Input(page.GetByTestId("InputId"));`  

**Взаимодействие**  
`await input.FillAsync("newValue").ConfigureAwait(false);`  

**Проверка**  
`await input.Expect().ToHaveValueAsync("newValue").ConfigureAwait(false);`  

**Создание своего компонента**  
```
public class Header : ControlBase
{
    public Header(ILocator context)
        : base(context)
    {
        Input = new Input(context.GetByTestId("InputId"));
    }
    
    public Input Input { get; }
}
```

# Playwright.React-UI.Controls.Extensions

Библиотека предоставляет набор расширений к библиотеке **Playwright.React-UI.Controls**

### Как использовать  

**Примеры для компонента [Input](https://tech.skbkontur.ru/react-ui/#/Components/Input):**  

+ `await input.AppendTextAsync("newValue").ConfigureAwait(false);` - добавление значения `newValue` в Input  
+ `await input.WaitPresenceAsync().ConfigureAwait(false);` - ожидание видимости компонента на странице  
+ `await input.WaitValueAsync("TODO").ConfigureAwait(false);` - ожидание значения `TODO` в Input'e  

# Минимальные требования

+ netstandard2.1 / NET6
+ @skbkontur/react-ui 4.15.0 (рекомендуется использовать последние версии)

# Запуск Storybook

Если хочется запустить тесты проекта, то наобходим Storybook. Его можно запустить локально или в docker-контейнере 

#### Локальный запуск

+ Должна стоять Node.js (проверялось на версии 18.19.0)
+ Запустить скрипт `scripts/RunLocalStorybook.ps1`

#### Запуск в Docker

+ Должен стоять Docker
+ Запустить скрипт `scripts/RunStorybookInDocker.ps1`
