# Playwright.ReactUI.Controls.Extensions

Библиотека предоставляет набор расширений к библиотеке **Playwright.ReactUI.Controls**

### Как использовать  

**Примеры для компонента [Input](https://tech.skbkontur.ru/react-ui/#/Components/Input):**  

+ `await input.AppendTextAsync("newValue").ConfigureAwait(false);` - добавление значения `newValue` к уже существующему в Input  
+ `await input.WaitPresenceAsync().ConfigureAwait(false);` - ожидание видимости компонента на странице  
+ `await input.WaitValueAsync("TODO").ConfigureAwait(false);` - ожидание значения `TODO` в Input'e  


# Минимальные требования

+ netstandard2.1 / NET6
+ Playwright 1.41.2
+ @skbkontur/react-ui 4.15.0 (рекомендуется использовать последние версии)