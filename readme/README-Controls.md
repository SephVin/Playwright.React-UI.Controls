# Playwright.ReactUI.Controls

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

# Минимальные требования

+ netstandard2.1 / NET6
+ Playwright 1.41.2
+ @skbkontur/react-ui 4.15.0 (рекомендуется использовать последние версии)